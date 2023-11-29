using ApiGame.Data.Dtos;
using ApiGame.Data.Models;
using ApiGame.Data.Services;
using ApiGame.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameConsolesController : ControllerBase
    {
        private readonly GameConsolesServices _service;
        private readonly IMapper _mapper;
        public GameConsolesController(GameConsolesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/GameConsoles
        [HttpGet]
        public ActionResult<IEnumerable<GameConsolesDTOFull>> getAllGameConsoles()
        {
            var listeGameConsoles = _service.GetAllGameConsoles();
            return Ok(_mapper.Map<IEnumerable<GameConsolesDTOFull>>(listeGameConsoles));
        }

        //GET api/GameConsoles/{id}
        [HttpGet("{id}", Name = "GetGameConsoleById")]
        public ActionResult<GameConsolesDTOFull> GetGameConsoleById(int id)
        {
            var commandItem = _service.GetGameConsoleById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GameConsolesDTOFull>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<GameConsolesDTO> CreateGameConsole(GameConsolesDTO gameConsoleDto)
        {
            GameConsole gameConsole = new GameConsole() ;
            _mapper.Map(gameConsoleDto, gameConsole);
            //on ajoute l’objet à la base de données
            _service.AddGameConsoles(gameConsole);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetGameConsoleById), new { Id = gameConsole.IdGameConsole }, gameConsole);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGameConsole(int id, GameConsolesDTO gameConsole)
        {
            var gameConsoleFromRepo = _service.GetGameConsoleById(id);
            if (gameConsoleFromRepo == null)
            {
                return NotFound();
            }
            gameConsoleFromRepo.Dump();
            _mapper.Map(gameConsole, gameConsoleFromRepo);
            gameConsoleFromRepo.Dump();
            gameConsole.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateGameConsole(gameConsoleFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialGameConsoleUpdate(int id, JsonPatchDocument<GameConsole> patchDoc)
        {
            try
            {
                var gameConsoleFromRepo = _service.GetGameConsoleById(id);
                gameConsoleFromRepo.Dump();

                var gameConsoleToPatch = _mapper.Map<GameConsole>(gameConsoleFromRepo);

                patchDoc.ApplyTo(gameConsoleToPatch, ModelState);

                if (!TryValidateModel(gameConsoleToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(gameConsoleToPatch, gameConsoleFromRepo);
                _service.UpdateGameConsole(gameConsoleFromRepo);
                gameConsoleFromRepo.Dump();
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

        //DELETE api/GameConsoles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGameConsole(int id)
        {
            var gameConsoleModelFromRepo = _service.GetGameConsoleById(id);
            if (gameConsoleModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteGameConsole(gameConsoleModelFromRepo);
            return NoContent();
        }
    }
}
