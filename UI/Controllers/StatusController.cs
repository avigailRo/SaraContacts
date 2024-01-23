using BL.Interfaces;
using DAL.Exceptions;
using DAL.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController:ControllerBase
    {
        IStatusBL statusBL;

        public StatusController(IStatusBL statusBL)
        {
            this.statusBL = statusBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<StatusDTO>>> GetAll()
        {
            List<StatusDTO> result = new List<StatusDTO>(); try
            {
                result = await statusBL.GetAll();
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

        [HttpPost("AddStatus")]
        public async Task<ActionResult<bool>> AddStatus(StatusDTO status)
        {
            try { 
            await statusBL.Add(status);}
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
        [Route("UpdateStatus/{id}")]
        public async Task<ActionResult> UpdateStatus(StatusDTO status, int id)
        {
            try
            {
                await statusBL.Update(status, id);
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
        [Route("DeleteStatus/{id}")]
        public async Task<ActionResult<bool>> DeleteStatus(int id)
        {
            try
            {
            await statusBL.Delete(id);

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
