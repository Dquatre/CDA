
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WpfCrud01.Models;
using WpfCrud01.Models.Data;
using WpfCrud01.Models.Dtos;
using WpfCrud01.Models.Profiles;
using WpfCrud01.Models.Services;

namespace WpfCrud01.Controller
{

    public class LivresController : ControllerBase
    {
        private readonly LivresServices _service;
        private readonly IMapper _mapper;

        public LivresController(LivreDbContext context)
        {
            _service = new LivresServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LivresProfiles>();
            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<LivresDtoOut> GetAllLivres()
        {
            IEnumerable<Livre> listeLivres = _service.GetAllLivres();
            return _mapper.Map<IEnumerable<LivresDtoOut>>(listeLivres);
        }



        public ActionResult<LivresDtoOut> GetLivreById(int id)
        {
            var item = _service.GetLivreById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<LivresDtoOut>(item));
            }
            return NotFound();
        }


        public ActionResult<LivresDtoOut> CreateLivre(LivresDtoOut LivreDTO)
        {
            Livre LivrePOCO = _mapper.Map<Livre>(LivreDTO);
            //on ajoute l’objet à la base de données
            _service.AddLivres(LivrePOCO);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetLivreById), new { Id = LivrePOCO.IdLivre }, LivrePOCO);

        }


        public ActionResult UpdateLivre(int id, LivresDtoOut Livre)
        {
            var LivreFromRepo = _service.GetLivreById(id);
            if (LivreFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(Livre, LivreFromRepo);
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateLivre(LivreFromRepo);

            return NoContent();
        }

        public ActionResult DeleteLivre(int id)
        {
            var LivreModelFromRepo = _service.GetLivreById(id);
            if (LivreModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteLivre(LivreModelFromRepo);

            return NoContent();
        }

    }
}
