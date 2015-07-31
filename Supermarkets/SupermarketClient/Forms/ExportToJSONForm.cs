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
    using Exporters;
    using MSSQL.Data;

    public partial class ExportToJSONForm : Form
    {
        public ExportToJSONForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.datePickerStartDate.Value.Date;
            DateTime endDate = this.datePickerEndDate.Value.Date;
            var productsSalesReports = MSSQLRepository.GetSalesByProduct(startDate, endDate);
            ExportToJSON.ExportSalesByProductReport(productsSalesReports);
            this.Close();
        }
    }
}
