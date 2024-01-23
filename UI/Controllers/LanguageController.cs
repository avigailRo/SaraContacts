using BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;
using BL.Services;
using DAL.Models;
using DAL.Exceptions;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        ILanguageBL languageBL;

        public LanguageController(ILanguageBL groupBL)
        {
            this.languageBL = groupBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LanguageDTO>>> GetAll()
        {
            List<LanguageDTO>languages = new List<LanguageDTO>();
            try
            {
                languages = await languageBL.GetAll();
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

        [HttpPost("AddLanguage")]
        public async Task<ActionResult<bool>> AddLanguage(LanguageDTO language)
        {
            try { 
            await languageBL.Add(language);}
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
        [Route("UpdateLanguage/{id}")]
        public async Task<ActionResult<LanguageDTO>> UpdateLanguage(LanguageDTO language, int id)
        {
            try
            {
                await languageBL.Update(language, id);
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
        [Route("DeleteLanguage/{id}")]
        public async Task<ActionResult<bool>> DeleteLanguage(int id)
        {
            try {   await languageBL.Delete(id);}
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
