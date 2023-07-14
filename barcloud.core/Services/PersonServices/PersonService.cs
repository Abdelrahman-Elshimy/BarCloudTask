using AutoMapper;
using barcloud.core.DTO.AddressDtos;
using barcloud.core.DTO.PersonDtos;
using barcloud.core.Models;
namespace barcloud.core.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        protected readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(CreatePersonDto createPerson)
        {
            Person person = new Person()
            {
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName
            };
            await _unitOfWork.Persons.Add(person);
            var result =  _unitOfWork.Complete();
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Persons.Delete(id);
            var result = _unitOfWork.Complete();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<GetPersonDto>> GetAll()
        {
            var people = await _unitOfWork.Persons.FindAll(new string[] { "Address" });
            var result = _mapper.Map<IEnumerable<GetPersonDto>>(people);
            return result;
        }
        public async Task<IEnumerable<GetPersonDto>> Filter(FilterRequestPersonDto filterRequestPerson)
        {
            var people = await _unitOfWork.Persons.FindAll(new string[] { "Address" });
            var filtered = people.Where(person => person.FirstName.Contains(filterRequestPerson.FirstName) && person.LastName.Contains(filterRequestPerson.LastName));
            var result = _mapper.Map<IEnumerable<GetPersonDto>>(filtered);
            return result;
        }

        public async Task<GetPersonDto> GetById(int id)
        {
            var people = await _unitOfWork.Persons.FindAll(new string[] { "Address" });
            var result = _mapper.Map<IEnumerable<GetPersonDto>>(people).FirstOrDefault(person => person.Id == id);

            return result;

        }

        public bool Update(UpdatePersonDto updatePerson)
        {
            Person person = new Person
            {
                Id = updatePerson.Id,
                FirstName = updatePerson.FirstName,
                LastName = updatePerson.LastName
            };

            _unitOfWork.Persons.Update(person);
            var count = _unitOfWork.Complete();
            if (count > 0)
                return true;
            return false;
        }
    }
}
