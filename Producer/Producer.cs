using General;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public class Producer<T> : IProducer<T>
    {
        public IModel Channel { get; set; }

        public Producer()
        {
            Channel = GeneralHelper.CreateChannel();
        }

        public void Publish(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var msg = Encoding.UTF8.GetBytes(json);

            Channel.BasicPublish(exchange: "", routingKey: "first",body:msg);
        }
    }
}
