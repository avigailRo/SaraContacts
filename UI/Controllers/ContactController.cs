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
    public class ContactController : ControllerBase
    {
        IContactBL contactBL;
        public ContactController(IContactBL contactBL)
        {
            this.contactBL = contactBL;
        }
        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return Ok(await contactBL.GetAll());
        }

        [HttpPost("AddContact")]
        public async Task<ActionResult<bool>> AddContact(ContactDTO contact)
        {
            await contactBL.Add(contact);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateContact/{id}")]
        public async Task<ActionResult<bool>> UpdateContact(ContactDTO contact, int id)
        {
            return Ok(await contactBL.Update(contact, id));
        }
        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public async Task<ActionResult<bool>> DeleteContact(int id)
        {
            await contactBL.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("GetContactById/{id}")]
        public async Task<ActionResult<bool>> GetContactById(int id)
        {
            return Ok(await contactBL.GetByID(id));
        }
    }
}