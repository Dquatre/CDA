using AutoMapper;
using CreerApi.Data.DTO;
using CreerApi.Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace CreerApi.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController:ControllerBase
    {
        private readonly PersonneServices _service;
        private readonly IMapper _mapper;
        public PersonneController(PersonneServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonneDTO>> getAllPersonnes()
        {
            var listePersonnes = _service.GetAllPersonnes();
            return Ok(_mapper.Map<IEnumerable<PersonneDTO>>(listePersonnes));
        }
    }
}
