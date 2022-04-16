using Newtonsoft.Json;
using RabbitMQ.Client;
using Rbt.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Publisher.Business
{
    public class SendingJobOperation
    {
        public static void SendinggJob(MarketCarMovementModel carMovement)
        {
            //ConnectionFactory:RabbitMQ hostuna bağlanmak için kullanılır , Credantial ve port bilgileri girilebilir
            //var factory = new ConnectionFactory() { HostName = "localhost" };//ConnectionFactory
             var factory = new ConnectionFactory() { HostName = RabbitMQConfiguration.Hostname };
            using (IConnection connection = factory.CreateConnection()) //Connection,
            {
                using (IModel channel = connection.CreateModel()) //Channel veya Session,RabbitMQ üzerinde yeni bir channel yaratılır.
                {
                    //QueueDeclare ile Kuyruk tanımlanır 
                    #region Excahnge Türleri
                    //Direct Exchnage : Routing Key belirlenip buna göre en uygun Queue gidilir 
                    //Fanout exchange,: Rotink key ile çalışmaz Brodcast yayınlarında kullanılır ,real-time spor haberleri gibi yayınlarda kullanılır 
                    //Topic Exchange,
                    //Headers Exchange 
                    #endregion

                    channel.QueueDeclare
                    (
                      queue: "CarMovement",
                      durable: false, // Ramde tutulacak 
                      exclusive: false,
                      autoDelete: true, 
                      arguments: null
                    );

                    string message = JsonConvert.SerializeObject(carMovement); //Json'a dönüştürdük
                    var bodyMessage = Encoding.UTF8.GetBytes(message); //Byta dizisine çevrilir 

                    //Publish Etme , Kuyruğa gönderme kısmı 
                    channel.BasicPublish(
                                         exchange: "",
                                         routingKey: "CarMovement",
                                         basicProperties: null,
                                         body: bodyMessage
                                         );

                    Console.WriteLine($"{carMovement.CarId} Numaralı Araba Haraketi Gönderildi , X Kordiantı :{carMovement.CordianteX} , Y Kordiantı :{carMovement.CordianteY} ");
                }
            }

            Console.WriteLine("İlgili araba gönderildi");

        }
    }
}
