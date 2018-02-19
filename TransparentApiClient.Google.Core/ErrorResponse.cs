namespace TransparentApiClient.Google.Core
{
    public class ErrorResponse
    {
        public Error1[] errors { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Error1
    {
        public string domain { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
    }

}