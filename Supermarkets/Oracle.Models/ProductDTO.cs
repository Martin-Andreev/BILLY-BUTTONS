namespace Oracle.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDTO
    {
       public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int VendorId { get; set; }

        public virtual VendorDTO Vendor { get; set; }

        public int MeasureId { get; set; }

        public virtual MeasureDTO Measure { get; set; }
    }
}
