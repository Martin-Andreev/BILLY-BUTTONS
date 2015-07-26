namespace MSSQL.Data.Utilities
{
    using System.Collections.Generic;

    public class VendorSalesReport
    {
        public string Vendor { get; set; }

        public IEnumerable<SaleReport> VendorReports { get; set; } 
    }
}
