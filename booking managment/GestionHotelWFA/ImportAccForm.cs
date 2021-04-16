using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;

namespace GestionHotelWFA
{
    public partial class ImportAccForm : Form
    {
        public ImportAccForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                    try
                    {
                        textBox1.Text = sfd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( ex.Message);
                    }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                string q = "Declare @query nvarchar(400) = 'Bulk insert AccomdationData" +
                           "Fromm '''+@filepath+''' " +
                           "with(" +
                           "Fieldterminator='';''," +
                           "Rowterminator = ''\n''" +
                           ")';" +
                           "Exec(@query);";
                SqlCommand cmd = new SqlCommand(q);
                cmd.Parameters.AddWithValue("@filepath", textBox1.Text);
                if (Program.setData(cmd))
                    MessageBox.Show("This file imported successfully!!");
                else
                    MessageBox.Show("this process failed");
            }
            else
                MessageBox.Show("you haven't chosen any file");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form = new InvoiceForm();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new form1();
            form.Show();
            this.Close();
        }
    }
}
