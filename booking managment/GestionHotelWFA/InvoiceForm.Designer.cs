namespace GestionHotelWFA
{
    partial class InvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbAllUsers = new System.Windows.Forms.CheckBox();
            this.chbAllTypes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTDays = new System.Windows.Forms.Label();
            this.lblTAmount = new System.Windows.Forms.Label();
            this.cmbFullName = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.DGVAccom = new System.Windows.Forms.DataGridView();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAccom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 78);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(679, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(287, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(207, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Manage accommadations invoices";
            // 
            // chbAllUsers
            // 
            this.chbAllUsers.AutoSize = true;
            this.chbAllUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllUsers.Location = new System.Drawing.Point(141, 154);
            this.chbAllUsers.Name = "chbAllUsers";
            this.chbAllUsers.Size = new System.Drawing.Size(117, 20);
            this.chbAllUsers.TabIndex = 7;
            this.chbAllUsers.Text = "Show All Users";
            this.chbAllUsers.UseVisualStyleBackColor = true;
            this.chbAllUsers.CheckedChanged += new System.EventHandler(this.chbAllUsers_CheckedChanged);
            // 
            // chbAllTypes
            // 
            this.chbAllTypes.AutoSize = true;
            this.chbAllTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllTypes.Location = new System.Drawing.Point(450, 154);
            this.chbAllTypes.Name = "chbAllTypes";
            this.chbAllTypes.Size = new System.Drawing.Size(120, 20);
            this.chbAllTypes.TabIndex = 8;
            this.chbAllTypes.Text = "Show All Types";
            this.chbAllTypes.UseVisualStyleBackColor = true;
            this.chbAllTypes.CheckedChanged += new System.EventHandler(this.chbAllTypes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(447, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type";
            // 
            // lblTDays
            // 
            this.lblTDays.AutoSize = true;
            this.lblTDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDays.Location = new System.Drawing.Point(287, 231);
            this.lblTDays.Name = "lblTDays";
            this.lblTDays.Size = new System.Drawing.Size(74, 16);
            this.lblTDays.TabIndex = 11;
            this.lblTDays.Text = "Total Days";
            // 
            // lblTAmount
            // 
            this.lblTAmount.AutoSize = true;
            this.lblTAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAmount.Location = new System.Drawing.Point(404, 231);
            this.lblTAmount.Name = "lblTAmount";
            this.lblTAmount.Size = new System.Drawing.Size(93, 16);
            this.lblTAmount.TabIndex = 12;
            this.lblTAmount.Text = "Total Amount :";
            // 
            // cmbFullName
            // 
            this.cmbFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullName.FormattingEnabled = true;
            this.cmbFullName.Location = new System.Drawing.Point(183, 178);
            this.cmbFullName.Name = "cmbFullName";
            this.cmbFullName.Size = new System.Drawing.Size(143, 21);
            this.cmbFullName.TabIndex = 13;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(488, 178);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(139, 21);
            this.cmbType.TabIndex = 14;
            // 
            // DGVAccom
            // 
            this.DGVAccom.AllowUserToAddRows = false;
            this.DGVAccom.AllowUserToDeleteRows = false;
            this.DGVAccom.AllowUserToResizeColumns = false;
            this.DGVAccom.AllowUserToResizeRows = false;
            this.DGVAccom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVAccom.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAccom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAccom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAccom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVAccom.Location = new System.Drawing.Point(57, 257);
            this.DGVAccom.Name = "DGVAccom";
            this.DGVAccom.RowHeadersVisible = false;
            this.DGVAccom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVAccom.Size = new System.Drawing.Size(677, 150);
            this.DGVAccom.TabIndex = 15;
            this.DGVAccom.SelectionChanged += new System.EventHandler(this.DGVAccom_SelectionChanged);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(639, 178);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(90, 21);
            this.BtnSearch.TabIndex = 16;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(57, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 38);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel accommodation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(538, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 38);
            this.button2.TabIndex = 18;
            this.button2.Text = "Export accommodation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.DGVAccom);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbFullName);
            this.Controls.Add(this.lblTAmount);
            this.Controls.Add(this.lblTDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbAllTypes);
            this.Controls.Add(this.chbAllUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage accommadations invoices";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAccom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbAllUsers;
        private System.Windows.Forms.CheckBox chbAllTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTDays;
        private System.Windows.Forms.Label lblTAmount;
        private System.Windows.Forms.ComboBox cmbFullName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DataGridView DGVAccom;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button2;
    }
}