using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVER.APPLICATION.Services;
using SERVER.CORE.DTOs.Users;
using SERVER.LOGGING;
using SERVER.UTIL.Helper;

namespace SERVER.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseApiController
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }
    [HttpGet]
    [Route("users")]
    [Authorize]
    public async Task<IResult> Users()
    {
        JsonResponse response = new ()
        {
            Result = await _userServices.GetAllUsers()
        };
        Logger.Instance.Info("Successfully fetched result");
        return Results.Ok(response.Result);
    }
    
    [HttpGet]
    [Route("user/{id}")]
    public async Task<IResult> UsersById(int id)
    {
        JsonResponse response = new()
        {
            Result = await _userServices.GetUserById(id)
        };
        Logger.Instance.Info("Successfully fetched result");
        return Results.Ok(response.Result);
    }
    
    [HttpPost]
    [Route("user/create")]
    public async Task<IResult> CreateUsers(CreateRequest request)
    {
        JsonResponse response = new()
        {
            Result = await _userServices.AddUser(request)
        };
        Logger.Instance.Info("Successfully Created Users");
        return Results.Ok(response.Result);
    }
    
}