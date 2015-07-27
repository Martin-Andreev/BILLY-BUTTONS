using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SupermarketConsoleClient
{
    public class Reports
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string vendor_name { get; set; }
        public int total_quantity_sold { get; set; }
        public decimal total_incomes { get; set; }

    }
}
