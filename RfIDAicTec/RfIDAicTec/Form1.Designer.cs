namespace RfIDAicTec
{
    partial class Form1
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtgridreader = new System.Windows.Forms.DataGridView();
            this.gb_ReadControl = new System.Windows.Forms.GroupBox();
            this.ANT2 = new System.Windows.Forms.CheckBox();
            this.ANT3 = new System.Windows.Forms.CheckBox();
            this.ANT1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_ReadType = new System.Windows.Forms.GroupBox();
            this.rb_Single = new System.Windows.Forms.RadioButton();
            this.rb_While = new System.Windows.Forms.RadioButton();
            this.gb_TagType = new System.Windows.Forms.GroupBox();
            this.rb_6b = new System.Windows.Forms.RadioButton();
            this.rb_gb = new System.Windows.Forms.RadioButton();
            this.rb_6c = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_ReceiveCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_DebugMsg = new System.Windows.Forms.TextBox();
            this.clm_ReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TagType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_EPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_UserData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ReserveData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridreader)).BeginInit();
            this.gb_ReadControl.SuspendLayout();
            this.gb_ReadType.SuspendLayout();
            this.gb_TagType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ip Address :";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(135, 11);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(186, 20);
            this.txtIpAddress.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnConnect);
            this.flowLayoutPanel1.Controls.Add(this.btnRead);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(27, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(409, 67);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnect.Location = new System.Drawing.Point(3, 3);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(95, 60);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click_1);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(104, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(95, 60);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Read Data";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(205, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close Connection";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtgridreader
            // 
            this.dtgridreader.AllowUserToAddRows = false;
            this.dtgridreader.AllowUserToDeleteRows = false;
            this.dtgridreader.AllowUserToResizeRows = false;
            this.dtgridreader.BackgroundColor = System.Drawing.Color.White;
            this.dtgridreader.CausesValidation = false;
            this.dtgridreader.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dtgridreader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgridreader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_ReaderName,
            this.clm_TagType,
            this.clm_EPC,
            this.clm_TID,
            this.clm_UserData,
            this.clm_ReserveData,
            this.clm_TotalCount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgridreader.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgridreader.GridColor = System.Drawing.Color.Blue;
            this.dtgridreader.Location = new System.Drawing.Point(9, 121);
            this.dtgridreader.MultiSelect = false;
            this.dtgridreader.Name = "dtgridreader";
            this.dtgridreader.ReadOnly = true;
            this.dtgridreader.RowTemplate.Height = 23;
            this.dtgridreader.Size = new System.Drawing.Size(661, 347);
            this.dtgridreader.TabIndex = 14;
            // 
            // gb_ReadControl
            // 
            this.gb_ReadControl.Controls.Add(this.ANT2);
            this.gb_ReadControl.Controls.Add(this.ANT3);
            this.gb_ReadControl.Controls.Add(this.ANT1);
            this.gb_ReadControl.Controls.Add(this.button2);
            this.gb_ReadControl.Controls.Add(this.button1);
            this.gb_ReadControl.Controls.Add(this.gb_ReadType);
            this.gb_ReadControl.Controls.Add(this.gb_TagType);
            this.gb_ReadControl.Location = new System.Drawing.Point(694, 9);
            this.gb_ReadControl.Name = "gb_ReadControl";
            this.gb_ReadControl.Size = new System.Drawing.Size(280, 243);
            this.gb_ReadControl.TabIndex = 16;
            this.gb_ReadControl.TabStop = false;
            this.gb_ReadControl.Text = "Control：";
            // 
            // ANT2
            // 
            this.ANT2.AutoSize = true;
            this.ANT2.Location = new System.Drawing.Point(147, 20);
            this.ANT2.Name = "ANT2";
            this.ANT2.Size = new System.Drawing.Size(54, 17);
            this.ANT2.TabIndex = 45;
            this.ANT2.Tag = "2";
            this.ANT2.Text = "ANT2";
            this.ANT2.UseVisualStyleBackColor = true;
            // 
            // ANT3
            // 
            this.ANT3.AutoSize = true;
            this.ANT3.Location = new System.Drawing.Point(50, 43);
            this.ANT3.Name = "ANT3";
            this.ANT3.Size = new System.Drawing.Size(54, 17);
            this.ANT3.TabIndex = 44;
            this.ANT3.Tag = "3";
            this.ANT3.Text = "ANT3";
            this.ANT3.UseVisualStyleBackColor = true;
            // 
            // ANT1
            // 
            this.ANT1.AutoSize = true;
            this.ANT1.Checked = true;
            this.ANT1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ANT1.Location = new System.Drawing.Point(50, 20);
            this.ANT1.Name = "ANT1";
            this.ANT1.Size = new System.Drawing.Size(54, 17);
            this.ANT1.TabIndex = 38;
            this.ANT1.Tag = "1";
            this.ANT1.Text = "ANT1";
            this.ANT1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(152, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Uncheck All";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(43, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check All";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gb_ReadType
            // 
            this.gb_ReadType.Controls.Add(this.rb_Single);
            this.gb_ReadType.Controls.Add(this.rb_While);
            this.gb_ReadType.Location = new System.Drawing.Point(36, 109);
            this.gb_ReadType.Name = "gb_ReadType";
            this.gb_ReadType.Size = new System.Drawing.Size(216, 54);
            this.gb_ReadType.TabIndex = 37;
            this.gb_ReadType.TabStop = false;
            this.gb_ReadType.Text = "ReadType：";
            // 
            // rb_Single
            // 
            this.rb_Single.AutoSize = true;
            this.rb_Single.Location = new System.Drawing.Point(131, 19);
            this.rb_Single.Name = "rb_Single";
            this.rb_Single.Size = new System.Drawing.Size(54, 17);
            this.rb_Single.TabIndex = 1;
            this.rb_Single.Tag = "0";
            this.rb_Single.Text = "Single";
            this.rb_Single.UseVisualStyleBackColor = true;
            // 
            // rb_While
            // 
            this.rb_While.AutoSize = true;
            this.rb_While.Checked = true;
            this.rb_While.Location = new System.Drawing.Point(14, 19);
            this.rb_While.Name = "rb_While";
            this.rb_While.Size = new System.Drawing.Size(69, 17);
            this.rb_While.TabIndex = 0;
            this.rb_While.TabStop = true;
            this.rb_While.Tag = "1";
            this.rb_While.Text = "Inventory";
            this.rb_While.UseVisualStyleBackColor = true;
            // 
            // gb_TagType
            // 
            this.gb_TagType.Controls.Add(this.rb_6b);
            this.gb_TagType.Controls.Add(this.rb_gb);
            this.gb_TagType.Controls.Add(this.rb_6c);
            this.gb_TagType.Location = new System.Drawing.Point(36, 170);
            this.gb_TagType.Name = "gb_TagType";
            this.gb_TagType.Size = new System.Drawing.Size(216, 60);
            this.gb_TagType.TabIndex = 36;
            this.gb_TagType.TabStop = false;
            this.gb_TagType.Text = "Tag Type：";
            // 
            // rb_6b
            // 
            this.rb_6b.AutoSize = true;
            this.rb_6b.Location = new System.Drawing.Point(80, 22);
            this.rb_6b.Name = "rb_6b";
            this.rb_6b.Size = new System.Drawing.Size(60, 17);
            this.rb_6b.TabIndex = 4;
            this.rb_6b.Tag = "0";
            this.rb_6b.Text = "6B Tag";
            this.rb_6b.UseVisualStyleBackColor = true;
            // 
            // rb_gb
            // 
            this.rb_gb.AutoSize = true;
            this.rb_gb.Location = new System.Drawing.Point(147, 22);
            this.rb_gb.Name = "rb_gb";
            this.rb_gb.Size = new System.Drawing.Size(62, 17);
            this.rb_gb.TabIndex = 3;
            this.rb_gb.Tag = "0";
            this.rb_gb.Text = "GB Tag";
            this.rb_gb.UseVisualStyleBackColor = true;
            // 
            // rb_6c
            // 
            this.rb_6c.AutoSize = true;
            this.rb_6c.Checked = true;
            this.rb_6c.Location = new System.Drawing.Point(14, 22);
            this.rb_6c.Name = "rb_6c";
            this.rb_6c.Size = new System.Drawing.Size(60, 17);
            this.rb_6c.TabIndex = 2;
            this.rb_6c.TabStop = true;
            this.rb_6c.Tag = "1";
            this.rb_6c.Text = "6C Tag";
            this.rb_6c.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lb_ReceiveCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(694, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 227);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Real-time：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(61, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "GPI：";
            // 
            // lb_ReceiveCount
            // 
            this.lb_ReceiveCount.AutoSize = true;
            this.lb_ReceiveCount.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.lb_ReceiveCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_ReceiveCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_ReceiveCount.Location = new System.Drawing.Point(114, 74);
            this.lb_ReceiveCount.Name = "lb_ReceiveCount";
            this.lb_ReceiveCount.Size = new System.Drawing.Size(16, 16);
            this.lb_ReceiveCount.TabIndex = 4;
            this.lb_ReceiveCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(27, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Time(S)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed(T/S)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ReadCount：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TagCount：";
            // 
            // tb_DebugMsg
            // 
            this.tb_DebugMsg.Location = new System.Drawing.Point(527, 76);
            this.tb_DebugMsg.Name = "tb_DebugMsg";
            this.tb_DebugMsg.Size = new System.Drawing.Size(100, 20);
            this.tb_DebugMsg.TabIndex = 17;
            this.tb_DebugMsg.Visible = false;
            // 
            // clm_ReaderName
            // 
            this.clm_ReaderName.HeaderText = "Reader";
            this.clm_ReaderName.Name = "clm_ReaderName";
            this.clm_ReaderName.ReadOnly = true;
            this.clm_ReaderName.Visible = false;
            // 
            // clm_TagType
            // 
            this.clm_TagType.HeaderText = "Type";
            this.clm_TagType.Name = "clm_TagType";
            this.clm_TagType.ReadOnly = true;
            // 
            // clm_EPC
            // 
            this.clm_EPC.HeaderText = "Epc";
            this.clm_EPC.Name = "clm_EPC";
            this.clm_EPC.ReadOnly = true;
            // 
            // clm_TID
            // 
            this.clm_TID.HeaderText = "TID";
            this.clm_TID.Name = "clm_TID";
            this.clm_TID.ReadOnly = true;
            // 
            // clm_UserData
            // 
            this.clm_UserData.HeaderText = "UserData";
            this.clm_UserData.Name = "clm_UserData";
            this.clm_UserData.ReadOnly = true;
            // 
            // clm_ReserveData
            // 
            this.clm_ReserveData.HeaderText = "ReserveData";
            this.clm_ReserveData.Name = "clm_ReserveData";
            this.clm_ReserveData.ReadOnly = true;
            // 
            // clm_TotalCount
            // 
            this.clm_TotalCount.HeaderText = "TotalCount";
            this.clm_TotalCount.Name = "clm_TotalCount";
            this.clm_TotalCount.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(306, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 60);
            this.button3.TabIndex = 12;
            this.button3.Text = "Send To Client";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "Transaction in",
            "Transaction out",
            "Stock"});
            this.cbtype.Location = new System.Drawing.Point(489, 10);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(151, 21);
            this.cbtype.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Transaction Type :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 546);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbtype);
            this.Controls.Add(this.tb_DebugMsg);
            this.Controls.Add(this.gb_ReadControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtgridreader);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIpAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridreader)).EndInit();
            this.gb_ReadControl.ResumeLayout(false);
            this.gb_ReadControl.PerformLayout();
            this.gb_ReadType.ResumeLayout(false);
            this.gb_ReadType.PerformLayout();
            this.gb_TagType.ResumeLayout(false);
            this.gb_TagType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dtgridreader;
        private System.Windows.Forms.GroupBox gb_ReadControl;
        private System.Windows.Forms.CheckBox ANT2;
        private System.Windows.Forms.CheckBox ANT3;
        private System.Windows.Forms.CheckBox ANT1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gb_ReadType;
        private System.Windows.Forms.RadioButton rb_Single;
        private System.Windows.Forms.RadioButton rb_While;
        private System.Windows.Forms.GroupBox gb_TagType;
        private System.Windows.Forms.RadioButton rb_6b;
        private System.Windows.Forms.RadioButton rb_gb;
        private System.Windows.Forms.RadioButton rb_6c;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_ReceiveCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_DebugMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TagType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_EPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_UserData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReserveData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TotalCount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label7;
    }
}

