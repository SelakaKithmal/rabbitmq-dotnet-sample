using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory {HostName="localhost"};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue:"letterbox", durable:false,exclusive:false,autoDelete:false, arguments:null);

var msg = "this is my first message";

var encodedMsg = Encoding.UTF8.GetBytes(msg);

channel.BasicPublish("", "letterbox", null, encodedMsg);

Console.WriteLine($"Message published{msg}");