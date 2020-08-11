using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProjectData;

namespace WebApplicationProject.Pages.PlayerSupport
{
    public class DetailModel : PageModel
    {
        private readonly iPlayerSupport playerData;
        public WebProjectCore.PlayerSupport.PlayerSupport PlayerSupport { get; set; }
        public DetailModel(iPlayerSupport playerData)
        {
            this.playerData = playerData;
        }

        public IActionResult OnGet(int playersupportId)
        {
            PlayerSupport = playerData.GetPlayerSupportById(playersupportId);
            if (PlayerSupport == null)
            {
                return RedirectToPage(".NotFound");
            }
            return Page();
        }
    }
}