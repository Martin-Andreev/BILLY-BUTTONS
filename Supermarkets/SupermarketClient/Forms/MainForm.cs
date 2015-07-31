namespace SupermarketClient.Forms
{
    using System;
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

        private void ReplicateOracleToMssql_Click(object sender, EventArgs e)
        {
            const string successfullyReplicatedMessage = "Oracle Database successfully replicated!";

            MSSQLRepository.ReplicateOracleData(OracleRepository.GetOracleData());
            MessageBox.Show(successfullyReplicatedMessage);
        }

        private void ImportFromExel_Click(object sender, EventArgs e)
        {
            const string successfullyImportedMessage = "Successfully imported from Excel!";

            ImportFromExcelForm excelForm = new ImportFromExcelForm();
            excelForm.ShowDialog();
            MessageBox.Show(successfullyImportedMessage);
        }

        private void ExportToPDF_Click(object sender, EventArgs e)
        {
            const string successfullyExportedMessage = "Successfully exported to PDF!";

            ExportToPdfForm exportToPdfForm = new ExportToPdfForm();
            exportToPdfForm.ShowDialog();
            MessageBox.Show(successfullyExportedMessage);
        }

        private void ExportToXML_Click(object sender, EventArgs e)
        {
            const string successfullyImportedMessage = "Successfully imported from XML!";

            ExportToXMLForm xmlForm = new ExportToXMLForm();
            xmlForm.ShowDialog();
            MessageBox.Show(successfullyImportedMessage);
        }

        private void ExportToJson_Click(object sender, EventArgs e)
        {
            const string successfullyExporedMessage = "Successfully exported to JSON!";

            ExportToJSONForm jsonForm = new ExportToJSONForm();
            jsonForm.ShowDialog();
            MessageBox.Show(successfullyExporedMessage);
        }

        private void ImportFromXML_Click(object sender, EventArgs e)
        {
            const string successfullyImportedMessage = "Successfully imported from XML!";
            ImportFromXMLForm xmlForm = new ImportFromXMLForm();
            xmlForm.ShowDialog();
            MessageBox.Show(successfullyImportedMessage);
        }

        private void PopulateMySql_Click(object sender, EventArgs e)
        {
            const string successfullyPopulatedMessage = "Successfully populated from MySql Database";
            
            MSSQLContext context = new MSSQLContext();
            MySqlRepository.ReplicateMssqlData(context);
            MessageBox.Show(successfullyPopulatedMessage);
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            const string successfullyExpotedMessage = "Successfully exported to Excel!";
            
            var products = SqLiteRepository.GetProductTaxesData();
            var vendors = MySqlRepository.GetAllData();
            ExportToExcel.ExportVendorsReports(products, vendors);
            MessageBox.Show(successfullyExpotedMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
