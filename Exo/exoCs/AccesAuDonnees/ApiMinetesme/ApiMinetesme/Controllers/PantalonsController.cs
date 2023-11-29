using ApiMinetesme.Data.Dtos;
using ApiMinetesme.Data.Models;
using ApiMinetesme.Data.Services;
using ApiMinetesme;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiMinetesme.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class PantalonsController : ControllerBase
    {
        private readonly PantalonsService _service;
        private readonly IMapper _mapper;
        public PantalonsController(PantalonsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Pantalons
        [HttpGet]
        public ActionResult<IEnumerable<PantalonsDTO>> getAllPantalons()
        {
            var listePantalons = _service.GetAllPantalons();
            return Ok(_mapper.Map<IEnumerable<PantalonsDTO>>(listePantalons));
        }

        //GET api/Pantalons/{id}
        [HttpGet("{id}", Name = "GetPantalonById")]
        public ActionResult<PantalonsDTO> GetPantalonById(int id)
        {
            var commandItem = _service.GetPantalonById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PantalonsDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Pantalons
        [HttpPost]
        public ActionResult<PantalonsDTO> CreatePantalon(Pantalon Pantalon)
        {
            //on ajoute l’objet à la base de données
            _service.AddPantalons(Pantalon);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPantalonById), new { Id = Pantalon.Id }, Pantalon);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePantalon(int id, PantalonsDTO Pantalon)
        {
            var PantalonFromRepo = _service.GetPantalonById(id);
            if (PantalonFromRepo == null)
            {
                return NotFound();
            }
            PantalonFromRepo.Dump();
            _mapper.Map(Pantalon, PantalonFromRepo);
            PantalonFromRepo.Dump();
            Pantalon.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdatePantalon(PantalonFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPantalonUpdate(int id, JsonPatchDocument<Pantalon> patchDoc)
        {
            try
            {
                var PantalonFromRepo = _service.GetPantalonById(id);
                PantalonFromRepo.Dump();

                var PantalonToPatch = _mapper.Map<Pantalon>(PantalonFromRepo);

                patchDoc.ApplyTo(PantalonToPatch, ModelState);

                if (!TryValidateModel(PantalonToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(PantalonToPatch, PantalonFromRepo);
                _service.UpdatePantalon(PantalonFromRepo);
                PantalonFromRepo.Dump();
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

        //DELETE api/Pantalons/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePantalon(int id)
        {
            var PantalonModelFromRepo = _service.GetPantalonById(id);
            if (PantalonModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePantalon(PantalonModelFromRepo);
            return NoContent();
        }
    }
}
