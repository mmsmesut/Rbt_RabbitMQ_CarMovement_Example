using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Database.Entity
{
    public class MarketCarMovement
    {
        [Key]
        public int CarId { get; set; }

        public string CarName { get; set; }

        public int CordianteX { get; set; }

        public int CordianteY { get; set; }

        public DateTime CreaDate { get; set; }

    }
}
