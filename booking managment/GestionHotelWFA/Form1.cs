using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace GestionHotelWFA
{
    public partial class form1 : Form
    {
        
        public form1()
        {
            InitializeComponent();
           
        }
        private void BtnCancelForm1_Click(object sender, EventArgs e)
        {
            // to close the program
            Application.Exit();
        }

        private void BtnLoginForm1_Click(object sender, EventArgs e)
        {
            string role;
            try
            {
                //check if textboxes are not empty
                if (EmailForm1.Text == string.Empty)
                {
                    MessageBox.Show("Email est obligatoire");
                }
                else if (PasswordForm1.Text == string.Empty)
                {
                    MessageBox.Show("Mot de passe est obligatoire");
                }
                else {
                    SqlCommand cmd = new SqlCommand("select RoleName from Roles R join Users U on R.RoleId=U.RoleId where Email=@email and Password=@Password;");
                    cmd.Parameters.AddWithValue("@email", EmailForm1.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordForm1.Text);
                    DataTable dt = new DataTable();
                    dt = Program.getData(cmd);
                    //check if the user exists
                    if (dt.Rows.Count>0)
                    {
                        //check the role of the user
                        role = dt.Rows[0][0].ToString();
                        if (role == "Administrator")
                        {
                            this.Hide();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }
                        if (role == "Manager")
                        {
                            this.Hide();
                            GestionnaireForm formgest = new GestionnaireForm();
                            formgest.Show();
                        }
                    }
                    else
                        MessageBox.Show("les informations que vous avez saisies sont incorrectes");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
    }
}
