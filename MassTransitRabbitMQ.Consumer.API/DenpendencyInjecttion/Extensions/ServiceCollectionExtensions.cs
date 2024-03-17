using MassTransit;
using MassTransitRabbitMQ.Consumer.API.DenpendencyInjecttion.Options;
using MassTransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events;
using System.Reflection;

namespace MassTransitRabbitMQ.Consumer.API.DenpendencyInjecttion.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Khai báo DI kết nối đến exchange của rabbitMQ (Consumer)
        public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);

            // DI Masstransit
            services.AddMassTransit(mt =>
            {
                // Add Consumer
                //mt.AddConsumer<SendSmsWhenReceivedSmsEventConsumer>(); // Add từng consumer vào masstransit
                mt.AddConsumers(Assembly.GetExecutingAssembly()); // Add tất consumer vào masstransit

                // Using RabbitMQ
                mt.UsingRabbitMq((context, bus) =>
                {
                    // Kết nối đến host của RabbitMQ đã cấu hình
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, c =>
                    {
                        c.Username(masstransitConfiguration.UserName);
                        c.Password(masstransitConfiguration.Password);
                    });

                    // Cấu hình Endpoint để nhận đc consumer
                    bus.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
