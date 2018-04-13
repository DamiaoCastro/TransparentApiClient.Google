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

            byte[] serviceAccountBQCredentials = System.IO.File.ReadAllBytes(@"bigquery-admin.json");
            byte[] serviceAccountPSCredentials = System.IO.File.ReadAllBytes(@"pubsub-admin.json");



            var tabledataclient = new Resources.Tabledata(serviceAccountBQCredentials);

            //Console.WriteLine("--- listasync --- ");

            //var list1 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table1", 10, null, "bool,boolean", null, CancellationToken.None).Result;
            //var list2 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table2", null, null, null, null, CancellationToken.None).Result;
            //var list3 = tabledataclient.ListAsync("extensiontest", "damiao-1982", "table3", null, null, null, null, CancellationToken.None).Result;

            //Console.WriteLine("--- insertallasync --- ");
            //var tt = DateTime.UtcNow;
            //var tasks = new List<Task>();
            //for (int j = 0; j <= 100; j++) {

            //    var rows = new List<Schema.TableDataInsertAllRequest.Row>();
            //    for (int i = 0; i <= 1000; i++) {
            //        string guid = Guid.NewGuid().ToString();
            //        rows.Add(new Schema.TableDataInsertAllRequest.Row() { insertId = guid, json = new { column1 = guid } });
            //    }

            //    var requestbody = new Schema.TableDataInsertAllRequest() { rows = rows };
            //    var t1 = DateTime.UtcNow;
            //    var insertall = tabledataclient.InsertAllAsync("extensiontest", "damiao-1982", "table3", requestbody, null, CancellationToken.None)
            //        .ContinueWith((insertAllTask) => {

            //            BaseResponse<Schema.TableDataInsertAllResponse> insertAllResult = insertAllTask.Result;

            //            Console.WriteLine($"elapsed {(DateTime.UtcNow - t1).TotalSeconds} seconds");
            //            Console.WriteLine($"success: {insertAllResult.Success}");
            //            Console.WriteLine($"insertErrors count: {insertAllResult.Response.insertErrors?.Count()}");
            //            Console.WriteLine("-----");
            //        });

            //    tasks.Add(insertall);

            //    if (tasks.Count % 10 == 0 && tasks.Count(c => !c.IsCompleted) > 5) {
            //        Task.WhenAny(tasks.Where(c => !c.IsCompleted)).Wait();
            //    }
            //}

            //Task.WhenAll(tasks).Wait();

            //Console.WriteLine($"total elapsed {(DateTime.UtcNow - tt).TotalSeconds} seconds");


            //Console.WriteLine("--- MessagesClient --- ");
            //var messagesClient = new Gmail.V1.Resources.Users(serviceAccountCredentials);
            //var list = messagesClient.GetProfileAsync("ccc", CancellationToken.None).Result;

            //Console.WriteLine("--- MessagesClient --- ");

            string projectId = "damiao-1982";
            {
                string topicId = "test1";
                var topicsClient = new Google.PubSub.V1.Resources.Topics(serviceAccountPSCredentials);
                var publish = topicsClient.PublishAsync($"projects/{projectId}/topics/{topicId}",
                    new PubSub.V1.Schema.PublishRequest() {
                        messages = new List<PubSub.V1.Schema.PubsubMessage>() {
                        new PubSub.V1.Schema.PubsubMessage(){
                                data =Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes( "test")),
                                //data = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes( System.IO.File.ReadAllText(@"pubsub-admin.json"))),
                            }
                        }
                    },
                    null, CancellationToken.None).Result;

                Console.WriteLine($"success: {publish.Success}");
            }

            {
                string subscriptionId = "subscriptionId";
                string subscription = $"projects/{projectId}/subscriptions/{subscriptionId}";
                var subscriptionsClient = new Google.PubSub.V1.Resources.Subscriptions(serviceAccountPSCredentials);
                var response = subscriptionsClient.PullAsync(subscription,
                       new PubSub.V1.Schema.PullRequest() {
                           maxMessages = 10,
                           returnImmediately = false
                       },
                       null,
                       CancellationToken.None).Result;

                IEnumerable<string> ackIds = response.Response.receivedMessages.Select(c => c.ackId);

                Console.WriteLine($"success: {response.Success}, messages:{string.Join(',', response.Response.receivedMessages.Select(c => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(c.message.data))))}");
                
                var ack = subscriptionsClient.AcknowledgeAsync(subscription,
                       new PubSub.V1.Schema.AcknowledgeRequest() {
                           ackIds = ackIds
                       },
                       null,
                       CancellationToken.None).Result;

                Console.WriteLine($"ack success: {ack.Success}");

            }

            Console.ReadLine();

        }
    }
}
