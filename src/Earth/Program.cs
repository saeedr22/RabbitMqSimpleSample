
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
var connection = factory.CreateConnection();
var chanel = connection.CreateModel();

chanel.QueueDeclare("inbox", false, false, false, null);
var message = "";
while (message == string.Empty)
{
    Console.WriteLine("please enter message");
    message = Console.ReadLine();
    var body = Encoding.UTF8.GetBytes(message);

    chanel.BasicPublish("", "inbox", null, body);
    Console.WriteLine("Message Sent from earth");
    message = "";
}


