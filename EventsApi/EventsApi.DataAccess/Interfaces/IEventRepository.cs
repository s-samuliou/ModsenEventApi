using EventsApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsApi.DataAccess.Interfaces
{
    public interface IEventRepository
    {
        public Task<EventEntity> Get(int id);

        public Task<IEnumerable<EventEntity>> GetAll();

        public Task Add(EventEntity @event);

        public Task Delete(int id);

        public Task Update(EventEntity @event);
    }
}
