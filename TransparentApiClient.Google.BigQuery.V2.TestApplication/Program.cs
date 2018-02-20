using System;
using System.Diagnostics;
using System.Threading;

namespace TransparentApiClient.Google.BigQuery.V2.TestApplication {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("--- tabledataclient --- ");

            byte[] serviceAccountCredentials = System.IO.File.ReadAllBytes(@"credencials.json");
            var tabledataclient = new Resources.Tabledata(serviceAccountCredentials);

            Console.WriteLine("--- listasync --- ");

            var list1 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table1", 10, null, "bool,boolean", null, CancellationToken.None).Result;
            var list2 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table2", null, null, null, null, CancellationToken.None).Result;
            var list3 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table3", null, null, null, null, CancellationToken.None).Result;

            Console.WriteLine("--- insertallasync --- ");

            var insertid = DateTime.UtcNow.ToString();

            var requestbody = new Schema.TableDataInsertAllRequest() {
                rows = new Schema.TableDataInsertAllRequest.Row[] {
                    new Schema.TableDataInsertAllRequest.Row() { insertId = insertid, json = new { column1 = insertid } }
                }
            };
            var insertall = tabledataclient.InsertAllAsync("extensiontest", "damiao-1982", "table3", requestbody, CancellationToken.None).Result;

            Console.WriteLine("--- MessagesClient --- ");
            var messagesClient = new Gmail.V1.Resources.Users(serviceAccountCredentials);
            var list = messagesClient.GetProfileAsync("ccc", CancellationToken.None).Result;

            Debugger.Break();

        }
    }
}
