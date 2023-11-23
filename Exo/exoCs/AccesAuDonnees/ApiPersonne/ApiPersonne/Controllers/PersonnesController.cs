using ApiPersonne.Data.Dtos;
using ApiPersonne.Data.Services;
using AutoMapper;
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

    }
}
