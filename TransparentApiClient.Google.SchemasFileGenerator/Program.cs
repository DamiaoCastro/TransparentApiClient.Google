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

                        GoogleApiDiscover googleApiDiscover = GetApiDiscover(url).Result;

                        //schema
                        {
                            var codeGeneratorService = new SchemaCodeGeneratorService();
                            foreach ((string id, string fileContent) in codeGeneratorService.GetFileContents(googleApiDiscover)) {
                                var path = Path.Combine(@"..\TransparentApiClient.Google.BigQuery.V2\Schema\", $"{id}.cs");
                                if (!string.IsNullOrWhiteSpace(fileContent)) {
                                    File.WriteAllText(path, fileContent.ToString());
                                }
                            }
                        }

                        //api
                        {
                            var codeGeneratorService = new ApiCodeGeneratorService();
                            foreach ((string id, string fileContent) in codeGeneratorService.GetFileContents(googleApiDiscover)) {
                                var path = Path.Combine(@"..\TransparentApiClient.Google.BigQuery.V2\Resources\", $"{id}.cs");
                                if (!string.IsNullOrWhiteSpace(fileContent)) {
                                    File.WriteAllText(path, fileContent.ToString());
                                }
                            }
                        }
                        
                    }).Wait();

                    break;
            }

            return known;
        }

        private static ConsoleKeyInfo ShowMenu() {
            Console.WriteLine("Generate files for:");
            Console.WriteLine("1: BigQuery");
            Console.WriteLine("0: Exit");
            return Console.ReadKey();
        }

        static Task<GoogleApiDiscover> GetApiDiscover(string url) {
            //HttpResponseMessage httpResponse;
            //using (var httpClient = new HttpClient()) {
            //    httpResponse = await httpClient.GetAsync(new Uri(url));
            //}

            //string responseContent = await httpResponse.Content.ReadAsStringAsync();
            string responseContent = System.IO.File.ReadAllText("bq-api.json");
            GoogleApiDiscover googleApiDiscover = JsonConvert.DeserializeObject<GoogleApiDiscover>(responseContent);
            return Task.FromResult(googleApiDiscover);
        }

    }
}