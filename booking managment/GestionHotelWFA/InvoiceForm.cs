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
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }
        public int ID;
        int i = 0;
        
        public void autosearch(SqlCommand cmd1, SqlCommand cmd2) //function for filling the datagridview with filtered data
        {
            //first command for loading the datagridview
            DGVAccom.DataSource = Program.getData(cmd1);
            DGVAccom.Columns[0].Width = 30;
            //count the number of days
            int days = 0;
            for (int i = 0; i < DGVAccom.RowCount; i++)
            {
                days += int.Parse(DGVAccom.Rows[i].Cells[3].Value.ToString());
            }
            lblTDays.Text = "Total Days :" + days;
            //count the amount of money
            int amount = 0;
            for (int i = 0; i < DGVAccom.RowCount; i++)
            {
                amount += int.Parse(DGVAccom.Rows[i].Cells[5].Value.ToString());
            }
            lblTAmount.Text = "Total Amount :" + amount + "$";
            //the second comannd for checking if any accommdation is canceled and making it red
            DataTable dt = Program.getData(cmd2);
            for (int i = 0; i < DGVAccom.RowCount; i++)
            {
                if (dt.Rows[i][0].ToString() == DGVAccom.Rows[i].Cells[0].Value.ToString() &&
                    dt.Rows[i][1].ToString() == DGVAccom.Rows[i].Cells[1].Value.ToString() &&
                    dt.Rows[i][2].ToString() == "True")
                {
                    DGVAccom.Rows[i].DefaultCellStyle.BackColor = Color.Crimson;
                }
                if (dt.Rows[i][0].ToString() == DGVAccom.Rows[i].Cells[0].Value.ToString() &&
                    dt.Rows[i][1].ToString() == DGVAccom.Rows[i].Cells[1].Value.ToString() &&
                    dt.Rows[i][2].ToString() == "False")
                {
                    DGVAccom.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            DGVAccom.Rows[0].Cells[0].Selected = false;
        }
        public void LoadGrid() //function for refreshing the datagridview
        {
            SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay]" +
                " from users u join AccomdationData ad on ad.UserEmail = u.Email " +
                "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID where RoleId='C' order by FullName");
            
            SqlCommand cmd2= new SqlCommand("select AccomdationId,FullName,unconfirmed " +
                "from users u join AccomdationData ad on ad.UserEmail = u.Email" +
                " join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID order by FullName");
            autosearch(cmd, cmd2);
            
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

            LoadGrid();
            DGVAccom.Rows[0].Cells[0].Selected = false;
            //loading the name combobox
            cmbFullName.DataSource = Program.getData(new SqlCommand("select email,FullName from users u " +
                "join (select distinct UserEmail from AccomdationData) a on a.UserEmail=u.Email"));
            cmbFullName.DisplayMember = ("FullName");
            cmbFullName.ValueMember = ("Email");

            //loading the type combobox
            cmbType.DataSource = Program.getData(new SqlCommand("select accomndationTypeId,AccomndationType " +
                "from AccomdationType"));
            cmbType.DisplayMember = ("AccomndationType");
            cmbType.ValueMember = ("AccomndationTypeId");

            cmbType.SelectedIndex = 1;
            cmbFullName.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new form1();
            form.Show();
            this.Hide();
        }

        private void chbAllUsers_CheckedChanged(object sender, EventArgs e)
        {

            if (chbAllTypes.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email join " +
                    "AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID join roles r on u.RoleID=r.RoleID" +
                    " where u.RoleID='C' order by FullName"); 
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u" +
                    " join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' order by FullName");
                autosearch(cmd, cmd2);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name],StarDate as [Start Date]" +
                    ",DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay]" +
                    " from users u join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' and ad.AccomdationTypeId=@type order by FullName");
                cmd.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' and ad.AccomdationTypeId=@type order by FullName");
                cmd2.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                autosearch(cmd, cmd2);
            }

        }

        private void chbAllTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllUsers.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' order by FullName");
                
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' order by FullName");
                autosearch(cmd, cmd2);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]," +
                    "StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email" +
                    " join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' and u.email=@email order by FullName");
                cmd.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());                
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID where u.RoleID='C' and u.email=@email order by FullName");
                cmd2.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());
                autosearch(cmd, cmd2);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //sinse we will be searching for a specific type, we uncheck the all types checkbox
            chbAllTypes.Checked = false;
            if (chbAllUsers.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u" +
                    " join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID " +
                    "where u.RoleID='C' and u.email=@email and ad.AccomdationTypeId=@type order by FullName");
                cmd.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
               
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID" +
                    " where u.RoleID='C' and u.email=@email and ad.AccomdationTypeId=@type order by FullName");
                cmd2.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());
                cmd2.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                autosearch(cmd, cmd2);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email" +
                    " join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID" +
                    " join roles r on u.RoleID=r.RoleID " +
                    "where u.RoleID='C' and ad.AccomdationTypeId=@type order by FullName");
                cmd.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));

                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID " +
                    "where u.RoleID='C' and ad.AccomdationTypeId=@type order by FullName");
                cmd2.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                autosearch(cmd, cmd2);
            }
            //sinse we will be searching for a specific user, we uncheck the all users checkbox
            chbAllUsers.Checked = false;
            if (chbAllTypes.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email" +
                    " join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID " +
                    "where u.RoleID='C' and u.email=@email and ad.AccomdationTypeId=@type order by FullName");
                cmd.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
               
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID " +
                    "where u.RoleID='C' and  ad.AccomdationTypeId=@type order by FullName");
                cmd2.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                autosearch(cmd, cmd2);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select accomdationId as [ID],fullName as [Full Name]" +
                    ",StarDate as [Start Date],DATEDIFF(DAY,starDate,EndDate) as [days],AccomndationType as [Room Type]" +
                    ",accomndationPricePerNight*(DATEDIFF(DAY,starDate,EndDate)) as [price per stay] from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID" +
                    " join roles r on u.RoleID=r.RoleID where u.RoleID='C' and u.email=@name order by FullName");
                cmd.Parameters.AddWithValue("@email", cmbFullName.SelectedValue.ToString());
                
                SqlCommand cmd2 = new SqlCommand("select fullName,StarDate,unconfirmed from users u " +
                    "join AccomdationData ad on ad.UserEmail = u.Email " +
                    "join AccomdationType[at] on at.AccomndationTypeID = ad.AccomdationTypeID " +
                    "join roles r on u.RoleID=r.RoleID" +
                    " where u.RoleID='C' and  ad.AccomdationTypeId=@type order by FullName");
                cmd2.Parameters.AddWithValue("@type", int.Parse(cmbType.SelectedValue.ToString()));
                autosearch(cmd, cmd2);
            }
        }
        private void DGVAccom_SelectionChanged(object sender, EventArgs e)
        {
            // we take the id of the selected accommdation
            i++;
            if (i > 1)
            {
                if (DGVAccom.SelectedCells.Count > 0)
                {
                    int selectedrowindex = DGVAccom.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = DGVAccom.Rows[selectedrowindex];
                    ID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string uncon;
            //we check if the accommdation is canceled
            SqlCommand cmd = new SqlCommand("select unconfirmed from accomdationData a " +
                "join users u on a.UserEmail=u.email where AccomdationId=@Id");
            cmd.Parameters.AddWithValue("@Id", ID);
            DataTable dt = Program.getData(cmd);
            uncon = dt.Rows[0][0].ToString();
            if (uncon == "True") //if the accommdation is canceled we ask him if he want to confirm it
            {
                DialogResult ans = MessageBox.Show("do you want to confirm this accommodation?", "confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    SqlCommand cmd2 = new SqlCommand("update accomdationData set unconfirmed=0 where accomdationId=@id");
                    cmd2.Parameters.AddWithValue("@id", ID);
                    Program.setData(cmd2);
                    MessageBox.Show("Accommdation confirmed");
                    LoadGrid();
                }
            }
            else //if the accommdation is NOT canceled we ask him if he want to cancel it
            {
                DialogResult ans = MessageBox.Show("do you want to cancel this accommodation?", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    SqlCommand cmd2 = new SqlCommand("update accomdationData set unconfirmed=1 where accomdationId=@id");
                    cmd2.Parameters.AddWithValue("@id", ID);
                    Program.setData(cmd2);
                    MessageBox.Show("Accommdation canceled");
                    LoadGrid();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImportAccForm f = new ImportAccForm();
            f.ShowDialog();
        }
    }
}
