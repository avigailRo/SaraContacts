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
    public class ContactController : ControllerBase
    {
        IContactBL contactBL;
        public ContactController(IContactBL contactBL)
        {
            this.contactBL = contactBL;
        }
        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<List<ContactDTO>>> GetAllContacts()
        {
            List<ContactDTO> contacts;
            try {
            contacts = await contactBL.GetAll(); }
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

        [HttpPost("AddContact")]
        public async Task<ActionResult<bool>> AddContact(ContactDTO contact)
        {
            try { 
            await contactBL.Add(contact);}
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
        [Route("UpdateContact/{id}")]
        public async Task<ActionResult> UpdateContact(ContactDTO contact, int id)
        {
            try
            {
                await contactBL.Update(contact, id);
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
        [Route("DeleteContact/{id}")]
        public async Task<ActionResult<bool>> DeleteContact(int id)
        {
            try { 
            await contactBL.Delete(id);}
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
        [Route("GetContactById/{id}")]
        public async Task<ActionResult<bool>> GetContactById(int id)
        {
            return Ok(await contactBL.GetByID(id));
        }
    }
}