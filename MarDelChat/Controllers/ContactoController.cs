using API_LoggerCore.CustomLogger;
using API_UsesCases.UnitOfWork;
using API_CoreBusiness.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_UsesCases.Services;
using API_CoreBusiness.Authentication.Response;
using API_CoreBusiness.Authentication.Request;

namespace MarDelChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IUnitOfWork context;
        private readonly ILogger<ContactoController> logger;


        private CustomLogger customLogger { get; set; }

        public ContactoController(IUnitOfWork context, ILogger<ContactoController> logger)
        {
            this.context = context;
            this.logger = logger;
            customLogger = new CustomLogger(logger);           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contactos>> Get(UserResponse user)
        {
            customLogger.Info("FROM CONTACTO");

            var aux = context.UsuarioRepo.GetByEmail(user.Email);

            List<Contactos> listaContactos = aux.contactos.ToList();

            return Ok(listaContactos);

            //var contacto = context.ContactoRepo.GetAll();
            //return Ok(contacto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserResponse user)
        {
            
            if (context.UsuarioRepo.ExisteNombre(user.Nombre))
            {

                customLogger.Info("FROM CONTACTO");
                Contactos contacto = new Contactos();
                contacto.Usuario = user;
                context.ContactoRepo.Insert(contacto);
                context.Save();
                return Ok();
            }
            
            return BadRequest();
            //ContactoResponse res = contactoService.Registrar(contacto);
            //return Ok(res);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Contactos contacto, int id)
        {
            customLogger.Info("FROM CONTANCTO");
            context.ContactoRepo.Update(contacto, id);
            context.Save();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            customLogger.Info("FROM CONTACTO");
            context.ContactoRepo.Delete(id);
            context.Save();
            return Ok();
        }
    }
}