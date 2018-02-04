using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Tabledata {

    public class InsertAllRequest {
        public string kind { get { return "bigquery#tableDataInsertAllRequest"; } }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? skipInvalidRows { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ignoreUnknownValues { get; set; }

        public string templateSuffix { get; set; }
        public Row[] rows { get; set; }

        public class Row {
            public string insertId { get; set; }
            public object json { get; set; }
        }

    }

}