using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.DTO.AddressDtos
{
    public class GetAddressDto
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
