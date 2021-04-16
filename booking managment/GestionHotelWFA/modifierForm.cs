using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace GestionHotelWFA
{
    public partial class modifierForm : Form
    {
        public modifierForm()
        {
            InitializeComponent();
        }
        //recieving the user's email
        public string UserEmail { get; set; }

        private void modifierForm_Load(object sender, EventArgs e)
        {
            //filling the ComboBoxes
            DataTable dt = new DataTable();
            lblEmail.Text = UserEmail;
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbRole.DataSource = Program.getData(new SqlCommand("select RoleID,RoleName from Roles"));
            cmbRole.DisplayMember = ("RoleName");
            cmbRole.ValueMember = ("RoleId");
            //loading the user's data
            SqlCommand cmd = new SqlCommand("select Email,FullName,Gender,RoleId,DateofBirth,MobileNo from users where Email=@email");
            cmd.Parameters.AddWithValue("@email", UserEmail);
            dt= Program.getData(cmd);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0][1].ToString();
                cmbGender.SelectedItem = dt.Rows[0][2].ToString();
                cmbRole.SelectedValue = dt.Rows[0][3].ToString();
                birthdayPick.Text = dt.Rows[0][4].ToString();
                txtTel.Text = dt.Rows[0][5].ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new form1();
            form.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //check if the textboxes are not empty and the passwords are the same
            if (txtpassword.Text == txtPassAgain.Text && txtpassword.Text!=string.Empty)
            {
                //check if the password is longer than 6 characteres
                if (txtpassword.TextLength < 6)
                {
                    MessageBox.Show("le mot de passe doit contenir au moins 6 caractères");
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update users set FullName=@name,gender=@gender,MobileNo=@tel,RoleId=@role,DateofBirth=@date where email=@email");
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTel.Text);
                        cmd.Parameters.AddWithValue("@email", UserEmail);
                        cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@date", birthdayPick.Value);
                        Program.setData(cmd);
                        MessageBox.Show("la modification a réussi");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (txtpassword != txtPassAgain)
                {
                    MessageBox.Show("les mots de passe sont différents");
                }
                
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
