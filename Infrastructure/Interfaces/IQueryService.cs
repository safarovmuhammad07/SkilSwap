using DoMain.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IQueryService
{
    Task<Responce<List<User>>> GetUsersOfferingSkillAsync(int skillId);
    Task<Responce<List<User>>> GetUsersExchangingSkillsAtTimeAsync(DateTime exchangeTime);
    Task<Responce<List<Skill>>> GetMostPopularSkillsAsync(int topCount);
}