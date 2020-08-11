using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectCore.PlayerSupport;
using WebProjectData;

namespace WebApplicationProject.Controllers.PlayerSupport
{
    [Route("api/PlayerSupports")]
    [ApiController]
    public class InGameController : ControllerBase
    {
        private readonly iPlayerSupport PSData;

        public InGameController(iPlayerSupport PSData)
        {
            this.PSData = PSData;
        }

        [HttpGet("ingame")]
        public IActionResult GetAll()
        {
            return Ok(Enum.GetNames(typeof(InGame)));
        }

        [HttpGet("{supportId}/ingame")]
        public IActionResult GetPlayerSupportById(int supportId)
        {
            var acc = PSData.GetPlayerSupportById(supportId);
            if (acc == null)
            {
                return NotFound();
            }
            return Ok(acc.Account.ToString());
        }
    }
}