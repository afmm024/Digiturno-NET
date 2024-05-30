using DigiturnoAPI.Constanst;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Models;
using Microsoft.OpenApi.Extensions;
using MongoDB.Driver;

namespace DigiturnoAPI.Services
{
    public class ParamRepository : IParamRepository
    {

        private readonly IMongoCollection<Param> _params;

        public ParamRepository(DatabaseProvider databaseProvider)
        {
            _params = databaseProvider.GetAccess().GetCollection<Param>("params");
        }

        public async Task<Param> GetConsecutiveAsync(bool isHandicapped)
        {
            if (isHandicapped)
            {
                return await _params.Find<Param>(param => param.Type.Equals(TypeTicket.HandicappedQueue)).FirstOrDefaultAsync();
            }
            return await _params.Find<Param>(param => param.Type.Equals(TypeTicket.TicketQueue)).FirstOrDefaultAsync();
        }

        public async Task UpdateConsecutiveAsync(bool isHandicapped)
        {
            if (isHandicapped)
            {
                Param paramHandicapped = await GetConsecutiveAsync(true);
                paramHandicapped.Value += 1;
                await _params.ReplaceOneAsync(param => param.Id!.Equals(param.Id), paramHandicapped);
            }
            Param param = await GetConsecutiveAsync(false);
            param.Value += 1;
            await _params.ReplaceOneAsync(param => param.Id!.Equals(param.Id), param);
        }

        public async Task<Param> CreateParamAsync()
        {
            Param param = new Param() {
                CreatedAt = DateTime.Now,
                Type = TypeTicket.HandicappedQueue,
                Value = 1
            };
            return param;
        }
    }
}
