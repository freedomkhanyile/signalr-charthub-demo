using CoreServer.Communication.Core.Data;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CoreServer.Controllers
{
    [Route("api/pdf-documents")]
    [ApiController]
    public class PDFDocumentsController : ControllerBase
    {
        private readonly ILogger<PDFDocumentsController> _logger;
        private readonly IConverter _converter;
        public PDFDocumentsController(ILogger<PDFDocumentsController> logger, IConverter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        [HttpGet("welcome-document")]
        public ActionResult<int> GenerateWelcomeDocument()
        {
            try {
                var globalSettings = new GlobalSettings {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = @"C:\PDFCreator\Welcome_Report.pdf"
                };

                var htmlDocuments = WelcomeDocumentTemplateGenerator.GetDocumentHtmls();
                var documentCount = 0;
                foreach (var htmlContent in htmlDocuments) {
                    var objectSettings = new ObjectSettings {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontName = "Montserrat", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                        FooterSettings = { FontName = "Montserrat", FontSize = 9, Line = true, Center = $"{DateTime.UtcNow.Year}©copyright Core Server " }
                    };
                    globalSettings.Out = @"C:\PDFCreator\Welcome_document_" + DateTime.UtcNow.Year + "_" + documentCount + ".pdf";
                    var pdf = new HtmlToPdfDocument() {
                        GlobalSettings = globalSettings,
                        Objects = { objectSettings }
                    };
                    _converter.Convert(pdf);
                    documentCount++;
                }
                return documentCount;
            }
            catch (System.Exception ex) {

                _logger.LogError(ex.Message);

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
