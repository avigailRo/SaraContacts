using BL.Interfaces;
using BL.Services;
using DAL.Exceptions;
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
            try { 
            await countryBL.Add(countryDTO);}
            catch (NotFoundException ex)
            {
                return NotFound(null);
            }
            catch (DALException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 409
                };
            }
            catch (BLException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 411
                };

            }
            catch (Exception ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 500
                };

            }
            return Ok();
        }

        [HttpGet("GetAllCountries")]
        public async Task<ActionResult<List<CountryDTO>>> GetAllCountries()
        {
            List<CountryDTO> countries;
            try {
                 countries = await countryBL.GetAll(); }
            catch (NotFoundException ex)
            {
                return NotFound(null);
            }
            catch (DALException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 409
                };
            }
            catch (BLException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 411
                };

            }
            catch (Exception ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 500
                };

            }
            return Ok(countries);
        }
        [HttpPut]
        [Route("updateCountry/{id}")]
        public async Task<ActionResult> UpdateCountry(CountryDTO country, int id)
        {
            try
            {
                await countryBL.Update(country, id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(null);
            }
            catch (DALException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 409
                };
            }
            catch (BLException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 411
                };

            }
            catch (Exception ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 500
                };

            }
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public async Task<ActionResult<bool>> DeleteCountry(int id)
        {
            try
            {
            await countryBL.Delete(id);

            }
            catch (NotFoundException ex)
            {
                return NotFound(null);
            }
            catch (DALException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 409
                };
            }
            catch (BLException ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 411
                };

            }
            catch (Exception ex)
            {
                return new ObjectResult(new { ErrorMessage = ex.Message })
                {
                    StatusCode = 500
                };

            }
            return Ok();
        }
    }
}
