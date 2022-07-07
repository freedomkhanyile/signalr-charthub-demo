using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServer.Communication.Models
{
    public class PeriodicReminderDocument : DocumentBase
    {
        public string Topic { get; set; }
        public DateTime ReminderDate { get; set; }
        public DateTime NextReminderDate { get; set; }
    }
}
