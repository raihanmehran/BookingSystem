using System.Text;
using System.Text.Json;
using BookingSystem.Api.Services.Interfaces;
using RabbitMQ.Client;

namespace BookingSystem.Api.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "passPO",
                VirtualHost = "/",
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // channel.QueueDeclare("bookings", durable: true, exclusive: true);
            channel.QueueDeclare("bookings", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "bookings", body: body);
        }
    }
}