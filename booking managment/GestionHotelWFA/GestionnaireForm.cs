using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionHotelWFA
{
    public partial class GestionnaireForm : Form
    {
        public GestionnaireForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccForm form = new AccForm();
            form.Show();
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            InvoiceForm f = new InvoiceForm();
            f.Show();
            this.Hide();

        }
    }
}
