using System.Net;
using Dapper;
using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class RequestService(DapperContext context) : IRequestService
{
    public async Task<Responce<List<Request>>> GetRequestsAsync()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from Requests";
        var res = connect.QueryAsync<Request>(sql);
        return new Responce<List<Request>>(res.Result.ToList());
    }

    public async Task<Responce<Request>> GetRequestByIdAsync(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from Requests where Id = @Id";
        var res = await connect.QueryFirstOrDefaultAsync<Request>(sql, new { Id = id });
        return new Responce<Request>(res);
    }

    public async Task<Responce<bool>> AddRequestAsync(Request request)
    {
        await using var connect = context.GetConnection();
        const string sql = "Insert into Requests(FromUserId,ToUserId ,RequestedSkillId ,OfferedSkillId ,Status , CreatedAt , UpdatedAt ) values (@FromUserId,@ToUserId ,@RequestedSkillId ,@OfferedSkillId ,@Status , @CreatedAt , @UpdatedAt )";
        var res = await connect.ExecuteAsync(sql, request);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Created Successfully");
    }

    public async Task<Responce<bool>> UpdateRequestAsync(Request request)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update Requests set   FromUserId=@FromUserId, ToUserId =@ToUserId , RequestedSkillId =@RequestedSkillId  , OfferedSkillId =@OfferedSkillId , Status =@Status  , CreatedAt = current_date, UpdatedAt = current_date";
        var res = await connect.ExecuteAsync(sql, request);
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Responce<bool>(HttpStatusCode.OK, "Updated Successfully");
    }

    
    public async Task<Responce<bool>> DeleteRequestAsync(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from Requests where Id = @Id";
        var res = await connect.ExecuteAsync(sql, new { Id = id });
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Responce<bool>(HttpStatusCode.OK, "Deleted Successfully");
    }
}