﻿using ApiPersonne.Data.Dtos;
using ApiPersonne.Data.Models;
using ApiPersonne.Data.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly PersonnesService _service;
        private readonly IMapper _mapper;
        public PersonnesController(PersonnesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/personnes
        [HttpGet]
        public ActionResult<IEnumerable<PersonnesDTO>> getAllPersonnes()
        {
            var listePersonnes = _service.GetAllPersonnes();
            return Ok(_mapper.Map<IEnumerable<PersonnesDTO>>(listePersonnes));
        }

        //GET api/personnes/{id}
        [HttpGet("{id}", Name = "GetPersonneById")]
        public ActionResult<PersonnesDTO> GetPersonneById(int id)
        {
            var commandItem = _service.GetPersonneById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PersonnesDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/personnes
        [HttpPost]
        public ActionResult<PersonnesDTO> CreatePersonne(Personne personne)
        {
            //on ajoute l’objet à la base de données
            _service.AddPersonnes(personne);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPersonneById), new { Id = personne.Id }, personne);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePersonne(int id, PersonnesDTO personne)
        {
            var personneFromRepo = _service.GetPersonneById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }
            personneFromRepo.Dump();
            _mapper.Map(personne, personneFromRepo);
            personneFromRepo.Dump();
            personne.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdatePersonne(personneFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Personne> patchDoc)
        {
            try
            {
                var personneFromRepo = _service.GetPersonneById(id);
                personneFromRepo.Dump();

                var personneToPatch = _mapper.Map<Personne>(personneFromRepo);

                patchDoc.ApplyTo(personneToPatch, ModelState);

                if (!TryValidateModel(personneToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(personneToPatch, personneFromRepo);
                _service.UpdatePersonne(personneFromRepo);
                personneFromRepo.Dump();
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

        //DELETE api/personnes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePersonne(int id)
        {
            var personneModelFromRepo = _service.GetPersonneById(id);
            if (personneModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePersonne(personneModelFromRepo);
            return NoContent();
        }
    }
}
