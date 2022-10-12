using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICityService
    {
        Task CreateAsync(CityDto cityDto);

        Task UpdateAsync(int Id, CityEditDto cityEditDto);
        Task DeleteAsync(int id);
        Task<List<CityDto>> GetAllAsync();
        Task<CityDto> GetAsync(int id);
        Task<CityDto> GetByIdAsync(int id);
        Task<IEnumerable<CityDto>> GetAllNameAsync(string name);
        Task<IEnumerable<CityDto>> GetAllCountryIdAsync(int countryId);                             
    }
}
