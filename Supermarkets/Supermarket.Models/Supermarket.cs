﻿namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supermarket
    {
        private ICollection<Sale> sales;

        public Supermarket()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; } 
            set { this.sales = value; }
        }
    }
}
