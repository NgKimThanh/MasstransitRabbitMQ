using MassTransit;
using MassTransitRabbitMQ.Contract.Abstractions.Messages;

namespace MassTransitRabbitMQ.Consumer.API.Abstractions.Messages
{
    // abstract class Consumer kế thừa INotificationEvent từ Contract.Abstractions.Messages để routing từ Contract.Abstractions.Messages đến đây
    public abstract class Consumer<TMessage> : IConsumer<TMessage>
        where TMessage : class, INotificationEvent
    {
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            throw new NotImplementedException();
        }
    }
}
