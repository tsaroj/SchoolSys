using Carter;
using Microsoft.AspNetCore.Mvc;
using SERVER.APPLICATION.Services;
using SERVER.UTIL.Helper;
using SERVER.LOGGING;

namespace SERVER.API.Endpoints
{
    public class UserEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/user/Users", GetUser);
            app.MapGet("/user/{id}", GetUserById);
            // app.MapPost("/user/create", CreateUser);
        }

        private async Task<IResult> GetUser([FromServices] IUserServices userServices)
        {
            var response = new JsonResponse
            {
                Result = await userServices.GetAllUsers()
            };
            Logger.Instance.Error("Saroj Guragain This is  my first Error");

            return Results.Ok(ApiResponse.GO(response));
        }

        private async Task<IResult> GetUserById(int id, [FromServices] IUserServices userServices)
        {
            var response = new JsonResponse
            {
                Result = await userServices.GetUserById(id)
            };
            Logger.Instance.Error($"Saroj Guragain This is my first Error {id}");
            return Results.Ok(ApiResponse.GO(response));
        }

        // private async Task<IResult> CreateUser(User user, [FromServices] IUserServices userServices)
        // {
        //     int users = await userServices.AddUser(user);
        //     return Results.Ok(users);
        // }
    }
}
