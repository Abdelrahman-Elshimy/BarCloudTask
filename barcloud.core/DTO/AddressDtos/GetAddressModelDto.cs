using barcloud.core.DTO.PersonDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.DTO.AddressDtos
{
    public class GetAddressModelDto
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public int PersonId { get; set; }
        public GetPersonBasicDto? Person { get; set; }

    }
}
