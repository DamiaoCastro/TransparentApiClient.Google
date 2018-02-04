using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.PubSub.V1.Topics {
    public class TopicsClient : BaseClient {

        public TopicsClient(byte[] serviceAccountCredentials) :
            base(serviceAccountCredentials, "https://pubsub.googleapis.com/v1/", new string[] { "https://www.googleapis.com/auth/pubsub" }) {
        }

        //CreateAsync

        //DeleteAsync

        //GetAsync

        //GetIamPolicyAsync

        //ListAsync

        /// <summary>
        /// https://cloud.google.com/pubsub/docs/reference/rest/v1/projects.topics/publish
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="topicId"></param>
        /// <param name="messages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseResponse<PublishResponse>> PublishAsync(string projectId, string topicId, IEnumerable<string> messages, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (string.IsNullOrWhiteSpace(topicId)) { throw new ArgumentNullException(nameof(topicId)); }
            if (messages == null) { throw new ArgumentNullException(nameof(messages)); }

            var pubSubMessages = new { messages = messages.Select(c => new { data = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(c)) }) };

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/topics/{topicId}:publish", pubSubMessages, cancellationToken)
                .ContinueWith(HandleBaseResponse<PublishResponse>, cancellationToken)
                .Unwrap();

        }

        //SetIamPolicyAsync

        //TestIamPermissionsAsync

    }
}