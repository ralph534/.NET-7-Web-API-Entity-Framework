using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHerosApi.Models;


namespace SuperHerosApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class SuperHeroController : ControllerBase
	{
		private static List<SuperHero> superHeroes = new List<SuperHero> {
			new SuperHero
			{
				Id = 1,
				Name = "Spider-man",
				FirstName= "Peter",
				LastName= "Parker",
				Place = "New York City"

			},
            new SuperHero
            {
                Id = 2,
                Name = "Iron-man",
                FirstName= "Tony",
                LastName= "Starks",
                Place = "Malibu"

            }
        };


		[HttpGet]

		public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
		{
			return Ok(superHeroes);
		}


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
			var hero = superHeroes.Find(x => x.Id == id);
			if (hero is null)
				return NotFound("Sorry, but hero doesnt exist.");		
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Sorry, but hero doesnt exist.");

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }
    }
}

