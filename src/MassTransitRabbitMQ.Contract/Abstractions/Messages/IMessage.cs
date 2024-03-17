using MassTransit;

namespace MassTransitRabbitMQ.Contract.Abstractions.Messages
{
    [ExcludeFromTopology]
    public interface IMessage
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
