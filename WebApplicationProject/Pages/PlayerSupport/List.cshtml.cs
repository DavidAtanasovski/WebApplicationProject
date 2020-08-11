using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProjectCore.PlayerSupport;
using WebProjectData;

namespace WebApplicationProject.Pages.PlayerSupport
{
    public class ListModel : PageModel
    {
        private readonly iPlayerSupport playersupportData;

        public IEnumerable<WebProjectCore.PlayerSupport.PlayerSupport> playerSupports { get; set; }

        public ListModel(iPlayerSupport playersupportData)
        {

            this.playersupportData = playersupportData;
        }

        public void OnGet()
        {
           playerSupports = playersupportData.GetPlayerSupports();
        }
    }
}