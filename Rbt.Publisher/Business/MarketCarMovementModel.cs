using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Publisher.Business
{
    public class MarketCarMovementModel
    {
        public int CarId { get; set; }

        public string CarName { get; set; }

        public int CordianteX { get; set; }

        public int CordianteY { get; set; }

        public int CalculatedDistance 
        {
            get
            {
                return CordianteX * 100 - CordianteY;
            }
        }

        public static List<MarketCarMovementModel> GetAllMarketCarMovement(int count)
        {
            List<MarketCarMovementModel> cars = new List<MarketCarMovementModel>();

            for (int i = 1; i <= count; i++)
            {
                cars.Add(new MarketCarMovementModel { CarId = i, CarName = $"Car{i}", CordianteX = new Random().Next(1,1000)+i, CordianteY = new Random().Next(1000, 10000)+i });
            }
            return cars;
        }
    }
}
