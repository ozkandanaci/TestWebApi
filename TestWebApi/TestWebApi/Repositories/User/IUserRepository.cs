
using System;
using System.Collections.Generic;
using System.Text;
using TestWebApi.Models;

namespace Repository.User
{
    public interface IUserRepository
    {
        void AddUser(TUser user);
        TUser FindById(int id);
        TUser FindByEMailAndPassword (string email, string password);
        void SaveRefreshToken(int user_id, string refreshToken);
        TUser GetUserWithRefreshToken(string refreshToken);
        void RevokeRefreshToken(TUser user);
    }
}
