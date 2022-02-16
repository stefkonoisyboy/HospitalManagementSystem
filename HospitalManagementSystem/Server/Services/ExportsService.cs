using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Payments;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class ExportsService : IExportsService
    {
        public MemoryStream CreatePdf(IEnumerable<AllPaymentsByDoctorIdViewModel> payments)
        {
            if (payments == null)
            {
                throw new ArgumentException("Data cannot be null!");
            }

            // Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                // Add page to the pdf document
                PdfPage page = pdfDocument.Pages.Add();

                // Create new Font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                // Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Payments", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                // Create a PDF
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                // Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

                // Assing Data Source
                pdfGrid.DataSource = payments.ToList();

                pdfGrid.Style.Font = contentFont;

                // Draw PDF Grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }

        public MemoryStream CreatePdfSingle(PaymentByIdViewModel payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("Data cannot be null!");
            }

            // Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                // Add page to the pdf document
                PdfPage page = pdfDocument.Pages.Add();

                // Create new Font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                // Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Payments", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                // Create a PDF
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                // Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

                // Assing Data Source
                pdfGrid.DataSource = payment;

                pdfGrid.Style.Font = contentFont;

                // Draw PDF Grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }
    }
}
