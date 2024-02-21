using AutoMapper;
using CrudWithBdd.Models;
using CrudWithBdd.Models.Data;
using CrudWithBdd.Models.Dtos;
using CrudWithBdd.Models.Profiles;
using CrudWithBdd.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Controller
{
    public class BatimentsController : ControllerBase
    {
        private readonly BatimentsServices _service;
        private readonly IMapper _mapper;
        public BatimentsController(ComplexDbContext context)
        {
            _service = new BatimentsServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BatimentsProfile>();
                cfg.AddProfile<SallesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<BatimentsDtoOut> getAllBatiments()
        {
            var listeBatiments = _service.GetAllBatiments();
            return _mapper.Map<IEnumerable<BatimentsDtoOut>>(listeBatiments);
        }


        public ActionResult<BatimentsDtoOut> GetBatimentById(int id)
        {
            var commandItem = _service.GetBatimentById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<BatimentsDtoOut>(commandItem));
            }
            return NotFound();
        }

        public ActionResult<Salle> CreateBatiment(BatimentsDtoOut objDto)
        {
            Salle obj = new Salle();
            _mapper.Map(objDto, obj);
            //on ajoute l’objet à la base de données
            _service.AddBatiments(obj);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetBatimentById), new { Id = obj.IdBatiment }, obj);
        }

        public ActionResult UpdateBatiment(int id, BatimentsDtoOut obj)
        {
            var objFromRepo = _service.GetBatimentById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateBatiment(objFromRepo);
            return NoContent();
        }

        public ActionResult PartialBatimentUpdate(int id, JsonPatchDocument<Salle> patchDoc)
        {
            try
            {
                var objFromRepo = _service.GetBatimentById(id);

                var objToPatch = _mapper.Map<Salle>(objFromRepo);

                patchDoc.ApplyTo(objToPatch, ModelState);

                if (!TryValidateModel(objToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(objToPatch, objFromRepo);
                _service.UpdateBatiment(objFromRepo);
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


        public ActionResult DeleteBatiment(int id)
        {
            var objModelFromRepo = _service.GetBatimentById(id);
            if (objModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteBatiment(objModelFromRepo);
            return NoContent();
        }
    }
}
