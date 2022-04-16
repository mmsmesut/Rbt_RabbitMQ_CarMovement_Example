using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rbt.Configuration;
using Rbt.Database;
using Rbt.Database.Entity;
using Rbt.Publisher.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Consumer.Business
{
    internal class IncomingJobOperation
    {
        public static void IncomingJob()
        {
            MarketCarMovementDbContext context = new MarketCarMovementDbContext();

            var factory = new ConnectionFactory() { HostName = RabbitMQConfiguration.Hostname };
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {

                    channel.QueueDeclare
                    (
                      queue: "CarMovement",
                      durable: false, // Ramde tutulacak 
                      exclusive: false,
                      autoDelete: true,
                      arguments: null
                    );

                    #region Kuyruktan Mesajın Consume edilip Model'e Dönüştürülmesi, işlenmesi 
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());
                        MarketCarMovementModel marketCarMovement = JsonConvert.DeserializeObject<MarketCarMovementModel>(message);
                        
                        context.MarketCarMovements.Add(new MarketCarMovement 
                        { 
                          //CarId = marketCarMovement .CarId , 
                          CarName = marketCarMovement .CarName ,
                          CordianteX =  marketCarMovement.CordianteX ,
                          CordianteY = marketCarMovement.CordianteY ,
                          CreaDate = DateTime.Now
                        });

                        context.SaveChanges();

                        Console.WriteLine($"{marketCarMovement.CarId} Numaralı Araba Kuyruktan okundu , Uzaklık : {marketCarMovement.CalculatedDistance}");
                    };
                    #endregion

                    channel.BasicConsume
                    (
                         queue: "CarMovement",
                         autoAck: true,  // Mesaj alındıktan sonra kuyruktan silinmesini sağlar
                         consumer: consumer
                    );

                    Console.WriteLine("İşlem Tamam");
                    Console.ReadLine();
                }
            }
        }

    }
}
