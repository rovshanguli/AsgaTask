using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateAsync(CountryDto countryDto);

        Task UpdateAsync(int Id, CountryEditDto countryEditDto);
        Task DeleteAsync(int id);
        Task<List<CountryDto>> GetAllAsync();
        Task<CountryDto> GetAsync(int id);
        Task<CityDto> GetByIdAsync(int id);

 
        Task<IEnumerable<CityDto>> GetAllNameAsync(string name);
        Task<CountryDto> GetAllCountryCitiesAsync(int id);
        
    }
}
