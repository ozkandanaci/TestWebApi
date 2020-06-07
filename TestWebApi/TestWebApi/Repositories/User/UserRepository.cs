using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Security;
using TestWebApi.Models;

namespace Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly TokenOptions tokenOptions;
        public UserRepository(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
           
        }
        public void AddUser(TUser user)
        {
            //..
        }

        public void UpdateUser(TUser user)
        {

        }

        public void DeleteUser(int id)
        {

        }

        
       

  

        public void RemoveRefreshToken(int user_id)
        {
            TUser user = this.FindById(user_id);
            user.RefreshToken = null;
            user.RefreshTokenEndDate = null;
            //save
            //refreshtoken = null
        }
        public TUser FindByEMailAndPassword(string email, string password)
        {
            return new TUser()
            {
                Id = 1,
                Email = "ozkandanaci@gmail.com",
                Name = "Özkan",
                SurName = "Danacı"
            };
        }
        public void SaveRefreshToken(int user_id, string refreshToken)
        {
            TUser user = FindById(user_id);
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = DateTime.Now.AddDays(tokenOptions.RefreshTokenExpiration);
            //save to db
        }
        public TUser FindById(int id)
        {
            return new TUser()
            {
                Id = 1,
                Email = "ozkandanaci@gmail.com",
                Name = "Özkan",
                SurName = "Danacı"
            };
        }
        public TUser GetUserWithRefreshToken(string refreshToken)
        {
            return new TUser()
            {
                Id = 1,
                Email = "ozkandanaci@gmail.com",
                Name = "Özkan",
                SurName = "Danacı"
            };
        }
        public void RevokeRefreshToken(TUser user)
        {
            //kullanıcı çıkış yaptığı zaman
            TUser dbuser = FindById(user.Id);
            dbuser.RefreshToken = null;
            dbuser.RefreshTokenEndDate = null;
            //save to db
        }

       
    }
}
