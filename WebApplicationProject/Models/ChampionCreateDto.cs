using System.ComponentModel.DataAnnotations;
using WebProjectCore;


namespace WebApplicationProject.Models
{
    public class ChampionDto
    {
        public string Name { get; set; }
        [Required]
        public string Overview { get; set; }
        [Required]
        public string UltimateName { get; set; }
        [Required]
        public string UltimateDesc { get; set; }
        [Required]
        public Role Role { get; set; }
       
        public string LinkUrl { get; set; }
   
       
        public string VideoUrl { get; set; }
    }
}
