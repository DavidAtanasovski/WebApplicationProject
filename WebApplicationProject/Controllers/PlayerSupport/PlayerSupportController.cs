using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models;
using WebProjectCore.PlayerSupport;
using WebProjectData;
using WebProjectCore;

namespace WebApplicationProject.Controllers
{
    [Route("api/PlayerSupports")]
    [ApiController]
    public class PlayerSupportController : ControllerBase
    {
        private readonly iPlayerSupport PSData;

        public PlayerSupportController(iPlayerSupport PSData)
        {
            this.PSData = PSData;
        }

        [HttpGet("{id}", Name = "GetPlayerSupport")]
        public IActionResult GetPlayerSupport(int id)
        {
            var data = PSData.GetPlayerSupportById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetChampionsAll()
        {
            var data = PSData.GetPlayerSupports();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(PlayerSupportDto playerSupportDto)
        {
            if (playerSupportDto == null)
            {
                return BadRequest();
            }

            var playersupport = new WebProjectCore.PlayerSupport.PlayerSupport();

            playersupport.InGame = (InGame)playerSupportDto.InGame;
            playersupport.Technical = (Technical)playerSupportDto.Technical;
            playersupport.Account = (Account)playerSupportDto.Account;
            playersupport.Description = playerSupportDto.Description;
            playersupport.Username = playerSupportDto.Username;
            playersupport.Subject = playerSupportDto.Subject;

           

            PSData.Create(playersupport);
            PSData.Commit();

            return CreatedAtRoute("GetPlayerSupport", new { id = playersupport.Id }, playersupport );
        }
    }
}