using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;

namespace logging_service
{
    class LoggingService
    {

        /// <summary>Name of exchange</summary>
        private static string ExchangeName = "order_exchange";

        /// <summary>Routing key for create order procedure to consume</summary>
        private static string CreateOrderRoutingKey = "create_order";

        /// <summary>Name for queue for logging service</summary>
        private static string LoggingServiceQueueName = "logging_queue";

        /// <summary>Path to log file to write logs on orders to</summary>
        private static string logFilePath = "log.txt";

        /// <summary>
        /// Consumes orders from exchange
        /// Logs orders to logfile
        /// </summary>
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel()) {
                channel.ExchangeDeclare(ExchangeName, "direct", true);
                channel.QueueDeclare(LoggingServiceQueueName, true);
                channel.QueueBind(LoggingServiceQueueName, ExchangeName, CreateOrderRoutingKey);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) => {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x] Logging {message} to {logFilePath}\n");
                    LogToFile(message);
                };
                channel.BasicConsume(LoggingServiceQueueName, true, consumer);
                Console.WriteLine("Logging service running");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Logs data recieved e.g. customer order to file log.txt
        /// Both error and successful orders
        /// </summary>
        /// <param name="message">request body of post request to api gateway</param>
        public static void LogToFile(string message)
        {
            using (var file = new StreamWriter(logFilePath, true))
            {
                file.WriteLine($"Log: {message}\n");
            }
        }
    }
}
