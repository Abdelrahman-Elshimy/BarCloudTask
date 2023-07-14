using AutoMapper;
using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;
using barcloud.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        protected readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(CreateAddressDto createAddress)
        {
            Address address = new Address()
            {
                City= createAddress.City,
                PersonId= createAddress.PersonId,
                Street = createAddress.Street,
            };
            await _unitOfWork.Addresses.Add(address);
            var result = _unitOfWork.Complete();
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Addresses.Delete(id);
            var result = _unitOfWork.Complete();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<GetAddressModelDto>> Filter(FilterAddressRequestDto filterAddressRequest)
        {
            var addresses = await _unitOfWork.Addresses.FindAll(new string[] { "Person" });
            var filtered = addresses.Where(address => address.City.Contains(filterAddressRequest.City) && address.Street.Contains(filterAddressRequest.Street));
            var result = _mapper.Map<IEnumerable<GetAddressModelDto>>(filtered);
            return result;
        }

        public async Task<IEnumerable<GetAddressModelDto>> GetAll()
        {
            var addresses = await _unitOfWork.Addresses.FindAll(new string[] { "Person" });
            var result = _mapper.Map<IEnumerable<GetAddressModelDto>>(addresses);
            return result;
        }

        public async Task<GetAddressModelDto> GetById(int id)
        {
            var addresses = await _unitOfWork.Addresses.FindAll(new string[] { "Person" });
            var result = _mapper.Map<IEnumerable<GetAddressModelDto>>(addresses).FirstOrDefault(person => person.Id == id);

            return result;

        }

        public bool Update(UpdateAddressDto updateAddress)
        {
            Address address = new Address
            {
                Id = updateAddress.Id,
                City = updateAddress.City,
                Street = updateAddress.Street,
                PersonId = updateAddress.PersonId,
            };

            _unitOfWork.Addresses.Update(address);
            var count = _unitOfWork.Complete();
            if (count > 0)
                return true;
            return false;
        }
    }
}
