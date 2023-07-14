using AutoMapper;
using barcloud.core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonMappingProfile>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}
