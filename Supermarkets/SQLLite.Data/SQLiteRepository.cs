namespace SQLLite.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    public static class SqLiteRepository
    {
        public static Dictionary<string, int> GetProductTaxesData()
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            const string query = "SELECT * FROM ProductTaxes;";
            const string dataSource = @"D:\SoftUni\Level #3\Database Apps\Teamwork SQLite DB\TaxInformation.sqlite";
            
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + dataSource);
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader dataReader = null;
            
            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string productName = dataReader["ProductName"].ToString();
                    int productTax = int.Parse(dataReader["Tax"].ToString());

                    products.Add(productName, productTax);
                    //Console.WriteLine(dataReader["ProductName"]);
                    //Console.WriteLine(dataReader["Tax"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                connection.Close();
            }

            return products;
        }
    }
}
