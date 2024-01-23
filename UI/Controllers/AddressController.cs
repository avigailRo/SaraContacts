using BL.Interfaces;
using DAL.Exceptions;
using DAL.Models;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AddressDTO>>> GetAll()
        {
            List<AddressDTO> address = new();
            try
            {
                address = await addressBL.GetAll();
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
            return Ok(address);
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult> AddAddress(AddressDTO address)
        {
            try { 
            await addressBL.Add(address);}
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
        [HttpPut]
        [Route("UpdateAddress/{id}")]
        public async Task<ActionResult> UpdateAddress(AddressDTO address, int id)
        {
            try {
                await addressBL.Update(address, id);
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
        [Route("DeleteAddress/{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(int id)
        {
            try { 
            await addressBL.Delete(id);}
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
        [HttpGet]
        [Route("GetAddressById/{id}")]
        public async Task<ActionResult<bool>> GetAddressById(int id)
        {
            return Ok(await addressBL.GetByID(id));
        }
    }
}