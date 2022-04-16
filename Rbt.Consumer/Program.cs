using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rbt.Consumer.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IncomingJobOperation.IncomingJob();
            Console.ReadLine();
        }
    }
}
