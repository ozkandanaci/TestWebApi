
using Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using TestWebApi.Models;

namespace Services.Login
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            //unitofwork yani transactional yürütme bu katmanda olacak
        }

        public Response<TUser> AddUser(TUser user)
        {
            try
            {
                userRepository.AddUser(user);
                return new Response<TUser>(user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        public Response<TUser> FindByEMailAndPassword(string email, string password)
        {
            try
            {
                TUser user = userRepository.FindByEMailAndPassword(email, password);
                return new Response<TUser>(user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        public Response<TUser> FindById(int user_id)
        {
            try
            {
                TUser user = userRepository.FindById(user_id);

                return new Response<TUser>(user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        public Response<TUser> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                TUser user = userRepository.GetUserWithRefreshToken(refreshToken);
                return new Response<TUser>(user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        public Response<TUser> RemoveRefreshToken(TUser user)
        {
            try
            {
                TUser db_user = userRepository.FindById(user.Id);
                db_user.RefreshToken = null;
                //save to db

                return new Response<TUser>(db_user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        public Response<TUser> SaveRefreshToken(int user_id, string refreshToken)
        {
            try
            {
                TUser user = userRepository.FindById(user_id);
                user.RefreshToken = refreshToken;
                //save to db

                return new Response<TUser>(user) { Success = true };
            }
            catch (Exception e)
            {
                return new Response<TUser>(e.Message);
            }
        }

        
    }
}
