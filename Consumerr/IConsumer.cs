using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public interface IConsumer
    {
        IModel Channel { get; set; }

        EventingBasicConsumer Consumer { get; set; }

        void Consume();
    }
}
