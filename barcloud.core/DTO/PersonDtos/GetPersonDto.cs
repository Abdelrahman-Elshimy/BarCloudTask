using barcloud.core.DTO.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.DTO.PersonDtos
{
    public class GetPersonDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public IEnumerable<GetAddressDto>? Addresses { get; set; }

    }
}
