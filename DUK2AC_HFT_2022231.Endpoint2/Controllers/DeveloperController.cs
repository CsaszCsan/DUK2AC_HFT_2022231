using DUK2AC_HFT_2022231.Logic;
using DUK2AC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DUK2AC_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        IDeveloperLogic logic;

        public DeveloperController(IDeveloperLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<DeveloperController>
        [HttpGet]
        public IEnumerable<Developer> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public Developer Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public void Create([FromBody] Developer value)
        {
            logic.Create(value);
        }

        // PUT api/<DeveloperController>/5
        [HttpPut]
        public void Update( [FromBody] Developer value)
        {
            logic.Update(value);
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
