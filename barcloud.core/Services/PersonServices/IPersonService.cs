using barcloud.core.DTO.PersonDtos;

namespace barcloud.core.Services.PersonServices
{
    public interface IPersonService
    {
        Task<int> Add(CreatePersonDto createPerson);
        Task<IEnumerable<GetPersonDto>> GetAll();
        Task<GetPersonDto> GetById(int id);
        bool Update(UpdatePersonDto updatePerson);
        Task<bool> Delete(int id);
        Task<IEnumerable<GetPersonDto>> Filter(FilterRequestPersonDto filterRequestPerson);

    }
}
