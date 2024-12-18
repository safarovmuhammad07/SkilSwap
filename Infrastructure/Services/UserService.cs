using System.Net;
using Dapper;
using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class UserService(DapperContext context):IUserService
{
    public async Task<Responce<List<User>>> GetUsersAsync()
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from users";
        var res = await context.GetConnection().QueryAsync<User>(sql);
        return new Responce<List<User>>(res.ToList());
    }

    public async Task<Responce<User>> GetUserByIdAsync(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from users where id = @id";
        var res = await connect.QueryFirstOrDefaultAsync<User>(sql, new { id });
        return new Responce<User>(res);
    }

    public async Task<Responce<bool>> AddUserAsync(User user)
    {
        await using var connect = context.GetConnection();
        const string sql = "insert into users (Fullname, Email,Phone,City, CreatedAt) values (@Fullname, @Email, @Phone, @City, current_date)";
        var res = await connect.ExecuteAsync(sql, user);
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error.") : new Responce<bool>(HttpStatusCode.Created, "User added.");
    }

    public async Task<Responce<bool>> UpdateUserAsync(User user)
    {
        await using var connect = context.GetConnection();
        const string sql = "update users set FullName=@Fullname, Email=@Email, Phone=@Phone, City=@City, CreatedAt=current_date  where Userid = @id";
        var res = await connect.ExecuteAsync(sql, user);
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error.") : new Responce<bool>(HttpStatusCode.OK, "User Updated.");

    }

    public async Task<Responce<bool>> DeleteUserAsync(int user)
    {
        await using var connect = context.GetConnection();
        const string sql = "delete from users where Userid = @id";
        var res = await connect.ExecuteAsync(sql, user);
        return res ==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error.")
            : new Responce<bool>(HttpStatusCode.OK, "User Deleted.");
    }
    
}