using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUK2AC_HFT_2022231.Logic;
using DUK2AC_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DUK2AC_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        IAchievementLogic logic;

        public AchievementController(IAchievementLogic logic )
        {
            this.logic = logic;
        }

        // GET: api/<AchievementController>
        [HttpGet]
        public IEnumerable<Achievement> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<AchievementController>/5
        [HttpGet("{id}")]
        public Achievement Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<AchievementController>
        [HttpPost]
        public void Create([FromBody] Achievement value)
        {
            logic.Create(value);
        }

        // PUT api/<AchievementController>/5
        [HttpPut]
        public void Update( [FromBody] Achievement value)
        {
            logic.Update(value);
        }

        // DELETE api/<AchievementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
