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
    public class SeriesController : ControllerBase
    {
        private readonly SeriesServices _service;
        private readonly IMapper _mapper;
        public SeriesController(SeriesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Series
        [HttpGet]
        public ActionResult<IEnumerable<SeriesDtoWithListGame>> getAllSeries()
        {
            var listeSeries = _service.GetAllSeries();
            return Ok(_mapper.Map<IEnumerable<SeriesDtoWithListGame>>(listeSeries));
        }

        //GET api/Series/{id}
        [HttpGet("{id}", Name = "GetSerieById")]
        public ActionResult<SeriesDtoWithListGame> GetSerieById(int id)
        {
            var commandItem = _service.GetSerieById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<SeriesDtoWithListGame>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<Serie> CreateSerie(SeriesDto serieDto)
        {
            Serie serie = new Serie();
            _mapper.Map(serieDto, serie);
            //on ajoute l’objet à la base de données
            _service.AddSeries(serie);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetSerieById), new { Id = serie.IdSerie }, serie);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSerie(int id, SeriesDto serie)
        {
            var serieFromRepo = _service.GetSerieById(id);
            if (serieFromRepo == null)
            {
                return NotFound();
            }
            serieFromRepo.Dump();
            _mapper.Map(serie, serieFromRepo);
            serieFromRepo.Dump();
            serie.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateSerie(serieFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialSerieUpdate(int id, JsonPatchDocument<Serie> patchDoc)
        {
            try
            {
                var serieFromRepo = _service.GetSerieById(id);
                serieFromRepo.Dump();

                var serieToPatch = _mapper.Map<Serie>(serieFromRepo);

                patchDoc.ApplyTo(serieToPatch, ModelState);

                if (!TryValidateModel(serieToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(serieToPatch, serieFromRepo);
                _service.UpdateSerie(serieFromRepo);
                serieFromRepo.Dump();
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

        //DELETE api/Series/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSerie(int id)
        {
            var serieModelFromRepo = _service.GetSerieById(id);
            if (serieModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteSerie(serieModelFromRepo);
            return NoContent();
        }
    }

}
