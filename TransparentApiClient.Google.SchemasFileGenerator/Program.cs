using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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

                    Task.Run(() => {
                        var url = "https://www.googleapis.com/discovery/v1/apis/bigquery/v2/rest";
                        var basePath = @"..\TransparentApiClient.Google.BigQuery.V2";
                        var @namespace = "TransparentApiClient.Google.BigQuery.V2";
                        WriteFiles(url, basePath, @namespace);

                    }).Wait();

                    break;
                case '2':

                    Task.Run(() => {

                        var url = "https://www.googleapis.com/discovery/v1/apis/gmail/v1/rest";
                        var basePath = @"..\TransparentApiClient.Google.Gmail.V1";
                        var @namespace = "TransparentApiClient.Google.Gmail.V1";
                        WriteFiles(url, basePath, @namespace);

                    }).Wait();

                    break;
                case '3':

                    Task.Run(() => {

                        var url = "https://www.googleapis.com/discovery/v1/apis/pubsub/v1/rest";
                        var basePath = @"..\TransparentApiClient.Google.PubSub.V1";
                        var @namespace = "TransparentApiClient.Google.PubSub.V1";
                        WriteFiles(url, basePath, @namespace);

                    }).Wait();

                    break;
            }

            return known;
        }

        private static void WriteFiles(string url, string basePath, string @namespace) {
            GoogleApiDiscover googleApiDiscover = GetApiDiscover(url).Result;

            //schema
            {
                var codeGeneratorService = new SchemaCodeGeneratorService(@namespace);
                foreach ((string id, string fileContent) in codeGeneratorService.GetFileContents(googleApiDiscover)) {
                    var path = Path.Combine($@"{basePath}\Schema\", $"{id}.cs");
                    if (!string.IsNullOrWhiteSpace(fileContent)) {
                        File.WriteAllText(path, fileContent.ToString());
                    }
                }
            }

            //api
            {
                var codeGeneratorService = new ApiCodeGeneratorService(@namespace);
                foreach ((string id, string fileContent) in codeGeneratorService.GetFileContents(googleApiDiscover)) {
                    var path = Path.Combine($@"{basePath}\Resources\", $"{id}.cs");
                    if (!string.IsNullOrWhiteSpace(fileContent)) {
                        File.WriteAllText(path, fileContent.ToString());
                    }
                }
            }
        }

        private static ConsoleKeyInfo ShowMenu() {
            Console.WriteLine("Generate files for:");
            Console.WriteLine("1: BigQuery");
            Console.WriteLine("2: Gmail");
            Console.WriteLine("3: PubSub");
            Console.WriteLine("0: Exit");
            return Console.ReadKey();
        }

        static async Task<GoogleApiDiscover> GetApiDiscover(string url) {
            HttpResponseMessage httpResponse;
            using (var httpClient = new HttpClient()) {
                httpResponse = await httpClient.GetAsync(new Uri(url));
            }

            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            //string responseContent = System.IO.File.ReadAllText("gmail-api.json");
            GoogleApiDiscover googleApiDiscover = JsonConvert.DeserializeObject<GoogleApiDiscover>(responseContent,
                new JsonSerializerSettings() { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
            return googleApiDiscover;
        }

    }
}