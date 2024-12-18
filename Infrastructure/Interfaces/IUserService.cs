using DoMain.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<Responce<List<User>>> GetUsersAsync();
    Task<Responce<User>> GetUserByIdAsync(int id);
    Task<Responce<bool>> AddUserAsync(User user);
    Task<Responce<bool>> UpdateUserAsync(User user);
    Task<Responce<bool>> DeleteUserAsync(int user);
}