using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class SkillController(ISkillService skillService):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Skill>>> GetSkills()
    {
        return skillService.GetSkillsAsync();
    }

    [HttpGet("{id}")]
    public Task<Responce<Skill>> GetSkill(int id)
    {
        return skillService.GetSkillByIdAsync(id);
    }

    [HttpPost]
    public Task<Responce<bool>> AddSkill(Skill skill)
    {
        return skillService.AddSkillAsync(skill);
    }

    [HttpPut]
    public Task<Responce<bool>> UpdateSkill(Skill skill)
    {
        return skillService.UpdateSkillAsync(skill);
    }

    [HttpDelete]
    public Task<Responce<bool>> DeleteSkill(int id)
    {
        return skillService.DeleteSkillAsync(id);
    }
}