using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjectCore.PlayerSupport;
using WebProjectData;

namespace WebApplicationProject.Pages.PlayerSupport
{
    public class TechnicalSupportModel : PageModel
    {
        private readonly iPlayerSupport playerSupport;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public WebProjectCore.PlayerSupport.PlayerSupport PlayerSupport { get; set; }
        public IEnumerable<SelectListItem> Technical { get; set; }

        public TechnicalSupportModel(iPlayerSupport playerSupport, IHtmlHelper htmlHelper)
        {
            this.playerSupport = playerSupport;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? PlayerSupportId)
        {
            if (PlayerSupportId.HasValue)
            {
                PlayerSupport = playerSupport.GetPlayerSupportById(PlayerSupportId.Value);
                if (PlayerSupport == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                PlayerSupport = new WebProjectCore.PlayerSupport.PlayerSupport();
            }
            Technical = htmlHelper.GetEnumSelectList<Technical>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (PlayerSupport.Id == 0)
                {
                    PlayerSupport = playerSupport.Create(PlayerSupport);
                    TempData["Message"] = "The Request was sent.";
                }

                playerSupport.Commit();
                return RedirectToPage("./RequestSent");

            }
            Technical = htmlHelper.GetEnumSelectList<Technical>();
            return Page();
        }
    }
}