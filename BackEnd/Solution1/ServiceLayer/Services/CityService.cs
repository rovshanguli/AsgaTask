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
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityDto cityDto)
        {
            var model = _mapper.Map<City>(cityDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _repository.GetAsync(id);
            await _repository.DeleteAsync(city);
        }
        
        public async Task<List<CityDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<CityDto>>(model);
            return res;
        }

        public async Task<CityDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<CityDto>(model);
            return res;
        }

        public async Task UpdateAsync(int Id, CityEditDto cityedit)
        {
            var entity = await _repository.GetAsync(Id);

            _mapper.Map(cityedit, entity);

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

        public async Task<IEnumerable<CityDto>> GetAllCountryIdAsync(int countryId)
        {
            var datas = await _repository.GetCitiesByCountryId(countryId);
            return _mapper.Map<IEnumerable<CityDto>>(datas);
        }
    
    }
}