using Rbt.Publisher.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kuyruğa Gidiliyor");
            foreach (MarketCarMovementModel item in MarketCarMovementModel.GetAllMarketCarMovement(10))
            {
                SendingJobOperation.SendinggJob(item);
            }
            Console.ReadLine();
        }
    }
}
