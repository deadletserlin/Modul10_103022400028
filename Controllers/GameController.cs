
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modul10_103022400028;

namespace odul10_103022400028.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // daftar game statis
        public static List<Game> game = new List<Game>
        {
            new Game
            {
                id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5,
                Platform = new string[] {"PC"}, Mode = new string[] { "Multiplayer" }, IsOnline = true, Harga = 0 }
            , new Game
            {
                id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5,
                Platform = new string[] {"PC", "PS4", "PS5", "Xbox"}, Mode = new string[] { "Singleplayer","Multiplayer" }, IsOnline = true, Harga = 300000 }
            , new Game
            {
                id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7,
                Platform = new string[] {"PC", "PS4", "PS5", "Xbox", "Switch"}, Mode = new string[] { "Singleplayer" }, IsOnline = false, Harga = 250000 }
            ,
        };
        // mengembalikan semua game
        [HttpGet]
        public ActionResult<List<Game>> Get()
        {
            return Ok(game);
        }
        // mengembalikan game berdasarkan index
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return game[id];
        }
        // menambahkan game baru
        [HttpPost]
        public ActionResult<Game> Post([FromBody] Game games)
        {
            game.Add(games);
            return Ok("Game berhasil ditambahkan.");
        }

        [HttpPut]// mengupdate game berdasarkan index
        public ActionResult Put([FromBody] Game games, int id)
        {
            var existingGame = game.FirstOrDefault(g => g.id == id);
            if (existingGame == null)
            {
                return NotFound();
            }
            existingGame.Nama = games.Nama;
            existingGame.Developer = games.Developer;
            existingGame.TahunRilis = games.TahunRilis;
            existingGame.Genre = games.Genre;
            existingGame.Rating = games.Rating;
            existingGame.Platform = games.Platform;
            existingGame.Mode = games.Mode;
            existingGame.IsOnline = games.IsOnline;
            existingGame.Harga = games.Harga;
            return NoContent();
        }
        // mengupdate or hpus game berdasarkan index
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            game.RemoveAt(id);
        }
    }
}