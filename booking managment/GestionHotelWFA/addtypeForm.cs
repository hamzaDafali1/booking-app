using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace GestionHotelWFA
{
    public partial class addtypeForm : Form
    {
        public addtypeForm()
        {
            InitializeComponent();
        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            double pr=0;
            double.TryParse(txtPrice.Text,out pr); //to check if the entered price is a number
            if (txtName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("please add missing informations");
            }
            else if (pr==0)
            {
                MessageBox.Show("please add a valid price");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into AccomdationType (AccomndationType,AccomndationPricePerNight) values(@type,@price)");
                cmd.Parameters.AddWithValue("@type", txtName.Text);
                cmd.Parameters.AddWithValue("@price", int.Parse(txtPrice.Text));
                Program.setData(cmd);
                MessageBox.Show("accommodation added with success!");
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

    }
}
