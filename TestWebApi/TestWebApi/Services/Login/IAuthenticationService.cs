
using Security;
using System;
using System.Collections.Generic;
using System.Text;
using TestWebApi.Models;

namespace Services.Login
{
    public interface IAuthenticationService
    {
        Response<AccessToken> CreateAccessToken(string email, string password);
        Response<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);
        Response<AccessToken> RevokeRefreshToken(string refreshToken);




    }
}
