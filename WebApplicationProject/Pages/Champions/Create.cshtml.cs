using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using WebProjectCore;
using WebProjectData;

namespace WebApplicationProject.Pages.Champions
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IChampData champData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Champion Champion { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public IFormFile Gif { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public CreateModel(IChampData champData, IHtmlHelper htmlHelper, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
            this.champData = champData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int? championId)
        {
            if (championId.HasValue)
            {
                Champion = champData.GetChampionById(championId.Value);
                if (Champion == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Champion = new Champion();
            }
            Roles = htmlHelper.GetEnumSelectList<Role>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Champion.Id == 0 && Photo != null && Gif != null)
                {                    

                   
                    Champion.LinkUrl = ProcessUploadedFile();
                    Champion.VideoUrl = ProcessUploadedVideo();
                    
                    Champion = champData.Create(Champion);
                    TempData["Message"] = "The Champion is created.";
                }
              
                champData.Commit();
                return RedirectToPage("./List", new { championId = Champion.Id });
                
            }
            Roles = htmlHelper.GetEnumSelectList<Role>();
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Photos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

        private string ProcessUploadedVideo()
        {
            string uniqueFileName = null;
            if (Gif != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Videos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Gif.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Gif.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }






    }
}