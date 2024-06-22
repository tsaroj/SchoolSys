using Microsoft.AspNetCore.Mvc;

namespace SERVER.API.Controllers;

[Route("api/[controller]")]
//[TypeFilter(typeof(AuthorizationFilterAttribute))]
[ApiController]
public class BaseApiController : ControllerBase
{

}