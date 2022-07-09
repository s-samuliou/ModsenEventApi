using AutoMapper;
using EventsApi.UI.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace EventsApi.DataAccess.DI
{
    public static class DUserInterfaceDi
    {
        public static void AddUserInterfaceLogic(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UIMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);
        }
    }
}
