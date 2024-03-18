using MassTransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MassTransitRabbitMQ.Contract.IntegretionEvents;

namespace MassTransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events
{
    // Đây là 1 Consumer: Lắng nghe và consume event từ DomainEvent.EmailNotificationEvent (producer: người gửi -> Exchange -> Queue -> đây)
    public class SendEmailWhenReceivedEmailEventConsumer : Consumer<DomainEvent.EmailNotificationEvent>
    {
        public SendEmailWhenReceivedEmailEventConsumer()
        {

        }
    }
}
