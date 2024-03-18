using MassTransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MassTransitRabbitMQ.Contract.IntegretionEvents;

namespace MassTransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events
{
    // Đây là 1 Consumer: Lắng nghe và consume event từ DomainEvent.SmsNotificationEvent (producer: người gửi -> Exchange -> Queue -> đây)
    public class SendSmsWhenReceivedSmsEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
    {
        public SendSmsWhenReceivedSmsEventConsumer()
        {

        }
    }
}
