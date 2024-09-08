using Consumer;
using Microsoft.AspNetCore.Mvc;
using Producer;

namespace RabbitApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private IConsumer consumer;
        private IProducer<object> producer;
        
        public RabbitMQController()
        {
            consumer = new ConsumerService();
            producer = new Producer<object>();
        }

        [HttpGet]
        public string Consume()
        {
            consumer.Consume();
            return "Consume is done";
        }


        [HttpPost]
        public string Publish(string value)
        {
            producer.Publish(value);
            return "Publish i done";
        }


    }
}
