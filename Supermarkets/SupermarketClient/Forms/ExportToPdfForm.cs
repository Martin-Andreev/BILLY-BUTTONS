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
    using MSSQL.Data;
    //using MSSQL.Data.Migrations;

    public partial class ExportToPdfForm : Form
    {
        public ExportToPdfForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstDate = this.dateTimePicker1.Value.Date;
            var secondDate = this.dateTimePicker2.Value.Date;
            MSSQLContext context = new MSSQLContext();
            ExportSalesReportsToPDF.ExportDataToPdf(firstDate,secondDate, context);
            this.Close();
        }
    }
}
