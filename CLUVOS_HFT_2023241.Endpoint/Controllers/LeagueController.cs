using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CLUVOS_HFT_2023241.Logic;
using CLUVOS_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CLUVOS_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        ILeagueLogic logic;

        public LeagueController(ILeagueLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<League> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public League Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] League value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] League value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }   
}
