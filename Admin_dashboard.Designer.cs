namespace CabManagement
{
    partial class Admin_dashboard
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
            this.btn_managecars = new System.Windows.Forms.Button();
            this.btn_Managedrivers = new System.Windows.Forms.Button();
            this.btn_vieworderhistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_managecars
            // 
            this.btn_managecars.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_managecars.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_managecars.Location = new System.Drawing.Point(376, 136);
            this.btn_managecars.Margin = new System.Windows.Forms.Padding(4);
            this.btn_managecars.Name = "btn_managecars";
            this.btn_managecars.Size = new System.Drawing.Size(366, 64);
            this.btn_managecars.TabIndex = 0;
            this.btn_managecars.Text = "Manage Cars";
            this.btn_managecars.UseVisualStyleBackColor = false;
            this.btn_managecars.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Managedrivers
            // 
            this.btn_Managedrivers.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Managedrivers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Managedrivers.Location = new System.Drawing.Point(376, 241);
            this.btn_Managedrivers.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Managedrivers.Name = "btn_Managedrivers";
            this.btn_Managedrivers.Size = new System.Drawing.Size(366, 65);
            this.btn_Managedrivers.TabIndex = 1;
            this.btn_Managedrivers.Text = "Manage Drivers";
            this.btn_Managedrivers.UseVisualStyleBackColor = false;
            this.btn_Managedrivers.Click += new System.EventHandler(this.btn_Managedrivers_Click);
            // 
            // btn_vieworderhistory
            // 
            this.btn_vieworderhistory.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_vieworderhistory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_vieworderhistory.Location = new System.Drawing.Point(376, 345);
            this.btn_vieworderhistory.Margin = new System.Windows.Forms.Padding(4);
            this.btn_vieworderhistory.Name = "btn_vieworderhistory";
            this.btn_vieworderhistory.Size = new System.Drawing.Size(366, 65);
            this.btn_vieworderhistory.TabIndex = 2;
            this.btn_vieworderhistory.Text = "View Order History";
            this.btn_vieworderhistory.UseVisualStyleBackColor = false;
            this.btn_vieworderhistory.Click += new System.EventHandler(this.btn_vieworderhistory_Click);
            // 
            // Admin_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.btn_vieworderhistory);
            this.Controls.Add(this.btn_Managedrivers);
            this.Controls.Add(this.btn_managecars);
            this.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin_dashboard";
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.Admin_dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_managecars;
        private System.Windows.Forms.Button btn_Managedrivers;
        private System.Windows.Forms.Button btn_vieworderhistory;
    }
}