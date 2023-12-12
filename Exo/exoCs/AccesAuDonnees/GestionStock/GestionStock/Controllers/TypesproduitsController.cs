
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GestionStock.Models;
using GestionStock.Models.Data;
using GestionStock.Models.Dtos;
using GestionStock.Models.Profiles;
using GestionStock.Models.Services;

namespace GestionStock.Controller
{

    public class TypesproduitsController : ControllerBase
    {
        private readonly TypesproduitsServices _service;
        private readonly IMapper _mapper;

        public TypesproduitsController(GestionStockDbContext context)
        {
            _service = new TypesproduitsServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TypesproduitsProfiles>();
            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<TypesproduitsDtoOut> GetAllTypesproduits()
        {
            IEnumerable<Typesproduit> listeTypesproduits = _service.GetAllTypesproduits();
            return _mapper.Map<IEnumerable<TypesproduitsDtoOut>>(listeTypesproduits);
        }



        public TypesproduitsDtoOut GetTypesproduitById(int id)
        {
            var item = _service.GetTypesproduitById(id);
            if (item != null)
            {
                return _mapper.Map<TypesproduitsDtoOut>(item);
            }
            return null;
        }


        public void CreateTypesproduit(TypesproduitsDtoOut itemDto)
        {
            Typesproduit itemPOCO = _mapper.Map<Typesproduit>(itemDto);
            _service.AddTypesproduits(itemPOCO);
        }


        public void UpdateTypesproduit(int id, TypesproduitsDtoOut item)
        {
            var itemFromRepo = _service.GetTypesproduitById(id);
            if (itemFromRepo != null)
            {
                _mapper.Map(item, itemFromRepo);
                _service.UpdateTypesproduit(itemFromRepo);
            }

        }

        public void DeleteTypesproduit(int id)
        {
            var itemFromRepo = _service.GetTypesproduitById(id);
            if (itemFromRepo != null)
            {
                _service.DeleteTypesproduit(itemFromRepo);
            }
        }
    }
}
