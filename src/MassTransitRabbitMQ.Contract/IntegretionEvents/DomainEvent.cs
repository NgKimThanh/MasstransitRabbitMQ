using MassTransitRabbitMQ.Contract.Abstractions.Messages;

namespace MassTransitRabbitMQ.Contract.IntegretionEvents
{
    public static class DomainEvent
    {
        // Record Email publish (gửi) đến Exchange
        public record EmailNotificationEvent : INotificationEvent 
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }

        // Record SMS publish (gửi) đến Exchange
        public record SmsNotificationEvent : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }
    }
}
