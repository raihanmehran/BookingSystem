// See https://aka.ms/new-console-template for more information
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the Ticketing Service");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "passPO",
    VirtualHost = "/",
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("bookings", durable: true, exclusive: true);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    System.Console.WriteLine($"New ticket processing initiated {message}");
};

channel.BasicConsume("bookings", true, consumer);

Console.ReadKey();