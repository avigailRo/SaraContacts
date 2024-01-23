using BL.Interfaces;
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
        public async Task<ActionResult<List<Status>>> GetAll()
        {
            return Ok(await statusBL.GetAll());
        }

        [HttpPost("AddStatus")]
        public async Task<ActionResult<bool>> AddStatus(StatusDTO status)
        {
            await statusBL.Add(status);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateStatus/{id}")]
        public async Task<ActionResult> UpdateStatus(StatusDTO status, int id)
        {
            return Ok(await statusBL.Update(status, id));
        }
        [HttpDelete]
        [Route("DeleteStatus/{id}")]
        public async Task<ActionResult<bool>> DeleteStatus(int id)
        {
            await statusBL.Delete(id);
            return Ok();
        }
    }
}
