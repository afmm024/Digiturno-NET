using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces;


public interface IParamsServices
{
    Task<List<Ticket>> Get();
    Task<Ticket> Get(string id);
    Task<Ticket> Create(Param param);
    Task Update(string id, Param paramIn);
    Task Remove(Param paramIn);
    Task Remove(string id);
}