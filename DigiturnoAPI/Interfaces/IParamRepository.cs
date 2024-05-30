using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface IParamRepository
    {
        Task<Param> GetConsecutiveAsync(bool isHandicapped);
        Task UpdateConsecutiveAsync(bool isHandicapped);
        Task<Param> CreateParamAsync();
    }
}
