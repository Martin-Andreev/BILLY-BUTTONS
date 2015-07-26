using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketClient
{
    using System.Data.Entity;
    using Exporters;
    using MSSQL.Data;
    using MSSQL.Data.Migrations;

    public partial class ExportToXMLForm : Form
    {
        public ExportToXMLForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.datePickerStartDate.Value.Date;
            DateTime endDate = this.datePickerEndDate.Value.Date;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQLContext, Configuration>());

            var vendorsSalesReports = MSSQLRepository.GetSalesByVendors(startDate, endDate);
            ExportToXML.ExportSalesByVendorsReport(vendorsSalesReports);
            this.Close();
        }
    }
}
