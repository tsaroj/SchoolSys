using Microsoft.AspNetCore.Mvc;
using SERVER.UTIL.Helper;
using System.Net;

namespace SERVER.API
{
    public static class ApiResponse
    {
        public static ActionResult GO()
        {
            return new OkResult();
        }

        public static ActionResult GO(JsonResponse response)
        {
            int status = (int)HttpStatusCode.OK;

            if (!response.IsSuccess)
            {
                // status = (int)HttpStatusCode.InternalServerError;
            }
            else if (response.Result == null)
            {
                status = (int)HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = status
            };
        }

        public static ActionResult NotFound(JsonResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        public static ActionResult InvalidInput(JsonResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.UnprocessableEntity
            };
        }

        public static ActionResult DuplicateEntry(JsonResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.Conflict
            };
        }
    }
}
