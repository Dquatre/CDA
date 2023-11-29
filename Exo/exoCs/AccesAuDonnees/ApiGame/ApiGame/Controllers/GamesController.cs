using ApiGame.Data.Dtos;
using ApiGame.Data.Models;
using ApiGame.Data.Profiles;
using ApiGame.Data.Services;
using ApiGame.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesServices _service;
        private readonly GameConsolesServices _serviceGc;
        private readonly IMapper _mapper;
        public GamesController(GamesServices service, GameConsolesServices serviceGc, IMapper mapper)
        {
            
            _service = service;
            _serviceGc = serviceGc;
            _mapper = mapper;
        }

        //GET api/Games
        [HttpGet]
        public ActionResult<IEnumerable<GamesDTO>> getAllGames()
        {
            var listeGames = _service.GetAllGames();
            return Ok(_mapper.Map<IEnumerable<GamesDTO>>(listeGames));
        }

        //GET api/Games/{id}
        [HttpGet("{id}", Name = "GetGameById")]
        public ActionResult<GamesDTO> GetGameById(int id)
        {
            var commandItem = _service.GetGameById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GamesDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Games
        [HttpPost]
        public ActionResult<GamesDTO> CreateGame(GamesDTO gameDto)
        {
            Game game = new Game();
            var gameconsole = _serviceGc.GetGameConsoleByName(gameDto.GameConsoleName);
            if (gameconsole != null)
            {
                game = GamesProfile.GameDtoToGame(gameDto, gameconsole);
                //on ajoute l’objet à la base de données
                _service.AddGames(game);
                //on retourne le chemin de findById avec l'objet créé
                //return CreatedAtRoute(nameof(GetGameById), new { Id = game.IdGame }, game);
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, GamesPartDTO game)
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
