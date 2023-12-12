
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

    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesServices _service;
        private readonly IMapper _mapper;

        public CategoriesController(GestionStockDbContext context)
        {
            _service = new CategoriesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoriesProfiles>();
            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<CategoriesDtoOut> GetAllCategories()
        {
            IEnumerable<Category> listeCategories = _service.GetAllCategorys();
            return _mapper.Map<IEnumerable<CategoriesDtoOut>>(listeCategories);
        }



        public CategoriesDtoOut GetCategoryById(int id)
        {
            var item = _service.GetCategoryById(id);
            if (item != null)
            {
                return _mapper.Map<CategoriesDtoOut>(item);
            }
            return null;
        }


        public void CreateCategory(CategoriesDtoOut itemDto)
        {
            Category itemPOCO = _mapper.Map<Category>(itemDto);
            _service.AddCategories(itemPOCO);
        }


        public void UpdateCategory(int id, CategoriesDtoOut item)
        {
            var itemFromRepo = _service.GetCategoryById(id);
            if (itemFromRepo != null)
            {
                _mapper.Map(item, itemFromRepo);
                _service.UpdateCategory(itemFromRepo);
            }

        }

        public void DeleteCategory(int id)
        {
            var itemFromRepo = _service.GetCategoryById(id);
            if (itemFromRepo != null)
            {
                _service.DeleteCategory(itemFromRepo);
            }
        }
    }
}
