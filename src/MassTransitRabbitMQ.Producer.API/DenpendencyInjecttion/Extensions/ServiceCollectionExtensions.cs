using MassTransit;
using MassTransitRabbitMQ.Producer.API.DenpendencyInjecttion.Options;

namespace MassTransitRabbitMQ.Producer.API.DenpendencyInjecttion.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, c =>
                    {
                        c.Username(masstransitConfiguration.UserName);
                        c.Password(masstransitConfiguration.Password);
                    });
                });
            });

            return services;
        }
    }
}
