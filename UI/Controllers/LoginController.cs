using BL.Interfaces;
using DAL.Exceptions;
using DAL.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        ILoginBL loginBL;

        public LoginController(ILoginBL loginBL)
        {
            this.loginBL = loginBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LoginDTO>>> GetAll()
        {
            List<LoginDTO> result = new List<LoginDTO>();
            try
            {
                result = await loginBL.GetAll();
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

        [HttpPost("AddLogin")]
        public async Task<ActionResult<bool>> AddLogin(LoginDTO login)
        {
            try
            {
            await loginBL.Add(login);

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
        [HttpPut]
        [Route("UpdateLogin/{id}")]
        public async Task<ActionResult> UpdateLogin(LoginDTO login, int id)
        {
            try
            {
                await loginBL.Update(login, id);
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
        [Route("DeleteLogin/{id}")]
        public async Task<ActionResult<bool>> DeleteLogin(int id)
        {
            try
            {
            await loginBL.Delete(id);

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
