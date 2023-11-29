using ApiGameBis.Helpers;
using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using ApiGameBis.Models.Profiles;
using ApiGameBis.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameBis.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesServices _service;
        private readonly SeriesServices _serviceSerie;
        private readonly IMapper _mapper;
        public GamesController(GamesServices service, SeriesServices serviceSerie, IMapper mapper)
        {
            _service = service;
            _serviceSerie = serviceSerie;
            _mapper = mapper;
        }

        //GET api/Games
        [HttpGet]
        public ActionResult<IEnumerable<GamesDtoFull>> getAllGames()
        {
            var listeGames = _service.GetAllGames();
            return Ok(_mapper.Map<IEnumerable<GamesDtoFull>>(listeGames));
        }

        //GET api/Games/{id}
        [HttpGet("{id}", Name = "GetGameById")]
        public ActionResult<GamesDtoFull> GetGameById(int id)
        {
            var commandItem = _service.GetGameById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GamesDtoFull>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<Game> CreateGame(GamesDtoOut gameDto)
        {
            Game game = new Game();
            var serie = _serviceSerie.GetSerieBySerieName(gameDto.SerieName);
            if (serie != null)
            {
                game = GamesProfile.GameDtoToGame(gameDto, serie);
                //on ajoute l’objet à la base de données
                _service.AddGames(game);
                //on retourne le chemin de findById avec l'objet créé
                return CreatedAtRoute(nameof(GetGameById), new { Id = game.IdGame }, game);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, GamesDto game)
        {
            var gameFromRepo = _service.GetGameById(id);
            if (gameFromRepo == null)
            {
                return NotFound();
            }
            gameFromRepo.Dump();
            _mapper.Map(game, gameFromRepo);
            gameFromRepo.Dump();
            game.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateGame(gameFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialGameUpdate(int id, JsonPatchDocument<Game> patchDoc)
        {
            try
            {
                var gameFromRepo = _service.GetGameById(id);
                gameFromRepo.Dump();

                var gameToPatch = _mapper.Map<Game>(gameFromRepo);

                patchDoc.ApplyTo(gameToPatch, ModelState);

                if (!TryValidateModel(gameToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(gameToPatch, gameFromRepo);
                _service.UpdateGame(gameFromRepo);
                gameFromRepo.Dump();
            }
            catch (HttpRequestException error)
            {
                return null;
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        //DELETE api/Games/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            var gameModelFromRepo = _service.GetGameById(id);
            if (gameModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteGame(gameModelFromRepo);
            return NoContent();
        }
    }


}
