using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models;
using WebProjectCore;
using WebProjectData;

namespace WebApplicationProject.Controllers
{
    [Route("api/Champions")]
    [ApiController]
    public class ChampionApiController : ControllerBase
    {
        private readonly IChampData champData;
        public ChampionApiController(IChampData champData)
        {
            this.champData = champData;
        }

        [HttpGet]
        public IActionResult GetChampionsAll()
        {
            var data = champData.GetChampions();
            return Ok(data);
        }

        [HttpGet("{id}", Name ="GetChampion")]
        public IActionResult GetChampion(int id)
        {
            var data = champData.GetChampionById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(ChampionDto championCreateDto)
        {
            if(championCreateDto == null)
            {
                return BadRequest();
            }

            var champion = new Champion();
            champion.Role = (Role)championCreateDto.Role;
            champion.Name = championCreateDto.Name;
            champion.Overview = championCreateDto.Overview;
            champion.UltimateDesc = championCreateDto.UltimateDesc;
            champion.UltimateName = championCreateDto.UltimateName;
            champion.LinkUrl = championCreateDto.LinkUrl;
            champion.VideoUrl = championCreateDto.VideoUrl;

            champData.Create(champion);
            champData.Commit();

            return CreatedAtRoute("GetChampion", new { id = champion.Id }, champion);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = champData.Delete(id);
            if(temp == null)
            {
                return BadRequest();
            }
            champData.Commit();
            return NoContent();
        }
    }
}