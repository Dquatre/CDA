

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using global::testMongo.Services;
using global::testMongo.Dto;
using global::testMongo.Models;

namespace testMongo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _LoginService;
        private readonly IMapper _mapper;

        public LoginController(LoginService service, IMapper mapper)
        {
            _LoginService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDto>>> Get()
        {
            var listeLogin = await _LoginService.GetAsync();
            var Login = _mapper.Map<IEnumerable<LoginDto>>(listeLogin);
            return Ok(Login);
        }

        [HttpGet("{id}", Name = "GetLoginById")]
        public async Task<ActionResult<Login>> Get(int id)
        {
            var LoginItem = await _LoginService.GetAsync(id);

            if (LoginItem != null)
            {
                return Ok(LoginItem);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Login>> CreateLogin(Login entity)
        {
            await _LoginService.CreateAsync(entity);

            return CreatedAtRoute("GetLoginById", new { id = entity.Id }, entity);
        }

        [HttpPost("{email}/{password}")]
        public async Task<ActionResult<string>> ValidateLogin(string email, string password){

            var listeLogin = await _LoginService.GetAsync();
            foreach (var item in listeLogin)
            {
                
            }
            return Ok("oui"); 
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLogin(int id, Login entity)
        {
            var LoginFromRepo = await _LoginService.GetAsync(id);

            if (LoginFromRepo == null)
            {
                return NotFound();
            }

            await _LoginService.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _LoginService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _LoginService.RemoveAsync(id);

            return NoContent();
        }
    }
}



