using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;


namespace barcloud.core.Services.AddressServices
{
    public interface IAddressService
    {
        Task<int> Add(CreateAddressDto createAddress);
        Task<IEnumerable<GetAddressModelDto>> GetAll();
        Task<GetAddressModelDto> GetById(int id);
        bool Update(UpdateAddressDto updateAddress);
        Task<bool> Delete(int id);

        Task<IEnumerable<GetAddressModelDto>> Filter(FilterAddressRequestDto filterAddressRequest);

    }
}
