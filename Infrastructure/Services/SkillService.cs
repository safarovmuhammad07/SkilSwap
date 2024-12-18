using System.Net;
using Dapper;
using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class SkillService(DapperContext context):ISkillService  
{
    public async Task<Responce<List<Skill>>> GetSkillsAsync()
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from Skills";
        var res= connect.QueryAsync<Skill>(sql);
        return new Responce<List<Skill>>(res.Result.ToList());
    }
    
    
    public async Task<Responce<Skill>> GetSkillByIdAsync(int skillId)
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from Skills where Id = @Id";
        var res = await connect.QueryFirstOrDefaultAsync<Skill>(sql, new { Id = skillId });
        return new Responce<Skill>(res);
    }

    public async Task<Responce<bool>> AddSkillAsync(Skill skill)
    {
        await using var connect = context.GetConnection();
        const string sql = "insert into Skills (UserId, Title, Description,CreatedAt) values (@UserId, Title, @Description,@CreatedAt)";
       var res = await connect.ExecuteAsync(sql, skill);
       return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError,"Internal Server Error") : new Responce<bool>(HttpStatusCode.Created, "Added");
    }

    public async Task<Responce<bool>> UpdateSkillAsync(Skill skill)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from Skills where Id = @Id";
        var res = await connect.ExecuteAsync(sql, skill);
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError,"Skill has Server Error") : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public async Task<Responce<bool>> DeleteSkillAsync(int skill)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from Skills where Id = @Id";
        var res = await connect.ExecuteAsync(sql, skill);
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Skill has Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted");
    }
}