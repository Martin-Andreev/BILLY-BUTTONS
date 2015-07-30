namespace Oracle.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VendorDTO
    {
        private ICollection<ProductDTO> products;
        
        public VendorDTO()
        {
            this.products = new HashSet<ProductDTO>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductDTO> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
