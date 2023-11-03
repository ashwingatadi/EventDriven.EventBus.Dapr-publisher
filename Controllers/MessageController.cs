using EventDriven.EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        readonly IEventBus eventBus;
        readonly ILogger<MessageController> logger;

        public MessageController(IEventBus eventBus, ILogger<MessageController> logger)
        {
            this.eventBus = eventBus;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string message)
        {
            await this.eventBus.PublishAsync(new MessageCreatedEvent(message), "test-eventbus");
            this.logger.LogInformation(message);
            return Ok(message);
        }
    }
}
