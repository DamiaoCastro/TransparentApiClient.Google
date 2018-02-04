using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.PubSub.V1.TopicsSubscriptions {
    public class TopicsSubscriptionsClient : BaseClient {

        public TopicsSubscriptionsClient(byte[] serviceAccountCredentials) :
            base(serviceAccountCredentials, "https://pubsub.googleapis.com/v1/", new string[] { "https://www.googleapis.com/auth/pubsub" }) {
        }

        //ListAsync

    }
}