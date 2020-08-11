using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebProjectCore
{
   public class Champion
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Overview { get; set; }
        [Required, Display(Name = "Ultimate Name")]
        public string UltimateName { get; set; }
        [Required, Display(Name = "Ultimate Description")]
        public string UltimateDesc { get; set; }
        [Required, Display(Name="Champion Role")]
        public Role Role { get; set; }
        [Display(Name= "Champion Photo")]
        public string LinkUrl { get; set; }
        [Display(Name = "Champion Ultimate Video")]       
        public string VideoUrl { get; set; }
       
    }
}
