using BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;
using BL.Services;
using DAL.Models;

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
        public async Task<ActionResult<List<Language>>> GetAll()
        {
            return Ok(await languageBL.GetAll());
        }

        [HttpPost("AddLanguage")]
        public async Task<ActionResult<bool>> AddLanguage(LanguageDTO language)
        {
            await languageBL.Add(language);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateLanguage/{id}")]
        public async Task<ActionResult<LanguageDTO>> UpdateLanguage(LanguageDTO language, int id)
        {
            return Ok(await languageBL.Update(language, id));
        }
        [HttpDelete]
        [Route("DeleteLanguage/{id}")]
        public async Task<ActionResult<bool>> DeleteLanguage(int id)
        {
            await languageBL.Delete(id);
            return Ok();
        }
    }
}
