using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryController(IQueryService queryService) : ControllerBase
{
    [HttpGet("{OfferingSkill}")]
    public Task<Responce<List<User>>> GetUsersOfferingSkillAsync(int skillId)
    {
        return queryService.GetUsersOfferingSkillAsync(skillId);
    }

    [HttpGet("{ExchangingSkills}")]
    public Task<Responce<List<User>>> GetUsersExchangingSkillsAtTimeAsync(DateTime exchangeTime)
    {
        return queryService.GetUsersExchangingSkillsAtTimeAsync(exchangeTime);
    }

    [HttpGet("{MostPopularSkill}")]
    public Task<Responce<List<Skill>>> GetMostPopularSkillsAsync(int topCount)
    {
        return queryService.GetMostPopularSkillsAsync(topCount);
    }
}
