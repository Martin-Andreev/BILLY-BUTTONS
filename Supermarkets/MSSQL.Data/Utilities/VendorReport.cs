namespace MSSQL.Data.Utilities
{
    using System.Collections.Generic;

    public class VendorReport
    {
        public string VendorName { get; set; }

        public List<SaleReport> Sales { get; set; }
    }
}
