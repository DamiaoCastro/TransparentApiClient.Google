using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TransparentApiClient.Google.BigQuery.V2 {
    public class BaseResponse<S> {

        public bool Success { get; set; }

        public S Response { get; set; }

        public HttpStatusCode ResponseCode { get; set; }

    }
}
