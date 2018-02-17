using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransparentApiClient.Google.SchemasFileGenerator {
    internal class ApiCodeGeneratorService {

        private string newLine = Environment.NewLine;

        internal IEnumerable<(string id, string fileContent)> GetFileContents(GoogleApiDiscover googleApiDiscover) {

            foreach (JProperty schemaProperty in googleApiDiscover.resources.Children()) {

                Console.WriteLine($"resources property '{schemaProperty.Name}'");

                yield return GetClassCodeString(schemaProperty);
            }

        }

        (string id, string content) GetClassCodeString(JProperty schemaProperty) {

            string id = CamelCase(schemaProperty.Name);
            var children = schemaProperty.Children().Values("methods").First();

            string classContent = GetClassCodeString(id, children);
            if (!string.IsNullOrWhiteSpace(classContent)) {

                var classGenerator = new StringBuilder("using System.Threading;");
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

        private string GetClassCodeString(string id, IEnumerable<JToken> methods) {

            var methodsCodeList = new List<string>();
            foreach (JToken method in methods) {

                var methodCode = GetMethodCode(method);
                methodsCodeList.Add(methodCode);
            }

            var allMethodsCode = string.Join(newLine, methodsCodeList);

            var classGenerator = new StringBuilder($"\tpublic class {id} : BaseClient {{{newLine}{newLine}");
            classGenerator.AppendLine($"\t\tpublic {id}(byte[] serviceAccountCredentials)");
            classGenerator.AppendLine($"\t\t    : base(serviceAccountCredentials, \"\", new string[] {{ }}) {{");
            classGenerator.AppendLine($"\t\t}}{newLine}");

            classGenerator.AppendLine(allMethodsCode);
            classGenerator.AppendLine("\t}");

            return classGenerator.ToString();
        }

        private string GetMethodCode(JToken methodToken) {

            var method = JsonConvert.DeserializeObject<GoogleApiDiscoverMethod>(methodToken.First().ToString());

            //id
            var methodName = method.id.Split(".").Last();
            methodName = CamelCase(methodName);
            //parameters
            //parameterOrder
            //request
            //response
            //scopes

            string description = null;
            if (!string.IsNullOrWhiteSpace(method.description)) {
                description = $"\t\t/// <summary>{newLine}\t\t/// {method.description}{newLine}\t\t/// </summary>";
            }

            var methodBuilder = new StringBuilder($"\t\tpublic Task<BaseResponse<object>> {methodName}Async(CancellationToken cancellationToken) {{{newLine}");
            methodBuilder.AppendLine($"{newLine}\t\t\treturn SendAsync(HttpMethod.Post, $\"\", null, cancellationToken)");
            methodBuilder.AppendLine("\t\t\t\t.ContinueWith(HandleBaseResponse<object>, cancellationToken)");
            methodBuilder.AppendLine($"\t\t\t\t.Unwrap();");
            methodBuilder.AppendLine($"{newLine}\t\t}}");

            return $"{description}{newLine}{methodBuilder.ToString()}";
        }

        private static string CamelCase(string name) {
            return $"{ name.Substring(0, 1).ToUpper()}{ name.Substring(1)}";
        }

        private static string GetValueString(JToken token, string propertyName) {
            return token.Values(propertyName).First().ToObject<JValue>().Value.ToString();
        }

    }
}