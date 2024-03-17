using MassTransit;
using MassTransitRabbitMQ.Producer.API.DenpendencyInjecttion.Options;

namespace MassTransitRabbitMQ.Producer.API.DenpendencyInjecttion.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Khai báo DI kết nối đến exchange của rabbitMQ (Producer)
        public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);

            // DI Masstransit
            services.AddMassTransit(mt =>
            {
                // Using RabbitMQ
                mt.UsingRabbitMq((context, bus) =>
                {
                    // Kết nối đến host của RabbitMQ đã cấu hình
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
