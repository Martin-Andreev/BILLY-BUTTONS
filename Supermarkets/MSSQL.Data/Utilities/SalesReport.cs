namespace MSSQL.Data.Utilities
{
    public class SalesReport
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public double TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }
    }
}
