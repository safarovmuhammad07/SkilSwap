using DoMain.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IRequestService
{
    Task<Responce<List<Request>>> GetRequestsAsync();
    Task<Responce<Request>> GetRequestByIdAsync(int id);
    Task<Responce<bool>> AddRequestAsync(Request request);
    Task<Responce<bool>> UpdateRequestAsync(Request request);
    Task<Responce<bool>> DeleteRequestAsync(int id);
}