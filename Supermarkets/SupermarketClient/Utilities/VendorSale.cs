namespace SupermarketClient.Utilities
{
    public class VendorSale
    {
        public VendorSale(string name, decimal incomes, decimal expenses, decimal totalTaxes, decimal financialResult)
        {
            this.Name = name;
            this.Incomes = incomes;
            this.Expenses = expenses;
            this.TotalTaxes = totalTaxes;
            this.FinancialResult = financialResult;
        }

        public string Name { get; set; }

        public decimal Incomes { get; set; }

        public decimal Expenses { get; set; }

        public decimal TotalTaxes { get; set; }

        public decimal FinancialResult { get; set; }
    }
}
