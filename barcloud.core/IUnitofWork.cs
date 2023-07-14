using barcloud.core.Interfaces;
using barcloud.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core
{
    public interface IUnitofWork:IDisposable
    {
        IBaseRepository<Person> Persons { get; }
        IBaseRepository<Address> Addresses { get; }
        int Complete();
    }
}
