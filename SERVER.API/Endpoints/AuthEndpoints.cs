using Carter;
using Microsoft.AspNetCore.Mvc;
using SERVER.APPLICATION.Interface;
using SERVER.LOGGING;
using SERVER.UTIL.Helper;

namespace SERVER.API.Endpoints
{
    public class AuthEndpoints:CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Admin/login", Authentication);
        }

          private async Task<IResult> Authentication([FromServices] IAuthServices authServices,Login login)
        {
            var response = new JsonResponse
            {
                Result = await authServices.Authentication(login)
            };
            Logger.Instance.Error("Saroj Guragain This is  my first Error");

            return Results.Ok(response.Result);
        }
    }
}