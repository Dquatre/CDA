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
    public class PlatformsController : ControllerBase
    {
        private readonly PlatformsServices _service;
        private readonly IMapper _mapper;
        public PlatformsController(PlatformsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Platforms
        [HttpGet]
        public ActionResult<IEnumerable<PlatformsDtoWithListGamesPlatforms>> getAllPlatforms()
        {
            var listePlatforms = _service.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformsDtoWithListGamesPlatforms>>(listePlatforms));
        }

        //GET api/Platforms/{id}
        [HttpGet("{id}", Name = "PlatformById")]
        public ActionResult<PlatformsDtoWithListGamesPlatforms> GetPlatformById(int id)
        {
            var commandItem = _service.GetPlatformById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PlatformsDtoWithListGamesPlatforms>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<Platform> CreatePlatform(PlatformsDto platformDto)
        {
            Platform platform = new Platform();
            _mapper.Map(platformDto, platform);
            //on ajoute l’objet à la base de données
            _service.AddPlatforms(platform);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platform.IdPlatform }, platform);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlatform(int id, PlatformsDto platform)
        {
            var platformFromRepo = _service.GetPlatformById(id);
            if (platformFromRepo == null)
            {
                return NotFound();
            }
            platformFromRepo.Dump();
            _mapper.Map(platform, platformFromRepo);
            platformFromRepo.Dump();
            platform.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdatePlatform(platformFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPlatformUpdate(int id, JsonPatchDocument<Platform> patchDoc)
        {
            try
            {
                var platformFromRepo = _service.GetPlatformById(id);
                platformFromRepo.Dump();

                var platformToPatch = _mapper.Map<Platform>(platformFromRepo);

                patchDoc.ApplyTo(platformToPatch, ModelState);

                if (!TryValidateModel(platformToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(platformToPatch, platformFromRepo);
                _service.UpdatePlatform(platformFromRepo);
                platformFromRepo.Dump();
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

        //DELETE api/Platforms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var platformModelFromRepo = _service.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePlatform(platformModelFromRepo);
            return NoContent();
        }

    }
}
