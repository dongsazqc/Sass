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
        public static (IConnection, IModel) Connect(string host = "localhost", int port = 5672, string user = "guest", string pass = "guest")
        {
            var factory = new ConnectionFactory()
            {
                HostName = host,
                Port = port,
                UserName = user,
                Password = pass
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return (connection, channel);
        }
    }

}
