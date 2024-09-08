using General;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json.Serialization;

namespace Consumer
{
    public class ConsumerService : IConsumer
    {
        public IModel Channel { get; set; }
        public EventingBasicConsumer Consumer { get; set; }


        public ConsumerService()
        {
            Channel = GeneralHelper.CreateChannel();
            Consumer = new EventingBasicConsumer(Channel);
        }

        public void Consume()
        {
            var result = new List<object>();
            Consumer.Received += (model, args) =>
            {
                var body = args.Body.ToArray();
                var data = Encoding.UTF8.GetString(body);

                Channel.BasicAck(args.DeliveryTag, false);

                result.Add(data);
                var jsonResult = JsonConvert.SerializeObject(result);
                var path = $"E:\\C#\\RabbitMQ\\Consumerr\\Files\\{DateTime.Now.Ticks}.txt";
                File.Create(path);
                using (var stream2 = new StreamWriter(path))
                {
                    stream2.Write(jsonResult);
                }
            };

            Channel.BasicConsume(queue:"first",autoAck:false,Consumer);
          
        }
    }
}