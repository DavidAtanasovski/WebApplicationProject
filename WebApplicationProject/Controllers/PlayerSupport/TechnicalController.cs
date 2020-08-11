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
    public class TechnicalController : ControllerBase
    {
        private readonly iPlayerSupport PSData;

        public TechnicalController(iPlayerSupport PSData)
        {
            this.PSData = PSData;
        }

        [HttpGet("technical")]
        public IActionResult GetAll()
        {
            return Ok(Enum.GetNames(typeof(Technical)));
        }

        [HttpGet("{supportId}/technical")]
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