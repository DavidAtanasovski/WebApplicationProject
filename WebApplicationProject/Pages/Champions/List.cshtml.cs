using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProjectCore;
using WebProjectData;

namespace WebApplicationProject
{
    public class ListModel : PageModel
    {
        private readonly IChampData championData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Champion> Champions { get; set; }

        public ListModel(IChampData championData)
        {

            this.championData = championData;
        }

        public void OnGet()
        {
            Champions = championData.GetChampions(SearchTerm);
        }
    }
}