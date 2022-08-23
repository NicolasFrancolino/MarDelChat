using API_CoreBusiness.Authentication.Request;
using API_CoreBusiness.Authentication.Response;
using API_CoreBusiness.Entities;
using API_UsesCases.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_UsesCases.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uOW;
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uOW = uow;
            _configuration = configuration;
        }

        public UserResponse Login(string email, string password)
        {
            if (_uOW.UsuarioRepo.ExisteUsuario(email))
            {
                UserResponse response = new UserResponse();
                //traigo el usuario, por el email
                Usuario user = _uOW.UsuarioRepo.GetByEmail(email);
                //verifico si el password ingresado es el mismo del usuario en la DB
                if (!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
                //aca deberia mappear a un UserResponse
                response.Email = email;
                response.Nombre = user.Nombre;
                response.FechaAlta = user.FechaAlta;
                response.Id = user.Id;
                //response.Role = user.Role;
                //Devuelvo la respuesta si esta todo bien
                return response;
            }
            return null;
        }
        private bool VerificarPassword(string pass, byte[] pHash, byte[] pSalt)
        {
            //hago una encriptacion con la key (psalt)
            var hMac = new HMACSHA512(pSalt);
            var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            //comparo el pass de la DB con el que acabo de encriptar
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != pHash[i]) return false;
            }

            return true;
        }
        public UserResponse Registrar(UserRequest user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CrearPassHash(password, out passwordHash, out passwordSalt);
            Usuario usuario = new Usuario();
            usuario.Nombre = user.Nombre;
            usuario.Email = user.Email;
            usuario.FechaAlta = DateTime.Now;
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            //usuario.Role = Role.User;
            _uOW.UsuarioRepo.Insert(usuario);
            _uOW.Save();
            UserResponse response = new UserResponse();
            response.Email = usuario.Email;
            response.Nombre = usuario.Nombre;
            response.FechaAlta = usuario.FechaAlta;
            response.Id = usuario.Id;
            //response.Role = usuario.Role;
            return response;
        }
        private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //creo una encriptacion
            var hMac = new HMACSHA512();
            //le asigno la llave de la encriptacion al passwordSalt
            passwordSalt = hMac.Key;
            //Encripto el pass y lo guardo en passwordHash
            passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));


        }

        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials

            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}