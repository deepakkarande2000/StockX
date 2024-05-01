
namespace StockX.Utility
{
    partial class FrmSettings
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
            this.pnlGeneralSettings = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLabelSpeed = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBilling = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.pnlBilling = new System.Windows.Forms.Panel();
            this.chkPendingAmountSave = new System.Windows.Forms.CheckBox();
            this.txtBillFooterDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBillprintingAfterBillSave = new System.Windows.Forms.CheckBox();
            this.btnPrinterSettings = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlPrinterSetting = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBillPrinter = new System.Windows.Forms.ComboBox();
            this.pnlGeneralSettings.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBilling.SuspendLayout();
            this.pnlPrinterSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGeneralSettings
            // 
            this.pnlGeneralSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGeneralSettings.Controls.Add(this.label2);
            this.pnlGeneralSettings.Controls.Add(this.txtLabelSpeed);
            this.pnlGeneralSettings.Location = new System.Drawing.Point(209, 36);
            this.pnlGeneralSettings.Name = "pnlGeneralSettings";
            this.pnlGeneralSettings.Size = new System.Drawing.Size(669, 438);
            this.pnlGeneralSettings.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pending amount Label Speed (Dashboard)";
            // 
            // txtLabelSpeed
            // 
            this.txtLabelSpeed.Location = new System.Drawing.Point(300, 35);
            this.txtLabelSpeed.Name = "txtLabelSpeed";
            this.txtLabelSpeed.Size = new System.Drawing.Size(100, 22);
            this.txtLabelSpeed.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(65)))), ((int)(((byte)(115)))));
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Location = new System.Drawing.Point(1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(879, 34);
            this.panel3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(823, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(209, 476);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 43);
            this.panel4.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnPrinterSettings);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btnBilling);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnGeneralSettings);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 483);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.panel5.BackgroundImage = global::StockX.Properties.Resources.receipts;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(19, 61);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 42);
            this.panel5.TabIndex = 4;
            // 
            // btnBilling
            // 
            this.btnBilling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(179)))), ((int)(((byte)(119)))));
            this.btnBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Font = new System.Drawing.Font("DaytonaPro-Semibold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBilling.Location = new System.Drawing.Point(3, 58);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(206, 46);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "Billing Settings";
            this.btnBilling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBilling.UseVisualStyleBackColor = false;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.panel2.BackgroundImage = global::StockX.Properties.Resources.Gear_icon;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(19, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 42);
            this.panel2.TabIndex = 2;
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.btnGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeneralSettings.FlatAppearance.BorderSize = 0;
            this.btnGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSettings.Font = new System.Drawing.Font("DaytonaPro-Semibold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneralSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGeneralSettings.Location = new System.Drawing.Point(3, 6);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Size = new System.Drawing.Size(206, 46);
            this.btnGeneralSettings.TabIndex = 0;
            this.btnGeneralSettings.Text = "General Settings";
            this.btnGeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneralSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGeneralSettings.UseVisualStyleBackColor = false;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnGeneralSettings_Click);
            // 
            // pnlBilling
            // 
            this.pnlBilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBilling.Controls.Add(this.chkPendingAmountSave);
            this.pnlBilling.Controls.Add(this.txtBillFooterDescription);
            this.pnlBilling.Controls.Add(this.label1);
            this.pnlBilling.Controls.Add(this.chkBillprintingAfterBillSave);
            this.pnlBilling.Location = new System.Drawing.Point(769, 340);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Size = new System.Drawing.Size(87, 19);
            this.pnlBilling.TabIndex = 2;
            // 
            // chkPendingAmountSave
            // 
            this.chkPendingAmountSave.AutoSize = true;
            this.chkPendingAmountSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkPendingAmountSave.Location = new System.Drawing.Point(51, 61);
            this.chkPendingAmountSave.Name = "chkPendingAmountSave";
            this.chkPendingAmountSave.Size = new System.Drawing.Size(340, 18);
            this.chkPendingAmountSave.TabIndex = 3;
            this.chkPendingAmountSave.Text = "Ask to save pending amount to save in database.";
            this.chkPendingAmountSave.UseVisualStyleBackColor = true;
            // 
            // txtBillFooterDescription
            // 
            this.txtBillFooterDescription.Location = new System.Drawing.Point(51, 118);
            this.txtBillFooterDescription.Multiline = true;
            this.txtBillFooterDescription.Name = "txtBillFooterDescription";
            this.txtBillFooterDescription.Size = new System.Drawing.Size(383, 61);
            this.txtBillFooterDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(48, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill Footer";
            // 
            // chkBillprintingAfterBillSave
            // 
            this.chkBillprintingAfterBillSave.AutoSize = true;
            this.chkBillprintingAfterBillSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkBillprintingAfterBillSave.Location = new System.Drawing.Point(51, 26);
            this.chkBillprintingAfterBillSave.Name = "chkBillprintingAfterBillSave";
            this.chkBillprintingAfterBillSave.Size = new System.Drawing.Size(298, 18);
            this.chkBillprintingAfterBillSave.TabIndex = 0;
            this.chkBillprintingAfterBillSave.Text = "Ask Message For Bill Printing after Bill save.";
            this.chkBillprintingAfterBillSave.UseVisualStyleBackColor = true;
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(179)))), ((int)(((byte)(119)))));
            this.btnPrinterSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrinterSettings.FlatAppearance.BorderSize = 0;
            this.btnPrinterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinterSettings.Font = new System.Drawing.Font("DaytonaPro-Semibold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrinterSettings.Location = new System.Drawing.Point(0, 111);
            this.btnPrinterSettings.Name = "btnPrinterSettings";
            this.btnPrinterSettings.Size = new System.Drawing.Size(206, 46);
            this.btnPrinterSettings.TabIndex = 5;
            this.btnPrinterSettings.Text = "Printer Settings";
            this.btnPrinterSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrinterSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrinterSettings.UseVisualStyleBackColor = false;
            this.btnPrinterSettings.Click += new System.EventHandler(this.btnPrinterSettings_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.panel6.BackgroundImage = global::StockX.Properties.Resources.print_icon;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(19, 112);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(44, 42);
            this.panel6.TabIndex = 5;
            // 
            // pnlPrinterSetting
            // 
            this.pnlPrinterSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrinterSetting.Controls.Add(this.cboBillPrinter);
            this.pnlPrinterSetting.Controls.Add(this.label3);
            this.pnlPrinterSetting.Location = new System.Drawing.Point(757, 373);
            this.pnlPrinterSetting.Name = "pnlPrinterSetting";
            this.pnlPrinterSetting.Size = new System.Drawing.Size(99, 12);
            this.pnlPrinterSetting.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(66, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bill Printer";
            // 
            // cboBillPrinter
            // 
            this.cboBillPrinter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBillPrinter.FormattingEnabled = true;
            this.cboBillPrinter.Location = new System.Drawing.Point(142, 34);
            this.cboBillPrinter.Name = "cboBillPrinter";
            this.cboBillPrinter.Size = new System.Drawing.Size(340, 26);
            this.cboBillPrinter.TabIndex = 2;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(881, 521);
            this.Controls.Add(this.pnlGeneralSettings);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBilling);
            this.Controls.Add(this.pnlPrinterSetting);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmSettings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.pnlGeneralSettings.ResumeLayout(false);
            this.pnlGeneralSettings.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlBilling.ResumeLayout(false);
            this.pnlBilling.PerformLayout();
            this.pnlPrinterSetting.ResumeLayout(false);
            this.pnlPrinterSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlGeneralSettings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGeneralSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlBilling;
        private System.Windows.Forms.CheckBox chkBillprintingAfterBillSave;
        private System.Windows.Forms.CheckBox chkPendingAmountSave;
        private System.Windows.Forms.TextBox txtBillFooterDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLabelSpeed;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnPrinterSettings;
        private System.Windows.Forms.Panel pnlPrinterSetting;
        private System.Windows.Forms.ComboBox cboBillPrinter;
        private System.Windows.Forms.Label label3;
    }
}