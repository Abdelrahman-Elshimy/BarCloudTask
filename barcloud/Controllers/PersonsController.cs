using barcloud.core;
using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;
using barcloud.core.Interfaces;
using barcloud.core.Models;
using barcloud.core.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace barcloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService= personService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Person))]

        public async Task<IActionResult> GetById(int id)
        {
           var result = await _personService.GetById(id);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPersonDto>))]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.GetAll());
        }

        [HttpPost("FilterPerson")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPersonDto>))]

        public async Task<IActionResult> FilterPerson([FromBody] FilterRequestPersonDto filterRequestPerson)
        {
            return Ok(await _personService.Filter(filterRequestPerson));

        }
        [HttpPost]
        [ProducesResponseType(200)]

        public async Task<IActionResult> Person([FromBody] CreatePersonDto createPersonDto)
        {
            var result = await _personService.Add(createPersonDto);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(200)]

        public IActionResult Person([FromBody] UpdatePersonDto updatePerson)
        {
            var result = _personService.Update(updatePerson);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(200)]

        public async Task<IActionResult> Person(int id)
        {
            var result = await _personService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
