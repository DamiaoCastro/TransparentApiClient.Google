using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TransparentApiClient.Google.SchemasFileGenerator {
    class Program {

        static void Main(string[] args) {

            var key = ShowMenu();
            while (key.KeyChar != '0') {

                ExecuteOption(key);

                Console.WriteLine("\n---Done---\n");

                key = ShowMenu();
            }

        }

        private static bool ExecuteOption(ConsoleKeyInfo key) {

            var known = false;

            switch (key.KeyChar) {
                case '1':

                    Task.Run(async () => {

                        var url = "https://www.googleapis.com/discovery/v1/apis/bigquery/v2/rest";
                        GoogleApiDiscover googleApiDiscover = await GetApiDiscover(url);

                        foreach (JProperty schemaProperty in googleApiDiscover.schemas.Children()) {

                            Console.WriteLine($"schema property '{schemaProperty.Name}'");

                            var children = schemaProperty.Children();

                            var id = children.Values("id").First().ToObject<JValue>().Value;

                            IEnumerable<JToken> properties = children.Values("properties");
                            if (properties.Count() > 0) {
                                var propertiesString = properties.First().Select(c => GetPropertyCodeString(c)).ToArray();

                                var fileContent = new StringBuilder($"using System.Collections.Generic;\n\nnamespace TransparentApiClient.Google.BigQuery.V2.Schema {{ \npublic class {id} {{ \n ");
                                foreach (var item in properties.First().Select(c => GetPropertyCodeString(c))) {
                                    fileContent.AppendLine(item);
                                }
                                fileContent.Append("\n} \n}\n");
                                var path = Path.Combine(@"..\TransparentApiClient.Google.BigQuery.V2\Schema\", $"{id}.cs");
                                File.WriteAllText(path, fileContent.ToString());
                            }

                        }

                    }).Wait();

                    break;
            }

            return known;
        }

        private static string GetPropertyCodeString(JToken token) {

            string name = ((JProperty)token).Name;

            string typeName = "object";
            var type = token.Values("type");
            if (type.Count() > 0) {
                typeName = type.First().ToObject<JValue>().Value.ToString();

                switch (typeName.ToLower()) {
                    case "any":
                        typeName = "object";
                        break;
                    case "boolean":
                        typeName = "bool";
                        break;
                    case "integer":
                        typeName = "int";
                        break;
                    case "number":
                        typeName = token.Values("format").First().ToObject<JValue>().Value.ToString();
                        break;
                    case "array":
                        typeName = "IEnumerable<object>";
                        break;
                }
            }

            var property = $"public {typeName} {name} {{ get; set; }}";

            var descriptionString = string.Empty;
            var description = token.Values("description");
            if (description.Count() > 0) {
                descriptionString = $"/// <summary>\n/// {description.First().ToObject<JValue>().Value.ToString()}\n/// </summary>";
            }

            if (string.IsNullOrWhiteSpace(descriptionString)) {
                return property;
            } else {
                return $"{descriptionString}\n{property}";
            }

        }

        private static Task<GoogleApiDiscover> GetApiDiscover(string url) {
            //HttpResponseMessage httpResponse;
            //using (var httpClient = new HttpClient()) {
            //    httpResponse = await httpClient.GetAsync(new Uri(url));
            //}

            //string responseContent = await httpResponse.Content.ReadAsStringAsync();
            string responseContent = System.IO.File.ReadAllText("bq-api.json");
            GoogleApiDiscover googleApiDiscover = JsonConvert.DeserializeObject<GoogleApiDiscover>(responseContent);
            return Task.FromResult(googleApiDiscover);
        }

        private static ConsoleKeyInfo ShowMenu() {
            Console.WriteLine("Generate files for:");
            Console.WriteLine("1: BigQuery");
            Console.WriteLine("0: Exit");
            return Console.ReadKey();
        }

    }
}