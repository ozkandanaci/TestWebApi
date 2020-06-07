
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(TUser user);
        void RevokeRefreshToken(TUser user);

    }
}
