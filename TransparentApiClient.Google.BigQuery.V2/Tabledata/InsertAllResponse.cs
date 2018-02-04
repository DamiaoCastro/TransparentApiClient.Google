namespace TransparentApiClient.Google.BigQuery.V2.Tabledata {
    public class InsertAllResponse {
        public string kind { get; set; }
        public Inserterror[] insertErrors { get; set; }
        
        public class Inserterror {
            public int index { get; set; }
            public Error[] errors { get; set; }
        }

        public class Error {
            public string reason { get; set; }
            public string location { get; set; }
            public string debugInfo { get; set; }
            public string message { get; set; }
        }

    }
}