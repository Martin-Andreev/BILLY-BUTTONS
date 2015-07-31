namespace SupermarketClient
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Exporters;
    using MSSQL.Data;
    using MySQLDB.Data;
    using Oracle.Data;
    using SQLLite.Data;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOracle_Click(object sender, EventArgs e)
        {
            OracleDbContex context = new OracleDbContex();
            MessageBox.Show(context.Measures.Count().ToString());
            MSSQLRepository.ReplicateOracleData(OracleRepository.GetOracleData());
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            ImportFromExcelForm excelForm = new ImportFromExcelForm();
            excelForm.ShowDialog();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnGenerateXML_Click(object sender, EventArgs e)
        {
            ExportToXMLForm xmlForm = new ExportToXMLForm();
            xmlForm.ShowDialog();
        }

        private void btnMongoDB_Click(object sender, EventArgs e)
        {
            ExportToJSONForm jsonForm = new ExportToJSONForm();
            jsonForm.ShowDialog();
            //TODO: Remove from here to the proper button when button is created;
            //Remove logic to a method
            //var context = new MSSQLContext();
            //var products = context.Products.ToList();            
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            ImportFromXMLForm xmlForm = new ImportFromXMLForm();
            xmlForm.ShowDialog();
        }

        private void btnMySQL_Click(object sender, EventArgs e)
        {
            //MySQLContext context = new MySQLContext();
            //MessageBox.Show(context.Products.Count().ToString());
            MSSQLContext context = new MSSQLContext();
            //var data = MSSQLRepository.GetAllData(context);
            MySqlRepository.ReplicateMssqlData(context);
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var products = SqLiteRepository.GetProductTaxesData();
            var vendors = MySqlRepository.GetAllData();
            ExportToExcel.ExportVendorsReports(products, vendors);

            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
