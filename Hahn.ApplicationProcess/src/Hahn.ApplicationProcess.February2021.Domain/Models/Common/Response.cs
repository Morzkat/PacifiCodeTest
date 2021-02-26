using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Models.Common
{
    public class Result<T>
    {
        public T HttpResponse { get; set; }
        public int StatusCode { get; set; }
    }

    public class Response
    {
        public string Title { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }

    public class ResponseWithList<T> : Response
    {
        public IEnumerable<T> Payload { get; set; }
        public int Total { get; set; }
    }

    public class ResponseWithElement<T> : Response
    {
        public T Payload { get; set; }
    }

    public enum HttpStatusCode
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        Conflict = 409,
        TooEarly = 425,
        InternalServerError = 500,
        BadGateway = 501,
        ServiceUnavailable = 503,
        HTTPVersionNotSupported = 505
    }
}
