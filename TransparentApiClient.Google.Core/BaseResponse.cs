using System.Net;

namespace TransparentApiClient.Google.Core {
    public class BaseResponse<S> {

        public bool Success { get; set; }

        public S Response { get; set; }

        public HttpStatusCode ResponseCode { get; set; }

    }
}
