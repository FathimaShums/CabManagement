namespace CabManagement
{
    partial class registercustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_contact = new System.Windows.Forms.TextBox();
            this.txt_accountNo = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact_No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account_No:";
            // 
            // txt_Name
            // 
            this.txt_Name.BackColor = System.Drawing.Color.LightYellow;
            this.txt_Name.Location = new System.Drawing.Point(505, 96);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(406, 28);
            this.txt_Name.TabIndex = 4;
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.Color.LightYellow;
            this.txt_ID.Location = new System.Drawing.Point(505, 167);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(406, 28);
            this.txt_ID.TabIndex = 5;
            // 
            // txt_contact
            // 
            this.txt_contact.BackColor = System.Drawing.Color.LightYellow;
            this.txt_contact.Location = new System.Drawing.Point(505, 232);
            this.txt_contact.Name = "txt_contact";
            this.txt_contact.Size = new System.Drawing.Size(406, 28);
            this.txt_contact.TabIndex = 6;
            // 
            // txt_accountNo
            // 
            this.txt_accountNo.BackColor = System.Drawing.Color.LightYellow;
            this.txt_accountNo.Location = new System.Drawing.Point(505, 298);
            this.txt_accountNo.Name = "txt_accountNo";
            this.txt_accountNo.Size = new System.Drawing.Size(406, 28);
            this.txt_accountNo.TabIndex = 7;
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.Olive;
            this.btn_register.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btn_register.Location = new System.Drawing.Point(800, 417);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(208, 56);
            this.btn_register.TabIndex = 8;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.LightYellow;
            this.txt_password.Location = new System.Drawing.Point(505, 363);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(406, 28);
            this.txt_password.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 47);
            this.button2.TabIndex = 12;
            this.button2.Text = "Back to login";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // registercustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.txt_accountNo);
            this.Controls.Add(this.txt_contact);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "registercustomer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_contact;
        private System.Windows.Forms.TextBox txt_accountNo;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button button2;
    }
}