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
    public class SallesController : ControllerBase
    {
        private readonly SallesServices _service;
        private readonly IMapper _mapper;
        public SallesController(ComplexDbContext context)
        {
            _service = new SallesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SallesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<SallesDtoOut> getAllSalles()
        {
            var listeSalles = _service.GetAllSalles();
            return _mapper.Map<IEnumerable<SallesDtoOut>>(listeSalles);
        }


        public ActionResult<SallesDtoOut> GetSalleById(int id)
        {
            var commandItem = _service.GetSalleById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<SallesDtoOut>(commandItem));
            }
            return NotFound();
        }

        public ActionResult<Salle> CreateSalle(SallesDtoOut objDto)
        {
            Salle obj = new Salle();
            _mapper.Map(objDto, obj);
            //on ajoute l’objet à la base de données
            _service.AddSalles(obj);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetSalleById), new { Id = obj.IdSalle }, obj);
        }

        public ActionResult UpdateSalle(int id, SallesDtoOut obj)
        {
            var objFromRepo = _service.GetSalleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateSalle(objFromRepo);
            return NoContent();
        }

        public ActionResult PartialSalleUpdate(int id, JsonPatchDocument<Salle> patchDoc)
        {
            try
            {
                var objFromRepo = _service.GetSalleById(id);

                var objToPatch = _mapper.Map<Salle>(objFromRepo);

                patchDoc.ApplyTo(objToPatch, ModelState);

                if (!TryValidateModel(objToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(objToPatch, objFromRepo);
                _service.UpdateSalle(objFromRepo);
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


        public ActionResult DeleteSalle(int id)
        {
            var objModelFromRepo = _service.GetSalleById(id);
            if (objModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteSalle(objModelFromRepo);
            return NoContent();
        }
    }
}
