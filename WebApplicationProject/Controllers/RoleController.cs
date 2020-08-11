using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectCore;
using WebProjectData;

namespace WebApplicationProject.Controllers
{
    [Route("api/Champions")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IChampData champData;

        public RoleController (IChampData champData)
        {
            this.champData = champData;
        }

        [HttpGet("role")]
        public IActionResult GetAll()
        {
            return Ok(Enum.GetNames(typeof(Role)));
        }

        [HttpGet("{championId}/role")]
        public IActionResult GetByChampionId(int championId)
        {
            var champ = champData.GetChampionById(championId);
            if (champ == null)
            {
                return NotFound();
            }
            return Ok(champ.Role.ToString());
        }
    }
}