using API_CoreBusiness.Authentication.Request;
using API_CoreBusiness.Authentication.Response;
using API_UsesCases.Services;
using API_UsesCases.UnitOfWork;
using API_Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarDelChat.Controllers
{
    [Tags("LOGIN")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService usuarioService;

        public LoginController(IUnitOfWork unitOfWork, IUserService usuarioService )
        {
            this.unitOfWork = unitOfWork;
            this.usuarioService = usuarioService;
        }
        /// <summary>
        /// Loguear Usuario
        /// </summary>
        /// <param name="req"></param>
        /// <response code="200">Se logueo correctamente</response>
        /// <response code="404">No has podido loguearte correctamente</response>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = usuarioService.Login(req.Email, req.Password);
            if (response == null)
            {
                return Unauthorized();
            }
             var token = usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response

            });
        }

        /// <summary>
        /// Registrar Usuario
        /// </summary>
        /// <param name="req"></param>
        /// <response code="200">Se registro correctamente</response>
        /// <response code="404">No has podido registrarte correctamente</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Registro")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult RegistrarUsuario([FromBody] UserRequest user)
        {
            if (unitOfWork.UsuarioRepo.ExisteUsuario(user.Email.ToLower()))
            {
                return BadRequest("Cuenta ya esxiste");
            }
            UserResponse res = usuarioService.Registrar(user, user.Password);
            return Ok(res);
        }
    }
}
