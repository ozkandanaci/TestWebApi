
using System;
using System.Collections.Generic;
using System.Text;
using TestWebApi.Models;

namespace Services.Login
{
    public interface IUserService
    {
        Response<TUser> AddUser(TUser user);
        Response<TUser> FindById(int user_id);
        Response<TUser> FindByEMailAndPassword(string email, string password);
        Response<TUser> SaveRefreshToken(int user_id, string refreshToken);
        Response<TUser> RemoveRefreshToken(TUser user);
        Response<TUser> GetUserWithRefreshToken(string refreshToken);
    }
}
