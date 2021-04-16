namespace GestionHotelWFA
{
    partial class form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmailForm1 = new System.Windows.Forms.TextBox();
            this.PasswordForm1 = new System.Windows.Forms.TextBox();
            this.BtnLoginForm1 = new System.Windows.Forms.Button();
            this.BtnCancelForm1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 76);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(242, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(0, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 43);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(683, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Veuillez vous connecter au système en utilisant votre adresse email et votre mot " +
    "de passe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password :";
            // 
            // EmailForm1
            // 
            this.EmailForm1.AllowDrop = true;
            this.EmailForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailForm1.Location = new System.Drawing.Point(277, 146);
            this.EmailForm1.Name = "EmailForm1";
            this.EmailForm1.Size = new System.Drawing.Size(239, 26);
            this.EmailForm1.TabIndex = 4;
            // 
            // PasswordForm1
            // 
            this.PasswordForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordForm1.Location = new System.Drawing.Point(277, 194);
            this.PasswordForm1.Name = "PasswordForm1";
            this.PasswordForm1.PasswordChar = '*';
            this.PasswordForm1.Size = new System.Drawing.Size(239, 26);
            this.PasswordForm1.TabIndex = 5;
            // 
            // BtnLoginForm1
            // 
            this.BtnLoginForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoginForm1.Location = new System.Drawing.Point(229, 264);
            this.BtnLoginForm1.Name = "BtnLoginForm1";
            this.BtnLoginForm1.Size = new System.Drawing.Size(92, 34);
            this.BtnLoginForm1.TabIndex = 6;
            this.BtnLoginForm1.Text = "Login";
            this.BtnLoginForm1.UseVisualStyleBackColor = true;
            this.BtnLoginForm1.Click += new System.EventHandler(this.BtnLoginForm1_Click);
            // 
            // BtnCancelForm1
            // 
            this.BtnCancelForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelForm1.Location = new System.Drawing.Point(369, 264);
            this.BtnCancelForm1.Name = "BtnCancelForm1";
            this.BtnCancelForm1.Size = new System.Drawing.Size(92, 34);
            this.BtnCancelForm1.TabIndex = 7;
            this.BtnCancelForm1.Text = "Cancel";
            this.BtnCancelForm1.UseVisualStyleBackColor = true;
            this.BtnCancelForm1.Click += new System.EventHandler(this.BtnCancelForm1_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 369);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancelForm1);
            this.Controls.Add(this.BtnLoginForm1);
            this.Controls.Add(this.PasswordForm1);
            this.Controls.Add(this.EmailForm1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion De Hotel";
            this.Load += new System.EventHandler(this.form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmailForm1;
        private System.Windows.Forms.TextBox PasswordForm1;
        private System.Windows.Forms.Button BtnLoginForm1;
        private System.Windows.Forms.Button BtnCancelForm1;
    }
}

