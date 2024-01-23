using BL.Interfaces;
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
        public async Task<ActionResult<List<Login>>> GetAll()
        {
            return Ok(await loginBL.GetAll());
        }

        [HttpPost("AddLogin")]
        public async Task<ActionResult<bool>> AddLogin(LoginDTO login)
        {
            await loginBL.Add(login);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateLogin/{id}")]
        public async Task<ActionResult> UpdateLogin(LoginDTO login, int id)
        {
            return Ok(await loginBL.Update(login, id));
        }
        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        public async Task<ActionResult<bool>> DeleteLogin(int id)
        {
            await loginBL.Delete(id);
            return Ok();
        }
    }
}
