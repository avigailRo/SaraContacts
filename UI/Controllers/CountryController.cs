using BL.Interfaces;
using BL.Services;
using DAL.Models;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryBL countryBL;

        public CountryController(ICountryBL countryBL)
        {
            this.countryBL = countryBL;
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult<bool>> AddCountry(CountryDTO countryDTO)
        {
            await countryBL.Add(countryDTO);
            return Ok();
        }

        [HttpGet("GetAllCountries")]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            return Ok(await countryBL.GetAll());
        }
        [HttpPut]
        [Route("updateCountry/{id}")]
        public async Task<ActionResult> UpdateCountry(CountryDTO country, int id)
        {
            return Ok(await countryBL.Update(country, id));
        }
        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public async Task<ActionResult<bool>> DeleteCountry(int id)
        {
            await countryBL.Delete(id);
            return Ok();
        }
    }
}
