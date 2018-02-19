namespace TransparentApiClient.Google.Core
{
    public class ErrorResponse
    {
        public Error[] errors { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Error
    {
        public string domain { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
    }

}