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
using MySQLDB.Data;
using MSSQL.Data;

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
            
            //TODO: Remove from here to the proper button when button is created;
            //Remove logic to a method
            //var context = new MSSQLContext();
            //var products = context.Products.ToList();            
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {

        }

        private void btnMySQL_Click(object sender, EventArgs e)
        {
            
            //TODO: Remove logic to a method
            //var context = new MySQLContext();
            //var products = context.Products.ToList();            
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
