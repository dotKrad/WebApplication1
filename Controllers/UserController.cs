using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Payloads;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SampleDBContext _sampleDBContext;
    private readonly JwtService _jwtService;

    public UserController(UserManager<IdentityUser> userManager, SampleDBContext sampleDBContext, JwtService jwtService)
    {
      _userManager = userManager;
      _sampleDBContext = sampleDBContext;
      _jwtService = jwtService;
    }

    [HttpGet]
    public IEnumerable<IdentityUser> Get()
    {
      return _sampleDBContext.Users.ToArray();
    }

    [HttpPost("signin")]
    public async Task<ActionResult<AuthenticationResponse>> Signin(AuthenticationRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Bad credentials");
      }

      var user = await _userManager.FindByNameAsync(request.UserName);

      if (user == null)
      {
        return BadRequest("Bad credentials");
      }

      var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

      /*
      if (!isPasswordValid)
      {
          return BadRequest("Bad credentials");
      }
      */

      var token = _jwtService.CreateToken(user);

      return Ok(token);
    }
  }
}
