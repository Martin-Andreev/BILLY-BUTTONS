﻿namespace SupermarketClient.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExportToExel = new System.Windows.Forms.Button();
            this.btnMySQL = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.btnMongoDB = new System.Windows.Forms.Button();
            this.btnGenerateXML = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnExel = new System.Windows.Forms.Button();
            this.btnOracle = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExportToExel
            // 
            this.btnExportToExel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExportToExel.Location = new System.Drawing.Point(602, 236);
            this.btnExportToExel.Name = "btnExportToExel";
            this.btnExportToExel.Size = new System.Drawing.Size(119, 36);
            this.btnExportToExel.TabIndex = 17;
            this.btnExportToExel.Text = "Export to Exel";
            this.btnExportToExel.UseVisualStyleBackColor = true;
            this.btnExportToExel.Click += new System.EventHandler(this.btnExportToExel_Click);
            // 
            // btnMySQL
            // 
            this.btnMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMySQL.Location = new System.Drawing.Point(420, 236);
            this.btnMySQL.Name = "btnMySQL";
            this.btnMySQL.Size = new System.Drawing.Size(146, 36);
            this.btnMySQL.TabIndex = 16;
            this.btnMySQL.Text = "Load data to MySQL";
            this.btnMySQL.UseVisualStyleBackColor = true;
            this.btnMySQL.Click += new System.EventHandler(this.PopulateMySql_Click);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadXML.Location = new System.Drawing.Point(257, 236);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(118, 36);
            this.btnLoadXML.TabIndex = 15;
            this.btnLoadXML.Text = "Load from XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.ImportFromXML_Click);
            // 
            // btnMongoDB
            // 
            this.btnMongoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMongoDB.Location = new System.Drawing.Point(44, 236);
            this.btnMongoDB.Name = "btnMongoDB";
            this.btnMongoDB.Size = new System.Drawing.Size(169, 36);
            this.btnMongoDB.TabIndex = 14;
            this.btnMongoDB.Text = "MongoDB JSON Reports";
            this.btnMongoDB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMongoDB.UseVisualStyleBackColor = true;
            this.btnMongoDB.Click += new System.EventHandler(this.ExportToJson_Click);
            // 
            // btnGenerateXML
            // 
            this.btnGenerateXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateXML.Location = new System.Drawing.Point(580, 171);
            this.btnGenerateXML.Name = "btnGenerateXML";
            this.btnGenerateXML.Size = new System.Drawing.Size(107, 36);
            this.btnGenerateXML.TabIndex = 13;
            this.btnGenerateXML.Text = "Generate XML ";
            this.btnGenerateXML.UseVisualStyleBackColor = true;
            this.btnGenerateXML.Click += new System.EventHandler(this.ExportToXML_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPDF.Location = new System.Drawing.Point(420, 171);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(124, 36);
            this.btnPDF.TabIndex = 12;
            this.btnPDF.Text = "PDF Sales Reports";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.ExportToPDF_Click);
            // 
            // btnExel
            // 
            this.btnExel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExel.Location = new System.Drawing.Point(283, 171);
            this.btnExel.Name = "btnExel";
            this.btnExel.Size = new System.Drawing.Size(109, 36);
            this.btnExel.TabIndex = 11;
            this.btnExel.Text = "Load Excel Data";
            this.btnExel.UseVisualStyleBackColor = true;
            this.btnExel.Click += new System.EventHandler(this.ImportFromExel_Click);
            // 
            // btnOracle
            // 
            this.btnOracle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOracle.Location = new System.Drawing.Point(66, 171);
            this.btnOracle.Name = "btnOracle";
            this.btnOracle.Size = new System.Drawing.Size(189, 36);
            this.btnOracle.TabIndex = 10;
            this.btnOracle.Text = "Populate MSSQL From Oracle";
            this.btnOracle.UseVisualStyleBackColor = true;
            this.btnOracle.Click += new System.EventHandler(this.ReplicateOracleToMssql_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(227, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 61);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Supermarkets";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 340);
            this.Controls.Add(this.btnExportToExel);
            this.Controls.Add(this.btnMySQL);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.btnMongoDB);
            this.Controls.Add(this.btnGenerateXML);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnExel);
            this.Controls.Add(this.btnOracle);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportToExel;
        private System.Windows.Forms.Button btnMySQL;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnMongoDB;
        private System.Windows.Forms.Button btnGenerateXML;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnExel;
        private System.Windows.Forms.Button btnOracle;
        private System.Windows.Forms.Label lblTitle;
    }
}

