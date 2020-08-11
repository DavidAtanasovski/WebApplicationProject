using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebProjectCore.PlayerSupport
{
    public class PlayerSupport
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, Display(Name = "Account issue")]

        public Account Account { get; set; }
        [Required, Display(Name = "In Game issue")]
        public InGame InGame { get; set; }
        [Required, Display(Name = "Technical issue")]
        public Technical Technical { get; set; }
    }
}
