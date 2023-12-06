using AutoMapper;
using CrudPersistant.Helpers;
using CrudPersistant.Models.Data;
using CrudPersistant.Models.Dtos;
using CrudPersistant.Models.Profiles;
using CrudPersistant.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudPersistant.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsServices Service { get; set; }
        public ProductsProfile ProfileProd { get; set; }
        public ProductsController()
        {
            Service = new ProductsServices();
            ProfileProd = new ProductsProfile();
        }

        //GET api/Products
        [HttpGet] 
        public IEnumerable<ProductDtoOut> getAllProducts()
        {
            var listeProducts = Service.GetAllProducts();
            return ProfileProd.ListPocoToDto((List<Product>)listeProducts);
        }

        //GET api/Products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public ProductDtoOut GetProductById(int id)
        {
            var commandItem = Service.GetProductById(id);
            if (commandItem != null)
            {
                return ProfileProd.PocoToDto(commandItem);
            }
            return null;
        }

        //POST api/GameConsoles
        /*[HttpPost]
        public ActionResult<Product> CreateProduct(ProductDtoOut objDto)
        {
            Product obj = new Product();
            ProfileProd.Map(objDto, obj);
            //on ajoute l’objet à la base de données
            Service.AddProducts(obj);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetProductById), new { Id = obj.IdProduct }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductDtoOut obj)
        {
            var objFromRepo = Service.GetProductById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            objFromRepo.Dump();
            ProfileProd.Map(obj, objFromRepo);
            objFromRepo.Dump();
            obj.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            Service.UpdateProduct(objFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<Product> patchDoc)
        {
            try
            {
                var objFromRepo = Service.GetProductById(id);
                objFromRepo.Dump();

                var objToPatch = ProfileProd.Map<Product>(objFromRepo);

                patchDoc.ApplyTo(objToPatch, ModelState);

                if (!TryValidateModel(objToPatch)) return ValidationProblem(ModelState);
                ProfileProd.Map(objToPatch, objFromRepo);
                Service.UpdateProduct(objFromRepo);
                objFromRepo.Dump();
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

        //DELETE api/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var objModelFromRepo = Service.GetProductById(id);
            if (objModelFromRepo == null)
            {
                return NotFound();
            }
            Service.DeleteProduct(objModelFromRepo);
            return NoContent();
        }*/
    }
}
