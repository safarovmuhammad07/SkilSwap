using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class RequestController(IRequestService requestService):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Request>>> Get()
    {
        return requestService.GetRequestsAsync();
    }

    [HttpGet("{id}")]
    public Task<Responce<Request>> Get(int id)
    {
        return requestService.GetRequestByIdAsync(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(Request request)
    {
        return requestService.AddRequestAsync(request);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put( Request request)
    {
        return requestService.AddRequestAsync(request);
    }

    [HttpDelete]
    public Task<Responce<bool>> Delete(int id)
    {
        return requestService.DeleteRequestAsync(id);
    }
    
}