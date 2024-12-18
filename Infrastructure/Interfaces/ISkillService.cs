using DoMain.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface ISkillService
{
    Task<Responce<List<Skill>>> GetSkillsAsync();
    Task<Responce<Skill>> GetSkillByIdAsync(int skillId);
    Task<Responce<bool>> AddSkillAsync(Skill skill);
    Task<Responce<bool>> UpdateSkillAsync(Skill skill);
    Task<Responce<bool>> DeleteSkillAsync(int skill);
    
}