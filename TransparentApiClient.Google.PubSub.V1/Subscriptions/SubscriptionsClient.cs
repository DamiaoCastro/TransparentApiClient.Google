using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.PubSub.V1.Subscriptions {
    public class SubscriptionsClient : BaseClient {

        public SubscriptionsClient(byte[] serviceAccountCredentials) :
            base(serviceAccountCredentials, "https://pubsub.googleapis.com/v1/", new string[] { "https://www.googleapis.com/auth/pubsub" }) {
        }

        /// <summary>
        /// https://cloud.google.com/pubsub/docs/reference/rest/v1/projects.subscriptions/acknowledge
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="ackIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseResponse<JObject>> AcknowledgeAsync(string projectId, string subscriptionId, IEnumerable<string> ackIds, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (string.IsNullOrWhiteSpace(subscriptionId)) { throw new ArgumentNullException(nameof(subscriptionId)); }
            if (ackIds == null) { throw new ArgumentNullException(nameof(ackIds)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/subscriptions/{subscriptionId}:acknowledge", new { ackIds }, cancellationToken)
                .ContinueWith(HandleBaseResponse<JObject>, cancellationToken)
                .Unwrap();

        }

        /// <summary>
        /// https://cloud.google.com/pubsub/docs/reference/rest/v1/projects.subscriptions/create
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="requestBody"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseResponse<JObject>> CreateAsync(string projectId, CreateRequest requestBody, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (requestBody == null) { throw new ArgumentNullException(nameof(requestBody)); }

            return SendAsync(HttpMethod.Put, $"projects/{projectId}/subscriptions/{requestBody.name}", requestBody, cancellationToken)
                .ContinueWith(HandleBaseResponse<JObject>, cancellationToken)
                .Unwrap();

        }

        //DeleteAsync

        //GetAsync

        //GetIamPolicy

        //List

        //ModifyAckDeadline

        /// <summary>
        /// https://cloud.google.com/pubsub/docs/reference/rest/v1/projects.subscriptions/pull
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="maxMessages"></param>
        /// <param name="returnImmediately"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseResponse<PullResponse>> PullAsync(string projectId, string subscriptionId, int maxMessages, bool returnImmediately, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (string.IsNullOrWhiteSpace(subscriptionId)) { throw new ArgumentNullException(nameof(subscriptionId)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/subscriptions/{subscriptionId}:pull", new { maxMessages, returnImmediately }, cancellationToken)
                .ContinueWith(HandleBaseResponse<PullResponse>, cancellationToken)
                .Unwrap();

        }

        //TestIamPermissions

    }
}