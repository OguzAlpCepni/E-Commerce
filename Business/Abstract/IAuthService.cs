using Core.Entites.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResults<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResults<User> Login(UserForLoginDto userForLoginDto);
        IResults UserExists(string email);
        IDataResults<AccessToken> CreateAccessToken(User user);
    }
}
