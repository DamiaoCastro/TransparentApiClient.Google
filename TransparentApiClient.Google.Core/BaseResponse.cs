using System.Net;

namespace TransparentApiClient.Google.Core {

    public class BaseResponse<S> {

        public BaseResponse() { }

        public BaseResponse(bool success, S response, HttpStatusCode responseCode, ErrorResponse error, string errorText) {
            Success = success;
            Response = response;
            ResponseCode = responseCode;
            Error = error;
            ErrorText = errorText;
        }

        public bool Success { get; internal set; }

        public S Response { get; internal set; }

        public HttpStatusCode ResponseCode { get; internal set; }

        public ErrorResponse Error { get; internal set; }

        public string ErrorText { get; internal set; }

    }
}
