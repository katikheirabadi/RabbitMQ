using RabbitMQ.Client;

namespace General
{
    public static class GeneralHelper
    {
        public static IModel CreateChannel()
        {
            return new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest",
                Port = 5762
            }.CreateConnection().CreateModel();
        }
    }
}