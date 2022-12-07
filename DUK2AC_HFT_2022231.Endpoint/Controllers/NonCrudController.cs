using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DUK2AC_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        IGameLogic gl;
        IDeveloperLogic dl;
        IAchievementLogic al;

        public NonCrudController(IGameLogic gl, IDeveloperLogic dl, IAchievementLogic al)
        {
            this.gl = gl;
            this.dl = dl;
            this.al = al;
        }

        
        [HttpGet]
        public IEnumerable<KeyValuePair<string,int>> GameWithTheMostAchievementPoints()
        {
            return al.GetGameWithTheMostAchievementPoints();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetAchievementsByGenre()
        {
            return al.GetAchievementsByGenre();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> DevsWithMostGamesMade()
        {
            return gl.DevsWithMostGamesMade();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> DevsWithCheapestGamesMade()
        {
            return gl.DevsWithCheapestGamesMade();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> GamesCountByOldestDev()
        {
            return gl.GamesCountByOldestDev();
        }


    }
}
