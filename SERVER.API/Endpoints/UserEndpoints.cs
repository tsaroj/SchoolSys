using Carter;
using Microsoft.AspNetCore.Mvc;
using SERVER.APPLICATION.Services;
using SERVER.CORE.DTOs.Users;
using SERVER.UTIL.Helper;
using SERVER.LOGGING;

namespace SERVER.API.Endpoints
{
    public class UserEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/user/users", GetUser).RequireAuthorization();;
            app.MapGet("/user/{id}", GetUserById);
            app.MapPost("/user/create", CreateUser);
        }
        private async Task<IResult> GetUser([FromServices] IUserServices userServices)
        {
            var response = new JsonResponse
            {
                Result = await userServices.GetAllUsers()
            };
            Logger.Instance.Error("Saroj Guragain This is  my first Error");
        
            return Results.Ok(response.Result);
        }
        
        private async Task<IResult> GetUserById(int id, [FromServices] IUserServices userServices)
        {
            var response = new JsonResponse
            {
                Result = await userServices.GetUserById(id)
            };
            Logger.Instance.Error($"Saroj Guragain This is my first Error {id}");
            return Results.Ok(response.Result);
        }
        
        private async Task<IResult> CreateUser(CreateRequest user, [FromServices] IUserServices userServices)
        {
            var response = new JsonResponse
            {
                Result = await userServices.AddUser(user)
            };
            Logger.Instance.Error("Saroj Guragain This is  my first Error");
        
            return Results.Ok(response.Result);
        }
    }
}
