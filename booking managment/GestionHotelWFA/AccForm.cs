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
    public partial class AccForm : Form
    { 
        public AccForm()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        //function to show the price of the accomndation with the recieved id
        public void pricepernight(int id)
        {
            SqlCommand cmd = new SqlCommand("select accomndationpricepernight from accomdationType where accomndationTypeID = @id");
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = Program.getData(cmd);
            label3.Text = "Current Price:" + dt.Rows[0][0].ToString() + "$";
        }
        //function to show the images of the accomndation with the recieved id
        public void loadImages(int id)
        {
            //declare an image array for stocking images
            Image[] pic = new Image[5];
            //a string array for stocking image titles
            string[] titles = new string[5];
            // a pictureboxe array
            CirclePictureBox[] boxes =
            {
                circlePictureBox8,circlePictureBox9,circlePictureBox10,circlePictureBox11,circlePictureBox12
                };
            // a label array
            Label[] labels =
            {
                label8,label9,label10,label11,label12
            };
            //get the data from the database
            SqlCommand command = new SqlCommand("select PictureID,PictureTitle,PicturePath,count(AccomndationTypeID) from AccomndationPictures where AccomndationTypeID=@id group by PictureID,PictureTitle,PicturePath");
            command.Parameters.AddWithValue("@id", id);
            DataTable dt = Program.getData(command);
            int count = dt.Rows.Count > 0 ? int.Parse(dt.Rows[0][3].ToString()):0;
            for (int i = 0; i < count; i++)
            {
                    pic[i] = Image.FromFile(dt.Rows[i][2].ToString());
                    titles[i] = dt.Rows[i][1].ToString();
            }
            //using the for loop for filling the pictureboxes and labels
            for (int i = 0; i < count && i < 5; i++)
            {
                boxes[i].Image = pic[i];
                labels[i].Text = titles[i];
            }
            //if the number of pictures is less than the number of pictureboxes we hide the empty pictureboxes
            //using this for loop
            if (count < 5)
            {
               for (int i = 0; i < 5 - count; i++)
               {
                boxes[4 - i].Visible = false;
                labels[4 - i].Visible = false;
               }

            }    
        }

        private void AccForm_Load(object sender, EventArgs e)
        {
           //load the combobox
            cmbAcc.DataSource = Program.getData(new SqlCommand("select AccomndationTypeID,AccomndationType from accomdationType"));
            cmbAcc.DisplayMember = "AccomndationType";
            cmbAcc.ValueMember = "AccomndationTypeID";
            cmbAcc.SelectedIndex = 0;

            int id = int.Parse(cmbAcc.SelectedValue.ToString());
            pricepernight(id);
            loadImages(id);
        }


        private void btnSavePic_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmbAcc.SelectedValue.ToString());
            if ((txtPic.Text == "" && NewPic.Image==null)|| txtPicTitle.Text == "" )
            {
                MessageBox.Show("there are missing information");
            }
            else
            {
                //adding the picture information to the database
                SqlCommand cmd = new SqlCommand("insert into accomndationPictures (AccomndationTypeID,PicturePath,PictureTitle) values(@id,@picpath,@title)");
                cmd.Parameters.AddWithValue("@id", int.Parse(cmbAcc.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("picpath", txtPic.Text);
                cmd.Parameters.AddWithValue("title", txtPicTitle.Text);
                Program.setData(cmd);
                MessageBox.Show("picture added with success!");
                txtPic.Text = txtPicTitle.Text = "";
                NewPic.Image = null;
                loadImages(id);
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //showing the chosen picture and the file path
                NewPic.Image = new Bitmap(open.FileName);
                txtPic.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new GestionnaireForm();
            form.Show();
            this.Hide();
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            addtypeForm f2 = new addtypeForm();
            f2.ShowDialog();
        }
        private void cmbAcc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = int.Parse(cmbAcc.SelectedValue.ToString());
            pricepernight(id);
            loadImages(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new form1();
            form.Show();
            this.Hide();
        }

        
    }
}
