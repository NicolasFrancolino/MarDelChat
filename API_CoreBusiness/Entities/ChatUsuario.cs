﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Entities
{
    public class ChatUsuario
    {
        [Key]
        public int Id { get; set; }
        public Usuario? Usuario { get; set; }
        public int ChatId { get; set; }
        public Role Role { get; set; }
    }
}
