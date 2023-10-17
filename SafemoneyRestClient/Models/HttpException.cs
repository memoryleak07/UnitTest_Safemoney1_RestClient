using System;

namespace SafemoneyRestClient.Models
{
    public class HttpException : Exception
    {
        public BadResponse BadResponse { get; set; }
        public HttpException() { }

        public HttpException(BadResponse badResponse) : base(badResponse.ToString())
        {
            BadResponse = badResponse;
        }
    }
}
