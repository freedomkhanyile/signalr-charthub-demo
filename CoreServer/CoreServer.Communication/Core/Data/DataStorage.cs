using CoreServer.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServer.Communication.Core.Data
{
    public static class DataStorage
    {
        public static List<WelcomeDocument> GetWelcomeDocuments() =>
            new List<WelcomeDocument>
            {
                new WelcomeDocument
                {
                    Title = "Welcome to our platform",
                    Description = "We hope your stay with us is a good one",
                    Email = "uuzo.art@gmail.com",
                    RecieverName ="Mr Freedom Khanyile",
                    SenderName = "Mr Cars Rep | Sessions powered by {DateTime.UtcNow.Year}©copyright Ndu Systems PTY LTD",
                    FullName = "Mr Uuzo Art",
                    Message = "We welcome you to our system, we are going to keep you on the road and always at lower comperative costs.",
                    SourceSystem ="Car-Rep-Ses",
                    SourceSystemEmail = "officialmarketing@car-rep-session.com",
                },   
                new WelcomeDocument
                {
                    Title = "Welcome to your notifier",
                    Description = "This is a system generated document as a forms of automated communications engine.",
                    Email = "ndu.systems@gmail.com",
                    RecieverName ="Ndu Systems | Principal",
                    SenderName = $"Core Server {DateTime.UtcNow.Year}©copyright Ndu Systems PTY LTD",
                    FullName = "Ndu Systems",
                    Message = "We welcome you to our system, we are going to keep you on the road and always at lower comperative costs.",
                    SourceSystem ="Core server",
                    SourceSystemEmail = "notifier@ndu-systems.net",
                }
            };
    }
}
