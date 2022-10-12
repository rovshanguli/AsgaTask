using DomainLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface ICountryRepository : IRespository<Country>
    {
        Task<Country> GetCountryAsync(int id);
    }
}
