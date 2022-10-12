using ApiMymall.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using ServiceLayer.Services.Interfaces;

namespace EMobileApi.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateCountry")]
        public async Task<IActionResult> Create([FromBody] CountryDto countryDto)
        {
            await _service.CreateAsync(countryDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateCountry")]
        public async Task<IActionResult> Update([FromBody] CountryEditDto countryEditDto)
        {


            await _service.UpdateAsync(countryEditDto.Id, countryEditDto);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllCountry")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCountryCities")]
        public async Task<IActionResult> GetAllCountryCities([FromBody] CountryEditDto countryEditDto)
        {
            var result = await _service.GetAllCountryCitiesAsync(countryEditDto.Id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetByCateId/{id}")]
        //public async Task<IActionResult> GetByCateId([FromRoute] int id)
        //{
        //    var result = await _service.GetByCateId(id);
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("GetAllByName/{txt}")]
        public async Task<IActionResult> GetAllByName([FromRoute] string txt)
        {
            return Ok(await _service.GetAllNameAsync(txt));
        }

    }
}