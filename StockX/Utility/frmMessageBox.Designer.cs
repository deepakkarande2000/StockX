namespace StockX.Utility
{
    partial class frmMessageBox
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
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlLogo.SuspendLayout();
            this.pnlLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Black;
            this.pnlLogo.BackgroundImage = global::StockX.Properties.Resources.messageBg3;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogo.Controls.Add(this.pnlLine);
            this.pnlLogo.Controls.Add(this.btnTwo);
            this.pnlLogo.Controls.Add(this.btnOne);
            this.pnlLogo.Controls.Add(this.lblMessage);
            this.pnlLogo.Location = new System.Drawing.Point(178, 36);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(774, 326);
            this.pnlLogo.TabIndex = 17;
            // 
            // pnlLine
            // 
            this.pnlLine.AccessibleDescription = " ";
            this.pnlLine.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.pnlLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLine.Controls.Add(this.panel5);
            this.pnlLine.Location = new System.Drawing.Point(0, 0);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(775, 39);
            this.pnlLine.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::StockX.Properties.Resources.logo;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(327, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(121, 35);
            this.panel5.TabIndex = 19;
            // 
            // btnTwo
            // 
            this.btnTwo.BackColor = System.Drawing.Color.Transparent;
            this.btnTwo.BackgroundImage = global::StockX.Properties.Resources.messageBg1;
            this.btnTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTwo.FlatAppearance.BorderSize = 0;
            this.btnTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTwo.Location = new System.Drawing.Point(401, 210);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(94, 32);
            this.btnTwo.TabIndex = 20;
            this.btnTwo.Text = "button1";
            this.btnTwo.UseVisualStyleBackColor = false;
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            // 
            // btnOne
            // 
            this.btnOne.BackColor = System.Drawing.Color.Transparent;
            this.btnOne.BackgroundImage = global::StockX.Properties.Resources.card2;
            this.btnOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOne.FlatAppearance.BorderSize = 0;
            this.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOne.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOne.Location = new System.Drawing.Point(252, 210);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(92, 32);
            this.btnOne.TabIndex = 19;
            this.btnOne.Text = "button1";
            this.btnOne.UseVisualStyleBackColor = false;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("DaytonaPro-Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMessage.Location = new System.Drawing.Point(350, 105);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(56, 27);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "label2";
            this.lblMessage.UseCompatibleTextRendering = true;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1121, 396);
            this.Controls.Add(this.pnlLogo);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMessageBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Panel panel5;
    }
}