using MassTransit;
using MassTransit.Testing;
using MassTransitRabbitMQ.Contract.Constants;
using MassTransitRabbitMQ.Contract.IntegretionEvents;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitRabbitMQ.Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ProducersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        // Hàm publish (gửi) event đến Exchange
        [HttpPost(Name = "publish-sms-notification")]
        public async Task<IActionResult> PublishSmsNotificationEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.SmsNotificationEvent
            {
                Id = Guid.NewGuid(),
                Description = "Sms description",
                Name = "Sms notification",
                TimeStamp = DateTime.Now,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.sms,
            });
            return Accepted();
        }
    }
}
