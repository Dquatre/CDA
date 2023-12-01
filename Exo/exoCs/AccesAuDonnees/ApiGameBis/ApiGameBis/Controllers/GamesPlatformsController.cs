using ApiGameBis.Helpers;
using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using ApiGameBis.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameBis.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class GamesPlatformsController : ControllerBase
    {
        private readonly GamesPlatformsServices _service;
        private readonly IMapper _mapper;
        public GamesPlatformsController(GamesPlatformsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/GamesPlatforms
        [HttpGet]
        public ActionResult<IEnumerable<GamesPlatformsDto>> getAllGamesPlatforms()
        {
            var listeGamesPlatforms = _service.GetAllGamesPlatforms();
            return Ok(_mapper.Map<IEnumerable<GamesPlatformsDto>>(listeGamesPlatforms));
        }

        //GET api/GamesPlatforms/{id}
        [HttpGet("{id}", Name = "GetGamesPlatformById")]
        public ActionResult<GamesPlatformsDto> GetGamesPlatformById(int id)
        {
            var commandItem = _service.GetGamesPlatformById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GamesPlatformsDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<GamesPlatform> CreateGamesPlatform(GamesPlatformsDto gamesPlatformDto)
        {
            GamesPlatform gamesPlatform = new GamesPlatform();
            _mapper.Map(gamesPlatformDto, gamesPlatform);
            //on ajoute l’objet à la base de données
            _service.AddGamesPlatforms(gamesPlatform);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetGamesPlatformById), new { Id = gamesPlatform.IdGamePlatform }, gamesPlatform);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGamesPlatform(int id, GamesPlatformsDto gamesPlatform)
        {
            var gamesPlatformFromRepo = _service.GetGamesPlatformById(id);
            if (gamesPlatformFromRepo == null)
            {
                return NotFound();
            }
            gamesPlatformFromRepo.Dump();
            _mapper.Map(gamesPlatform, gamesPlatformFromRepo);
            gamesPlatformFromRepo.Dump();
            gamesPlatform.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateGamesPlatform(gamesPlatformFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialGamesPlatformUpdate(int id, JsonPatchDocument<GamesPlatform> patchDoc)
        {
            try
            {
                var gamesPlatformFromRepo = _service.GetGamesPlatformById(id);
                gamesPlatformFromRepo.Dump();

                var gamesPlatformToPatch = _mapper.Map<GamesPlatform>(gamesPlatformFromRepo);

                patchDoc.ApplyTo(gamesPlatformToPatch, ModelState);

                if (!TryValidateModel(gamesPlatformToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(gamesPlatformToPatch, gamesPlatformFromRepo);
                _service.UpdateGamesPlatform(gamesPlatformFromRepo);
                gamesPlatformFromRepo.Dump();
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

        //DELETE api/GamesPlatforms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGamesPlatform(int id)
        {
            var gamesPlatformModelFromRepo = _service.GetGamesPlatformById(id);
            if (gamesPlatformModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteGamesPlatform(gamesPlatformModelFromRepo);
            return NoContent();
        }
    }


}
