using System;
using System.Diagnostics;
using System.Threading;

namespace TransparentApiClient.Google.BigQuery.V2.TestApplication {
    class Program {
        static void Main(string[] args) {
            
            Console.WriteLine("--- TabledataClient --- ");

            byte[] serviceAccountCredentials = System.IO.File.ReadAllBytes(@"credencials.json");
            var tabledataClient = new Tabledata.TabledataClient(serviceAccountCredentials, "damiao-1982");

            Console.WriteLine("--- ListAsync --- ");

            var list1 = tabledataClient.ListAsync("extensiontest", "table1", 10, null, "Bool,Boolean", null, CancellationToken.None).Result;
            var list2 = tabledataClient.ListAsync("extensiontest", "table2", null, null, null, null, CancellationToken.None).Result;
            var list3 = tabledataClient.ListAsync("extensiontest", "table3", null, null, null, null, CancellationToken.None).Result;

            Console.WriteLine("--- InsertAllAsync --- ");

            var insertId = DateTime.UtcNow.ToString();

            var requestBody = new Tabledata.InsertAllRequest() {
                rows = new Tabledata.InsertAllRequest.Row[] {
                    new Tabledata.InsertAllRequest.Row() { insertId = insertId, json = new { column1 = insertId } }
                }
            };
            var insertAll = tabledataClient.InsertAllAsync("extensiontest", "table3", requestBody, CancellationToken.None).Result;

            Debugger.Break();

        }
    }
}
