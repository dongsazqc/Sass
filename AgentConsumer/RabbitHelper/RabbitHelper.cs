using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace AgentConsumer.Service
{
    /// <summary>
    /// Nơi kết nối đến RabbitMQ
    /// </summary>
    public static class RabbitHelper
    {
        public static (IConnection, IModel) Connect()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "103.5.209.131",
                Port = 5672,
                UserName = "nextcrm",
                Password = "123456aa",
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return (connection, channel);
        }
    }

}
