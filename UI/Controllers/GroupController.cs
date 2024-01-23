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
    public class GroupController : ControllerBase
    {
       IGroupBL groupBL;

        public GroupController(IGroupBL groupBL)
        {
            this.groupBL = groupBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Group>>> GetAll()
        {
            return Ok(await groupBL.GetAll());
        }

        [HttpPost("AddGroup")]
        public async Task<ActionResult<bool>> AddGroup(GroupDTO groupDTO)
        {
            await groupBL.Add(groupDTO);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateGroup/{id}")]
        public async Task<ActionResult> UpdateGroup(GroupDTO group, int id)
        {
            return Ok(await groupBL.Update(group, id));
        }
        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(int id)
        {
            await groupBL.Delete(id);
            return Ok();
        }
    }
}