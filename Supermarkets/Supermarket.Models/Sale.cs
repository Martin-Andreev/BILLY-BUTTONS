namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        public int SupermarketId { get; set; }

        public virtual Supermarket Supermarket { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
