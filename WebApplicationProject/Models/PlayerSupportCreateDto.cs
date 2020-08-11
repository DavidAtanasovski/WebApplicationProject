using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProjectCore.PlayerSupport;

namespace WebApplicationProject.Models
{
    public class PlayerSupportDto
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]

        public Account Account { get; set; }
        [Required]
        public InGame InGame { get; set; }
        [Required]
        public Technical Technical { get; set; }
    }
}
