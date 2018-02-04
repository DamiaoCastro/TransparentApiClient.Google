using Newtonsoft.Json.Linq;

namespace TransparentApiClient.Google.BigQuery.V2.Tabledata {
    public class ListResponse {
        public string kind { get; set; }
        public string etag { get; set; }
        public string totalRows { get; set; }
        public string pageToken { get; set; }
        public JObject[] rows { get; set; }
    }
}