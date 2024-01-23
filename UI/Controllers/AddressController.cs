using BL.Interfaces;
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
        public async Task<ActionResult<List<Address>>> GetAll()
        {
            return Ok(await addressBL.GetAll());
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult> AddAddress(AddressDTO address)
        {
            await addressBL.Add(address);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateAddress/{id}")]
        public async Task<ActionResult> UpdateAddress(AddressDTO address,int id)
        {
            return Ok(await addressBL.Update(address,id));
        }
        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(int id)
        {
            await addressBL.Delete(id);
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