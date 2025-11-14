using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using super_hero_api.Data;
using super_hero_api.Entities;

namespace super_hero_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperzHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperzHeroController(DataContext context)
        {
            _context = context;
        }

        public SuperzHeroController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync();
            if (hero is null)
                return BadRequest("Hero not fund ");

            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync();
            if (hero is null)
                return BadRequest("Hero not fund ");

            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedhero)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(updatedhero.Id);
            if (dbhero is null)
                return BadRequest("Hero not fund ");

            dbhero.Name = updatedhero.Name;
            dbhero.FirstName = updatedhero.FirstName;
            dbhero.LastName = updatedhero.LastName;
            dbhero.Place = updatedhero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}