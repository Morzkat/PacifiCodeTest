using KHahn.ApplicationProcess.February2021.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Helpers
{
    public static class ResponseHelper
    {
        public static ResponseWithElement<T> NewResponseWithElement<T>(T payload = default(T), string title = "", Dictionary<string, List<string>> errors = null)
        {
            return new ResponseWithElement<T>
            {
                Title = title,
                Errors = errors,
                Payload = payload,
            };
        }

        public static ResponseWithList<T> NewResponseWithList<T>(IEnumerable<T> payload = default(IEnumerable<T>), string title = "", Dictionary<string, List<string>> errors = null)
        {
            return new ResponseWithList<T>
            {
                Title = title,
                Errors = errors,
                Payload = payload,
                Total = payload.Count()
            };
        }

        public static Result<T> NewResult<T>(HttpStatusCode statusCode, T httpResponse)
        {
            return new Result<T>
            {
                StatusCode = (int)statusCode,
                HttpResponse = httpResponse
            };
        }
    }
}