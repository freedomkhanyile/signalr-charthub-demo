using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServer.Communication.Models
{
    public abstract class DocumentBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SourceSystem { get; set; }
        public string SourceSystemEmail { get; set; }
        public string Message { get; set; }
        public string RecieverName { get; set; }
        public string Email { get; set; } // When we wish to send.
        public string SenderName { get; set; }

    }


}
