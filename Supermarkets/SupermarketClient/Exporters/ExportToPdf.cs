namespace SupermarketClient.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using MSSQL.Data.Utilities;

    public static class ExportToPdf
    {
        public static void ExportSalesToPdf(IList<AgregatedSalesReport> salesQuery)
        {
            PdfPTable salesInfoTable;
            var document = CreateDocument(out salesInfoTable);
            AddSalesToDocument(salesQuery, salesInfoTable);

            document.Add(salesInfoTable);
            document.Close();
        }

        private static Document CreateDocument(out PdfPTable salesInfoTable)
        {
            var document = new Document(PageSize.A4, 50, 50, 10, 10);

            var output = File.Create(Directory.GetCurrentDirectory() + @"..\..\..\Exported-Files\PdfReport.pdf");
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();

            salesInfoTable = new PdfPTable(5);
            salesInfoTable.TotalWidth = 100f;
            salesInfoTable.HorizontalAlignment = 0;
            salesInfoTable.SpacingBefore = 5;
            salesInfoTable.SpacingAfter = 5;
            salesInfoTable.DefaultCell.Border = 0;
            salesInfoTable.SetWidths(new float[] {3f, 1.5f, 2f, 3f, 1f});

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font normal = new Font(bfTimes, 10);
            Font bold = new Font(bfTimes, 11, Font.BOLD);

            PdfPCell cellHeader = new PdfPCell(new Phrase("Aggregated Sales Report"));
            cellHeader.Colspan = 5;
            cellHeader.HorizontalAlignment = 1;
            cellHeader.BackgroundColor = new BaseColor(135, 196, 28);
            cellHeader.PaddingTop = 10f;
            cellHeader.PaddingBottom = 10f;
            salesInfoTable.AddCell(cellHeader);

            salesInfoTable.AddCell(new Phrase("Product", bold));
            salesInfoTable.AddCell(new Phrase("Quantity", bold));
            salesInfoTable.AddCell(new Phrase("Unit Price", bold));
            salesInfoTable.AddCell(new Phrase("Location", bold));
            salesInfoTable.AddCell(new Phrase("Sum", bold));
            return document;
        }

        private static void AddSalesToDocument(IList<AgregatedSalesReport> salesQuery, PdfPTable salesInfoTable)
        {
            foreach (var sale in salesQuery)
            {
                salesInfoTable.AddCell(sale.ProductName);
                salesInfoTable.AddCell(Convert.ToDecimal(sale.TotalQuantitySold).ToString(CultureInfo.InvariantCulture));
                salesInfoTable.AddCell(Convert.ToDecimal(sale.UnitPrice).ToString(CultureInfo.InvariantCulture));
                salesInfoTable.AddCell(sale.Supermaket);
                salesInfoTable.AddCell(Convert.ToDecimal(sale.TotalIncomes).ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
