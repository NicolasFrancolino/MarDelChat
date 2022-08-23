using API_CoreBusiness.Authentication.Request;
using API_CoreBusiness.Authentication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_UsesCases.Services
{
    public interface IUserService
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
    }
}
