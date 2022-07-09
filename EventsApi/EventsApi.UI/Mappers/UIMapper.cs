using AutoMapper;
using EventsApi.BusinessLogic.DTO;
using EventsApi.Domain.Entities;

namespace EventsApi.UI.Mappers
{
    public class UIMapper : Profile
    {
        public UIMapper()
        {
            CreateMap<CreateEventModel, EventEntity>().ReverseMap();
            CreateMap<UpdateEventModel, EventEntity>().ReverseMap();
        }
    }
}
