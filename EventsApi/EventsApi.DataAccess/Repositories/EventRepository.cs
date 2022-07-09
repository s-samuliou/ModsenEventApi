using EventsApi.DataAccess.Data;
using EventsApi.DataAccess.Interfaces;
using EventsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsApi.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(EventEntity @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Events.FindAsync(id);
            if (itemToRemove is null)
                throw new NullReferenceException();

            _context.Events.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<EventEntity> Get(int id) =>
            await _context.Events.FindAsync(id);

        public async Task<IEnumerable<EventEntity>> GetAll() =>
            await _context.Events.ToListAsync();

        public async Task Update(EventEntity @event)
        {
            var itemToUpdate = await _context.Events.FindAsync(@event.Id);
            if (itemToUpdate is null)
                throw new NullReferenceException();
            itemToUpdate.Name = @event.Name;
            itemToUpdate.Description = @event.Description;
            itemToUpdate.Plan = @event.Plan;
            itemToUpdate.Organizer = @event.Organizer;
            itemToUpdate.Speaker = @event.Speaker;
            itemToUpdate.EventTime = @event.EventTime;
            itemToUpdate.EventPlace = @event.EventPlace;

            await _context.SaveChangesAsync();
        }
    }
}
