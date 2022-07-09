using AutoMapper;
using EventsApi.BusinessLogic.DTO;
using EventsApi.DataAccess.Interfaces;
using EventsApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsApi.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventEntity>> GetEvent(int id)
        {
            var @event = await _eventRepository.Get(id);
            return @event switch
            {
                null => NotFound(),
                _ => Ok(@event)
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventEntity>>> GetEvents()
        {
            var events = await _eventRepository.GetAll();
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(CreateEventModel createEventDto)
        {
            CreateEventModel eventApi = new CreateEventModel()
            {
                Name = createEventDto.Name,
                Description = createEventDto.Description,
                Plan = createEventDto.Plan,
                Organizer = createEventDto.Organizer,
                Speaker = createEventDto.Speaker,
                EventTime = createEventDto.EventTime,
                EventPlace = createEventDto.EventPlace
            };

            await _eventRepository.Add(_mapper.Map<EventEntity>(eventApi));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _eventRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateEventModel updateEventDto)
        {
            UpdateEventModel eventApi = new UpdateEventModel()
            {
                Id = id,
                Name = updateEventDto.Name,
                Description = updateEventDto.Description,
                Plan = updateEventDto.Plan,
                Organizer = updateEventDto.Organizer,
                Speaker = updateEventDto.Speaker,
                EventTime = updateEventDto.EventTime,
                EventPlace = updateEventDto.EventPlace
            };

            await _eventRepository.Update(_mapper.Map<EventEntity>(eventApi));
            return Ok();
        }
    }
}
