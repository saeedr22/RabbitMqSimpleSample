using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
var connection = factory.CreateConnection();
var chanel = connection.CreateModel();

chanel.QueueDeclare("inbox", false, false, false, null);
var consumer = new EventingBasicConsumer(chanel);
consumer.Received += ConsumerEvent_Received;
chanel.BasicConsume("inbox", true, consumer);
Console.ReadKey();
void ConsumerEvent_Received(object? sender, BasicDeliverEventArgs e)
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine(message);
}