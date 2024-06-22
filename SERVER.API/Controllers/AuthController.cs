using Microsoft.AspNetCore.Mvc;
using SERVER.APPLICATION.Interface;
using SERVER.LOGGING;
using SERVER.UTIL.Helper;

namespace SERVER.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseApiController
{
    private readonly IAuthServices _authServices;

    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IResult> Authentication(Login request)
    {
        JsonResponse response = new()
        {
            Result = await _authServices.Authentication(request)
        };
        Logger.Instance.Info("User Login Successfully");
        return Results.Ok(response.Result);
    }
}