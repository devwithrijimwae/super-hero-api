using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using super_hero_api.Entities;

namespace super_hero_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperzHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heroes = new List<SuperHero> {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };
            return Ok(heroes);
        }
    }
}
