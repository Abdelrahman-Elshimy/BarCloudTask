using barcloud.core;
using barcloud.core.Interfaces;
using barcloud.core.Models;
using barcloud.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.EF
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Person> Persons { get; private set; }

        public IBaseRepository<Address> Addresses {get; private set; }

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Persons = new BaseRepository<Person>(_context);
            Addresses = new BaseRepository<Address>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
