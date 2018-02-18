using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransparentApiClient.Google.SchemasFileGenerator {
    internal class ApiCodeGeneratorService {

        private string newLine = Environment.NewLine;

        internal IEnumerable<(string id, string fileContent)> GetFileContents(GoogleApiDiscover googleApiDiscover) {

            foreach (KeyValuePair<string, GoogleApiDiscoverResource> schemaProperty in googleApiDiscover.resources) {

                Console.WriteLine($"resources property '{schemaProperty.Key}'");

                yield return GetClassCodeString(googleApiDiscover, schemaProperty);
            }

        }

        (string id, string content) GetClassCodeString(GoogleApiDiscover googleApiDiscover, KeyValuePair<string, GoogleApiDiscoverResource> schemaProperty) {

            string id = CamelCase(schemaProperty.Key);

            string classContent = GetClassCodeString(googleApiDiscover, id, schemaProperty.Value.methods);
            if (!string.IsNullOrWhiteSpace(classContent)) {

                var classGenerator = new StringBuilder();
                classGenerator.AppendLine("using System;");
                classGenerator.AppendLine("using System.Threading;");
                classGenerator.AppendLine("using System.Net.Http;");
                classGenerator.AppendLine("using System.Threading.Tasks;");
                classGenerator.AppendLine($"using TransparentApiClient.Google.Core;{newLine}");
                classGenerator.AppendLine($"namespace TransparentApiClient.Google.BigQuery.V2.Resources {{ {newLine}");
                classGenerator.AppendLine(classContent);
                classGenerator.Append($"}}");

                return (id, classGenerator.ToString());
            }

            return (id, null);
        }

        private string GetClassCodeString(GoogleApiDiscover googleApiDiscover, string id, Dictionary<string, GoogleApiDiscoverMethod> methods) {

            var methodsCodeList = new List<string>();
            foreach (KeyValuePair<string, GoogleApiDiscoverMethod> method in methods) {

                var methodCode = GetMethodCode(method);
                methodsCodeList.Add(methodCode);
            }

            var allMethodsCode = string.Join(newLine, methodsCodeList);

            IEnumerable<string> scopes = methods.SelectMany(c => c.Value.scopes).Distinct().Select(c => $"\"{c}\"");

            var classGenerator = new StringBuilder($"\tpublic class {id} : BaseClient {{{newLine}{newLine}");
            classGenerator.AppendLine($"\t\tpublic {id}(byte[] serviceAccountCredentials)");
            classGenerator.AppendLine($"\t\t    : base(serviceAccountCredentials, \"{googleApiDiscover.baseUrl}\",");
            classGenerator.AppendLine($"\t\t    \t\tnew string[] {{{string.Join(",", scopes)}}}) {{");
            classGenerator.AppendLine($"\t\t}}{newLine}");

            classGenerator.AppendLine(allMethodsCode);
            classGenerator.AppendLine("\t}");

            return classGenerator.ToString();
        }

        private string GetMethodCode(KeyValuePair<string, GoogleApiDiscoverMethod> methodToken) {

            var method = methodToken.Value;

            //id
            var methodName = method.id.Split(".").Last();
            methodName = CamelCase(methodName);
            //parameters
            var functionParams = new List<string>(GetFunctionParameters(method.parameters));
            var hasRequestBody = !string.IsNullOrWhiteSpace(method.request?.refName);
            var requestBodyVar = "null";
            if (hasRequestBody) {
                requestBodyVar = CamelCase(method.request.refName);
                functionParams.Add($"Schema.{method.request.refName} {requestBodyVar}");
            }
            functionParams.Add("CancellationToken cancellationToken");
            var parameters = string.Join(", ", functionParams);

            var responseClass = string.IsNullOrWhiteSpace(method.response?.refName) ? "object" : $"Schema.{method.response.refName}";

            string description = GetDescription(method);

            string functionBody = GetFunctionBody(method, methodName, requestBodyVar, parameters, responseClass);

            return $"{description}{functionBody.ToString()}";
        }

        private string GetFunctionBody(GoogleApiDiscoverMethod method, string methodName, string requestBodyVar, string parameters, string responseClass) {

            var httpMethod = GetHttpMethod(method);

            var methodBuilder = new StringBuilder($"\t\tpublic Task<BaseResponse<{responseClass}>> {methodName}Async({parameters}) {{{newLine}");

            //validation
            foreach (var param in method.parameters.Where(c => c.Value.required)) {
                if (param.Value.type.ToLower() == "string") {
                    methodBuilder.AppendLine($"\t\t\tif (string.IsNullOrWhiteSpace({param.Key})) {{ throw new ArgumentNullException(nameof({param.Key})); }}");
                } else {
                    System.Diagnostics.Debugger.Break();
                }
            }

            //queryBuilder
            var queryStringOnPath = string.Empty;
            var qQueryParameters = method.parameters.Where(c => c.Value.location == "query");
            if (qQueryParameters.Any()) {
                methodBuilder.AppendLine($"{newLine}\t\t\tstring queryString = GetQueryString(new {{{string.Join(", ", qQueryParameters.Select(c => c.Key))}}});");
                queryStringOnPath = "?{queryString}";
            }

            //remaining function body
            methodBuilder.AppendLine($"{newLine}\t\t\treturn SendAsync(HttpMethod.{httpMethod}, $\"{method.path}{queryStringOnPath}\", {requestBodyVar}, cancellationToken)");
            methodBuilder.AppendLine($"\t\t\t\t.ContinueWith(HandleBaseResponse<{responseClass}>, cancellationToken)");
            methodBuilder.AppendLine($"\t\t\t\t.Unwrap();{newLine}\t\t}}");

            return methodBuilder.ToString();
        }

        private string GetDescription(GoogleApiDiscoverMethod method) {
            var description = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(method.description)) {
                description.AppendLine($"\t\t/// <summary>{newLine}\t\t/// {method.description}{newLine}\t\t/// </summary>");
                foreach (var item in method.parameters.Where(c => c.Value.location == "path")) {
                    description.AppendLine($"\t\t/// <param name=\"{item.Key}\">{item.Value.description}</param>");
                }
                foreach (var item in method.parameters.Where(c => c.Value.location != "path")) {
                    description.AppendLine($"\t\t/// <param name=\"{item.Key}\">{item.Value.description}</param>");
                }
            }

            return description.ToString();
        }

        private string GetHttpMethod(GoogleApiDiscoverMethod method) {
            var qHttpMethod = typeof(System.Net.Http.HttpMethod).GetProperties().FirstOrDefault(c => c.Name.ToLower() == method.httpMethod.ToLower());
            if (qHttpMethod != null) {
                return qHttpMethod.Name;
            }

            return "Post";
        }

        private IEnumerable<string> GetFunctionParameters(Dictionary<string, GoogleApiDiscoverMethodParameter> parameters) {
            foreach (var param in parameters.Where(c => c.Value.location == "path")) {
                yield return $"{ToCSType(param.Value.type)} {param.Key}";
            }
            foreach (var param in parameters.Where(c => c.Value.location != "path")) {
                var nullableString = string.Empty;
                if (!param.Value.required) {
                    var optionalPossible = (!new string[] { "string", "array", "object" }.Contains(param.Value.type));
                    if (optionalPossible) { nullableString = "?"; }
                }
                yield return $"{ToCSType(param.Value.type)}{nullableString} {param.Key}";
            }
        }

        private string ToCSType(string type) {
            switch (type.ToLower()) {
                case "integer":
                    return "int";
                case "boolean":
                    return "bool";
            }
            return type;
        }

        private string CamelCase(string name) {
            return $"{ name.Substring(0, 1).ToUpper()}{ name.Substring(1)}";
        }

        private string GetValueString(JToken token, string propertyName) {
            return token.Values(propertyName).First().ToObject<JValue>().Value.ToString();
        }

    }
}