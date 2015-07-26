namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Expense
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [Required]
        public virtual DateTime ExpenseDate { get; set; }

        [Required]
        public decimal ExpenseSum { get; set; }
    }
}
