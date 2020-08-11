using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProjectCore;
using WebProjectData;

namespace WebApplicationProject.Pages.Champions
{
    public class DetailModel : PageModel
    {
        private readonly IChampData champData;
        public Champion Champion { get; set; }
        public DetailModel(IChampData champData)
        {
            this.champData = champData;
        }

        public IActionResult OnGet(int championId)
        {
            Champion = champData.GetChampionById(championId);
            if(Champion == null)
            {
                return RedirectToPage(".NotFound");
            }
            return Page();
        }
    }
}