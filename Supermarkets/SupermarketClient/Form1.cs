using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.Models;
using Supermarket.Database.Mysql.Data;

namespace SupermarketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOracle_Click(object sender, EventArgs e)
        {

        }

        private void btnExel_Click(object sender, EventArgs e)
        {

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateXML_Click(object sender, EventArgs e)
        {

        }

        private void btnMongoDB_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {

        }

        private void btnMySQL_Click(object sender, EventArgs e)
        {
            var context = new SupermarketsMysqlContext();
            var products = context.Products.ToList();
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
