namespace SQLLite.Data
{
    using System;
    using System.Data.SQLite;

    public static class SqLiteContext
    {
        public static void GetProductTaxesData()
        {
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
                    Console.WriteLine(dataReader["ProductName"]);
                    Console.WriteLine(dataReader["Tax"]);
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
        }
    }
}
