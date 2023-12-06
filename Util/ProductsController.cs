using AutoMapper;
using CrudPersistant.Helpers;
using CrudPersistant.Models.Data;
using CrudPersistant.Models.Dtos;
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
        private readonly ProductsServices _service;
        private readonly IMapper _mapper;
        public ProductsController(ProductsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Products
        [HttpGet]
        public List<ProductDtoOut> getAllProducts()
        {
            var listeProducts = _service.GetAllProducts();
            return (List<ProductDtoOut>)_mapper.Map<IEnumerable<ProductDtoOut>>(listeProducts);
        }

        //GET api/Products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductDtoOut> GetProductById(int id)
        {
            var commandItem = _service.GetProductById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ProductDtoOut>(commandItem));
            }
            return NotFound();
        }

        //POST api/GameConsoles
        [HttpPost]
        public ActionResult<Product> CreateProduct(ProductDtoOut productDto)
        {
            Product product = new Product();
            _mapper.Map(productDto, product);
            //on ajoute l’objet à la base de données
            _service.AddProducts(product);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetProductById), new { Id = product.IdProduct }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductDtoOut product)
        {
            var productFromRepo = _service.GetProductById(id);
            if (productFromRepo == null)
            {
                return NotFound();
            }
            productFromRepo.Dump();
            _mapper.Map(product, productFromRepo);
            productFromRepo.Dump();
            product.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateProduct(productFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<Product> patchDoc)
        {
            try
            {
                var productFromRepo = _service.GetProductById(id);
                productFromRepo.Dump();

                var productToPatch = _mapper.Map<Product>(productFromRepo);

                patchDoc.ApplyTo(productToPatch, ModelState);

                if (!TryValidateModel(productToPatch)) return ValidationProblem(ModelState);
                _mapper.Map(productToPatch, productFromRepo);
                _service.UpdateProduct(productFromRepo);
                productFromRepo.Dump();
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
            var productModelFromRepo = _service.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteProduct(productModelFromRepo);
            return NoContent();
        }
    }

}
