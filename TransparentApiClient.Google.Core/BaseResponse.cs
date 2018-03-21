using System.Net;

namespace TransparentApiClient.Google.Core {

    public class BaseResponse<S> {

        public bool Success { get; internal set; }

        public S Response { get; internal set; }

        public HttpStatusCode ResponseCode { get; internal set; }

        public ErrorResponse Error { get; internal set; }

        public string ErrorText { get; internal set; }

    }
}
