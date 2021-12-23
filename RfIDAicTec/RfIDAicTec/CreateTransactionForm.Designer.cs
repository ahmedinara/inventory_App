
namespace RfIDAicTec
{
    partial class CreateTransactionForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.lblinvoice = new System.Windows.Forms.Label();
            this.lblDatetTime = new System.Windows.Forms.Label();
            this.lblCustmerSupplier = new System.Windows.Forms.Label();
            this.cbCustmerSupplier = new System.Windows.Forms.ComboBox();
            this.txtDatein = new System.Windows.Forms.DateTimePicker();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Transaction Type :";
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "Transaction in",
            "Transaction out",
            "Stock"});
            this.cbtype.Location = new System.Drawing.Point(260, 39);
            this.cbtype.Margin = new System.Windows.Forms.Padding(4);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(200, 24);
            this.cbtype.TabIndex = 20;
            this.cbtype.SelectedIndexChanged += new System.EventHandler(this.cbtype_SelectedIndexChanged);
            // 
            // lblinvoice
            // 
            this.lblinvoice.AutoSize = true;
            this.lblinvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinvoice.Location = new System.Drawing.Point(44, 94);
            this.lblinvoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblinvoice.Name = "lblinvoice";
            this.lblinvoice.Size = new System.Drawing.Size(127, 25);
            this.lblinvoice.TabIndex = 23;
            this.lblinvoice.Text = "Invoice No.:";
            this.lblinvoice.Visible = false;
            // 
            // lblDatetTime
            // 
            this.lblDatetTime.AutoSize = true;
            this.lblDatetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatetTime.Location = new System.Drawing.Point(44, 146);
            this.lblDatetTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatetTime.Name = "lblDatetTime";
            this.lblDatetTime.Size = new System.Drawing.Size(94, 25);
            this.lblDatetTime.TabIndex = 25;
            this.lblDatetTime.Text = "Date In :";
            this.lblDatetTime.Visible = false;
            // 
            // lblCustmerSupplier
            // 
            this.lblCustmerSupplier.AutoSize = true;
            this.lblCustmerSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustmerSupplier.Location = new System.Drawing.Point(44, 199);
            this.lblCustmerSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustmerSupplier.Name = "lblCustmerSupplier";
            this.lblCustmerSupplier.Size = new System.Drawing.Size(106, 25);
            this.lblCustmerSupplier.TabIndex = 27;
            this.lblCustmerSupplier.Text = "Custmer :";
            this.lblCustmerSupplier.Visible = false;
            // 
            // cbCustmerSupplier
            // 
            this.cbCustmerSupplier.FormattingEnabled = true;
            this.cbCustmerSupplier.Items.AddRange(new object[] {
            "Transaction in",
            "Transaction out",
            "Stock"});
            this.cbCustmerSupplier.Location = new System.Drawing.Point(260, 200);
            this.cbCustmerSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.cbCustmerSupplier.Name = "cbCustmerSupplier";
            this.cbCustmerSupplier.Size = new System.Drawing.Size(200, 24);
            this.cbCustmerSupplier.TabIndex = 26;
            this.cbCustmerSupplier.Visible = false;
            // 
            // txtDatein
            // 
            this.txtDatein.CustomFormat = "MM/dd/yyyy";
            this.txtDatein.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDatein.Location = new System.Drawing.Point(260, 149);
            this.txtDatein.Name = "txtDatein";
            this.txtDatein.Size = new System.Drawing.Size(200, 22);
            this.txtDatein.TabIndex = 28;
            this.txtDatein.Visible = false;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(260, 98);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(200, 22);
            this.txtInvoice.TabIndex = 29;
            this.txtInvoice.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 69);
            this.button1.TabIndex = 30;
            this.button1.Text = "Post Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.txtDatein);
            this.Controls.Add(this.lblCustmerSupplier);
            this.Controls.Add(this.cbCustmerSupplier);
            this.Controls.Add(this.lblDatetTime);
            this.Controls.Add(this.lblinvoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbtype);
            this.Name = "CreateTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateTransactionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label lblinvoice;
        private System.Windows.Forms.Label lblDatetTime;
        private System.Windows.Forms.Label lblCustmerSupplier;
        private System.Windows.Forms.ComboBox cbCustmerSupplier;
        private System.Windows.Forms.DateTimePicker txtDatein;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Button button1;
    }
}