using barcloud.core;
using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;
using barcloud.core.Interfaces;
using barcloud.core.Models;
using barcloud.core.Services.AddressServices;
using barcloud.core.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace barcloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Address))]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _addressService.GetById(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAddressModelDto>))]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _addressService.GetAll());
        }

        [HttpPost("FilterPerson")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAddressModelDto>))]

        public async Task<IActionResult> FilterPerson([FromBody] FilterAddressRequestDto filterAddressRequest)
        {
            return Ok(await _addressService.Filter(filterAddressRequest));

        }

        [HttpPost]
        [ProducesResponseType(200)]

        public async Task<IActionResult> Address([FromBody] CreateAddressDto createAddressDto)
        {
            var result = await _addressService.Add(createAddressDto);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(200)]

        public IActionResult Address([FromBody] UpdateAddressDto updateAddress)
        {
            var result = _addressService.Update(updateAddress);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(200)]

        public async Task<IActionResult> Address(int id)
        {
            var result = await _addressService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
