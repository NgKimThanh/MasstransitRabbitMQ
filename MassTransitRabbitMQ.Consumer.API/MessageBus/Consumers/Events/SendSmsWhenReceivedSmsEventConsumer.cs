using MassTransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MassTransitRabbitMQ.Contract.IntegretionEvents;

namespace MassTransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events
{
    // Đây là 1 Queue: Lắng nghe và consume event từ DomainEvent.SmsNotificationEvent (producer: người gửi)
    public class SendSmsWhenReceivedSmsEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
    {
        public SendSmsWhenReceivedSmsEventConsumer()
        {

        }
    }
}
