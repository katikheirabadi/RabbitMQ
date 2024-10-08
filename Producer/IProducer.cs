﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public interface IProducer<T>
    {
        IModel Channel { get; set; }

        void Publish(T data);
    }
}
