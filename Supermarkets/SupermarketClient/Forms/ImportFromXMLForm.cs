﻿using System;
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
    using Importerts;

    public partial class ImportFromXMLForm : Form
    {
        public ImportFromXMLForm()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                ImportFromXML.ImportVendorExpenses(file);
            }

            this.Close();
        }
    }
}