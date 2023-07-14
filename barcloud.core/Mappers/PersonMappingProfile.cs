using AutoMapper;
using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;
using barcloud.core.Models;

namespace barcloud.core.Mappers
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, GetPersonDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Address.Select(address => new GetAddressDto
                {
                    City = address.City,
                    Id = address.Id,
                    Street = address.Street
                })));

            CreateMap<Address, GetAddressDto>();

            CreateMap<Address, GetAddressModelDto>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

            CreateMap<Person, GetPersonBasicDto>();
        }
    }


}
   