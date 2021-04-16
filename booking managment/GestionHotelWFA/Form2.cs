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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string query;

        //function that shows the number of users
        public void UserCount()
        {
            int users = dataGridView1.RowCount;
            UsersNbr.Text = "Total users : " + users;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //fill the ComboBoxes
            CmbRole.DataSource = Program.getData(new SqlCommand("select RoleID,RoleName from Roles"));
            CmbRole.DisplayMember = ("RoleName");
            CmbRole.ValueMember = ("RoleId");

            CmbSort.Items.Add("Role");
            CmbSort.Items.Add("Email");
            CmbSort.Items.Add("Full Name");

            //fill the datagridview
            query = "select fullName as [Full Name],RoleName as [Role],Email from Users join Roles on Users.RoleID=Roles.RoleID";
            SqlCommand cmd = new SqlCommand(query);
            dataGridView1.DataSource = Program.getData(cmd);
            
            //adding the buttons in the datagridview
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.Text = "Edit";
            btn.Name = "btn";
            btn.HeaderText = "";
            btn.UseColumnTextForButtonValue = true;
            CmbRole.SelectedIndex = CmbSort.SelectedIndex = -1;

            UserCount();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //checking if the column if a button
            int ind = 2;
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ind = (CmbSort.SelectedIndex != (-1) || CmbRole.SelectedIndex != (-1)) ? 3 : 2;
                MessageBox.Show(e.ColumnIndex.ToString());
                string Email = dataGridView1.Rows[e.RowIndex].Cells[ind].Value.ToString();
                modifierForm frm3 = new modifierForm();
                //sending the email to the editing form
                frm3.UserEmail = Email;
                frm3.Show();
                this.Hide();
            }
        }

        private void CmbRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string idRole = CmbRole.SelectedValue.ToString();
            query = "select FullName as [Full Name],RoleName as [Role],email from Users u join roles r on u.RoleId=r.RoleId where u.RoleId=@id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", idRole);
            dataGridView1.DataSource = Program.getData(cmd);
            UserCount();
            

        }

        private void CmbSort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string idRole = CmbRole.SelectedValue.ToString();
            string sort = CmbSort.SelectedItem.ToString();
            string query2 = query;
            if(sort=="Full Name")
            {
                query += " order by FullName";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id", idRole);
                dataGridView1.DataSource = Program.getData(cmd);
                query = query2;
            }
            else if(sort == "Role")
            {
                query += " order by RoleName";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id", idRole);
                dataGridView1.DataSource = Program.getData(cmd);
                query = query2;
            }
            else
            {
                query += " order by Email";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id", idRole);
                dataGridView1.DataSource = Program.getData(cmd);
                query = query2;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //exporting data from datagridview to a CSV file
                if (dataGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "Output.csv";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                int columnCount = dataGridView1.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ";";
                                }
                                outputCsv[0] += columnNames;

                                for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ";";
                                    }
                                }

                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("Data Exported Successfully !!!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //refresh the datagridview and show all users
            SqlCommand cmd2 = new SqlCommand("select fullName as [Full Name],RoleName as [Role],Email from Users join Roles on Users.RoleID=Roles.RoleID");
            dataGridView1.DataSource = Program.getData(cmd2);
            UserCount();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hiding this form and showing the main form
            form1 form = new form1();
            form.Show();
            this.Hide();
        }
    }
}
