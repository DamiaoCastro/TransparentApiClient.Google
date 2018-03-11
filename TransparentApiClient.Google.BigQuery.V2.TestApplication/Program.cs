using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.TestApplication {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("--- tabledataclient --- ");

            byte[] serviceAccountCredentials = System.IO.File.ReadAllBytes(@"credencials.json");
            var tabledataclient = new Resources.Tabledata(serviceAccountCredentials);

            //Console.WriteLine("--- listasync --- ");

            //var list1 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table1", 10, null, "bool,boolean", null, CancellationToken.None).Result;
            //var list2 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table2", null, null, null, null, CancellationToken.None).Result;
            //var list3 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table3", null, null, null, null, CancellationToken.None).Result;

            Console.WriteLine("--- insertallasync --- ");
            var tt = DateTime.UtcNow;
            var tasks = new List<Task>();
            for (int j = 0; j <= 100; j++) {

                var rows = new List<Schema.TableDataInsertAllRequest.Row>();
                for (int i = 0; i <= 1000; i++) {
                    string guid = Guid.NewGuid().ToString();
                    rows.Add(new Schema.TableDataInsertAllRequest.Row() { insertId = guid, json = new { column1 = guid } });
                }

                var requestbody = new Schema.TableDataInsertAllRequest() { rows = rows };
                var t1 = DateTime.UtcNow;
                var insertall = tabledataclient.InsertAllAsync("extensiontest", "damiao-1982", "table3", requestbody, null, CancellationToken.None)
                    .ContinueWith((insertAllTask) => {

                        BaseResponse<Schema.TableDataInsertAllResponse> insertAllResult = insertAllTask.Result;
                        
                        Console.WriteLine($"elapsed {(DateTime.UtcNow - t1).TotalSeconds} seconds");
                        Console.WriteLine($"success: {insertAllResult.Success}");
                        Console.WriteLine($"insertErrors count: {insertAllResult.Response.insertErrors?.Count()}");
                        Console.WriteLine("-----");
                    });

                tasks.Add(insertall);

                if (tasks.Count % 10 == 0 && tasks.Count(c => !c.IsCompleted) > 5) {
                    Task.WhenAny(tasks.Where(c => !c.IsCompleted)).Wait();
                }
            }

            Task.WhenAll(tasks).Wait();

            Console.WriteLine($"total elapsed {(DateTime.UtcNow - tt).TotalSeconds} seconds");


            //Console.WriteLine("--- MessagesClient --- ");
            //var messagesClient = new Gmail.V1.Resources.Users(serviceAccountCredentials);
            //var list = messagesClient.GetProfileAsync("ccc", CancellationToken.None).Result;

            Console.ReadLine();

        }
    }
}
