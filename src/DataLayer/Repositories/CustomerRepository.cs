using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CustomerRepository : IDataRepository<Customer>
    {
        public Task<Customer> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Customer>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
