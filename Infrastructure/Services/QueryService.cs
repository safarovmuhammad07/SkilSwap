using System.Net;
using Dapper;
using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class QueryService(DapperContext context) : IQueryService
{
    public async Task<Responce<List<User>>> GetUsersOfferingSkillAsync(int skillId)
    {
        await using var connect = context.GetConnection();
        const string sql = @" SELECT DISTINCT u.*   FROM Users u JOIN Skills s ON u.Id = s.UserId  WHERE s.Id = @SkillId";
        var res = await connect.QueryAsync<User>(sql, new { SkillId = skillId });
        return new Responce<List<User>>(res.ToList());
    }

    public async Task<Responce<List<User>>> GetUsersExchangingSkillsAtTimeAsync(DateTime exchangeTime)
    {
        await using var connect = context.GetConnection();
        const string sql = @" SELECT DISTINCT u.*  FROM Users u JOIN Requests r ON u.Id = r.FromUserId OR u.Id = r.ToUserId WHERE r.CreatedAt <= @ExchangeTime AND r.UpdatedAt >= @ExchangeTime";
        var res = await connect.QueryAsync<User>(sql, new { ExchangeTime = exchangeTime });
        return new Responce<List<User>>(res.ToList());
    }

    public async Task<Responce<List<Skill>>> GetMostPopularSkillsAsync(int topCount)
    {
        await using var connect = context.GetConnection();
        const string sql = @"SELECT s.*, COUNT(r.RequestedSkillId) AS RequestCount FROM Skills s  LEFT JOIN Requests r ON s.Id = r.RequestedSkillId GROUP BY s.Id ORDER BY RequestCount DESC LIMIT @TopCount";
        var res = await connect.QueryAsync<Skill>(sql, new { TopCount = topCount });
        return new Responce<List<Skill>>(res.ToList());
    }
}