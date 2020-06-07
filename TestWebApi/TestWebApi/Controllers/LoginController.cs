using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Resource;
using Security;
using Services.Login;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthenticationService authenticationService;


        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(TLoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState.GetErrorMessages());
                return BadRequest("InvalidResource");
            }
            else
            {
                Response<AccessToken> accessTokenResponse = authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);
                return Ok(accessTokenResponse);
            }

        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            Response<AccessToken> accessTokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);
            return Ok(accessTokenResponse.Result);
        }

        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenResource tokenResource)
        {
            Response<AccessToken> accessTokenResponse = authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);
            return Ok(accessTokenResponse.Result);
        }


    }
}