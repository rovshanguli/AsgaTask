using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryDto countryDto)
        {
            var model = _mapper.Map<Country>(countryDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _repository.GetAsync(id);
            await _repository.DeleteAsync(country);
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<CountryDto>>(model);
            return res;
        }

        public async Task<CountryDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<CountryDto>(model);
            return res;
        }

        public async Task<CountryDto> GetAllCountryCitiesAsync(int id)
        {
            var model = await _repository.GetCountryAsync(id);
            var res = _mapper.Map<CountryDto>(model);
            return res;
        }

        public async Task UpdateAsync(int Id, CountryEditDto countryedit)
        {
            var entity = await _repository.GetAsync(Id);

            _mapper.Map(countryedit, entity);

            await _repository.UpdateAsync(entity);
        }
        public async Task<CityDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<CityDto>(model);
            return res;
        }
        public async Task<IEnumerable<CityDto>> GetAllNameAsync(string search)
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }
    }
}