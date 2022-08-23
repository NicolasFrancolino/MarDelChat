using API_CoreBusiness.Entities;
using API_LoggerCore.CustomLogger;
using API_UsesCases.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MarDelChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IUnitOfWork context;
        private readonly ILogger<ChatController> logger;
        private CustomLogger customLogger { get; set; }

        public ChatController(IUnitOfWork context, ILogger<ChatController> logger)
        {
            this.context = context;
            this.logger = logger;
            customLogger = new CustomLogger(logger);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Chat>> Get()
        {
            customLogger.Info("[Get] Chat");
            var entidadaux = context.ChatRepo.GetAll();
            return Ok(entidadaux);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Chat chat)
        {
            customLogger.Info("[Post] Chat");
            context.ChatRepo.Insert(chat);
            context.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entidadaux = context.ChatRepo.GetById(id);

            customLogger.Info("[Delete] Chat");
            context.ChatRepo.Delete(id);
            context.Save();
            return Ok();
        }
    }

}