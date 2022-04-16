using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Configuration
{
    public class RabbitMQConfiguration
    {
        public static string Hostname
        {
            get
            {
                return ConfigurationManager.AppSettings["HostName"].ToString();
            }
        }

        public string Port
        {
            get
            {
                return ConfigurationManager.AppSettings["Port"].ToString();
            }
        }
        public string Username
        {
            get
            {
                return ConfigurationManager.AppSettings["Username"].ToString();
            }
        }
    }
}
