namespace TransparentApiClient.Google.PubSub.V1.Subscriptions {
    public class CreateRequest {
        public int ackDeadlineSeconds { get; set; }
        public string messageRetentionDuration { get; set; }
        public string name { get; set; }
        public Pushconfig pushConfig { get; set; }
        public bool retainAckedMessages { get; set; }
        public string topic { get; set; }

        public class Pushconfig {
            //public Attributes attributes { get; set; }
            public string pushEndpoint { get; set; }
        }
    }

}