namespace SupermarketClient.Exporters
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    using MSSQL.Data.Utilities;

    public static class ExportToXML
    {
        public static void ExportSalesByVendorsReport(List<VendorSalesReport> salesReports)
        {
            const string fileName = "../../Exported-Files/Sales-by-Vendors-Report.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");
                foreach (var vendorSalesReport in salesReports)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", vendorSalesReport.Vendor);
                    WriteVendorSales(vendorSalesReport, writer);
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }

        private static void WriteVendorSales(VendorSalesReport vendorSalesReport, XmlTextWriter writer)
        {
            const string saleDateFormat = "dd-MMM-yyy";

            foreach (var vendorReport in vendorSalesReport.VendorReports)
            {
                writer.WriteStartElement("summary");
                writer.WriteAttributeString("date", vendorReport.SaleDate.Value.ToString(saleDateFormat));
                writer.WriteAttributeString("total-sum", vendorReport.TotalSum.ToString(CultureInfo.InvariantCulture));
                writer.WriteEndElement();
            }
        }
    }
}
