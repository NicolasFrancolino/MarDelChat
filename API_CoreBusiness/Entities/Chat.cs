using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ChatUsuario> usuario { get; set; }

        public ICollection<Mensaje> mensaje { get; set; }
        public  ChatType type { get; set; }

    } 
}
