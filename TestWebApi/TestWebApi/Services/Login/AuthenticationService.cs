
using Security;
using System;
using System.Collections.Generic;
using System.Text;
using TestWebApi.Models;

namespace Services.Login
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public Response<AccessToken> CreateAccessToken(string email, string password)
        {
            Response<TUser> userResponse = userService.FindByEMailAndPassword(email, password);
            if(userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Result);

                userService.SaveRefreshToken(userResponse.Result.Id, accessToken.RefreshToken);

                return new Response<AccessToken>(accessToken);
            }
            else
            {
                return new Response<AccessToken>(userResponse.Message);
            }



        }

        public Response<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            Response<TUser> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                if(userResponse.Result.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Result);

                    userService.SaveRefreshToken(userResponse.Result.Id, accessToken.RefreshToken);

                    return new Response<AccessToken>(accessToken);
                }
                else
                {
                    return new Response<AccessToken>("RefreshTokenTimeout");
                }
            }
            else
            {
                return new Response<AccessToken>("InvalidRefreshToken");
            }
        }

        public Response<AccessToken> RevokeRefreshToken(string refreshToken)
        {
            Response<TUser> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if(userResponse.Success)
            {
                userResponse = userService.RemoveRefreshToken(userResponse.Result);
                return new Response<AccessToken>(new AccessToken());
            }
            else
            {
                return new Response<AccessToken>("InvalidRefreshToken");
            }
        }
    }
}
