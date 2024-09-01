using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Security.JWT;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(LoginDTO userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
