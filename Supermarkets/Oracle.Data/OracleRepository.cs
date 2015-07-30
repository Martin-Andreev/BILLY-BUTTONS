namespace Oracle.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class OracleRepository
    {
        public static IList<ProductDTO> GetOracleData()
        {
            OracleDbContex context = new OracleDbContex();

            var data = context.Products.ToList();

            return data;
        }
    }
}
