using CoreServer.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServer.Communication.Core.Data
{
    public static class WelcomeDocumentTemplateGenerator
    {
        public static List<string> GetDocumentHtmls()
        {
            var documents = DataStorage.GetWelcomeDocuments();
            var convertedHtmlDocuments = new List<string>();
            foreach (var item in documents)
            {
                convertedHtmlDocuments.Add(item.GetHTMLString());
            }

            return convertedHtmlDocuments;

        }
        public static string GetHTMLString(this WelcomeDocument document)
        {

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>");
            sb.AppendFormat(@"
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <div>
                                <p>{0}</p>
                                </div>
                                <div>
                                <p>{1}</p>
                                </div>", document.FullName, document.Message);
            sb.Append(@"
                            </body>
                        </html>");

            return sb.ToString();
        }
    }

}
