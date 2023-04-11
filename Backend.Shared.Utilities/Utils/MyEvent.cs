using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Utilities.Utils
{
    public class MyEvent : IEventHandler
    {
        private readonly byte[] headerImage;
        private readonly byte[] footerImage;

        public MyEvent(byte[] headerImage, byte[] footerImage)
        {
            this.headerImage = headerImage;
            this.footerImage = footerImage;
        }


        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;

            PdfPage page = docEvent.GetPage();

            Rectangle pageSize = page.GetPageSize();

            PdfDocument pdfDoc = docEvent.GetDocument();

            PdfCanvas pdfCanvas = new PdfCanvas(page.GetLastContentStream(), page.GetResources(), pdfDoc);

            ImageData header = ImageDataFactory.Create(headerImage);
            ImageData footer = ImageDataFactory.Create(footerImage);

            pdfCanvas.AddImage(header, 50, 710, 495, true);
            pdfCanvas.AddImage(footer, 175, 40, 250, true);


        }

    }
}


