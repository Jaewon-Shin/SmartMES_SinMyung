namespace SmartMES_SinMyung
{
    partial class P1A04_PROCESS_SUB
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
            this.panTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbKind = new System.Windows.Forms.ComboBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.tbTool = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnClose = new SmartMES_SinMyung.UserButtonA();
            this.btnSave = new SmartMES_SinMyung.UserButtonA();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.ckFinalFlag = new System.Windows.Forms.CheckBox();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.BackgroundImage = global::SmartMES_SinMyung.Properties.Resources.photo_background;
            this.panTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(629, 54);
            this.panTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "공정설계";
            // 
            // cbKind
            // 
            this.cbKind.BackColor = System.Drawing.SystemColors.Window;
            this.cbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKind.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbKind.FormattingEnabled = true;
            this.cbKind.Location = new System.Drawing.Point(213, 136);
            this.cbKind.Name = "cbKind";
            this.cbKind.Size = new System.Drawing.Size(322, 29);
            this.cbKind.TabIndex = 1;
            this.cbKind.SelectedIndexChanged += new System.EventHandler(this.cbKind_SelectedIndexChanged);
            this.cbKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbTime.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbTime.Location = new System.Drawing.Point(213, 416);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(155, 29);
            this.tbTime.TabIndex = 5;
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // tbNo
            // 
            this.tbNo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbNo.Location = new System.Drawing.Point(213, 206);
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(322, 29);
            this.tbNo.TabIndex = 2;
            this.tbNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNo.TextChanged += new System.EventHandler(this.tbNo_TextChanged);
            this.tbNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            this.tbNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(83, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "* 공정번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(83, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "* 표준공정명";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(28, 73);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // tbTool
            // 
            this.tbTool.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbTool.Location = new System.Drawing.Point(213, 346);
            this.tbTool.Name = "tbTool";
            this.tbTool.Size = new System.Drawing.Size(322, 29);
            this.tbTool.TabIndex = 4;
            this.tbTool.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTool.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(83, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "금형/외주/치공구";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(83, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "표준공정시간";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(83, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "* 공정명(내용)";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbName.Location = new System.Drawing.Point(213, 276);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(322, 29);
            this.tbName.TabIndex = 3;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_SinMyung.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_SinMyung.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(341, 578);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_SinMyung.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_SinMyung.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(185, 578);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(374, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(83, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "생산그룹";
            // 
            // cbGroup
            // 
            this.cbGroup.BackColor = System.Drawing.SystemColors.Window;
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Items.AddRange(new object[] {
            "A.자체가공",
            "X.외주처리",
            "Y.출하대기"});
            this.cbGroup.Location = new System.Drawing.Point(213, 486);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(155, 29);
            this.cbGroup.TabIndex = 6;
            // 
            // ckFinalFlag
            // 
            this.ckFinalFlag.AutoSize = true;
            this.ckFinalFlag.ForeColor = System.Drawing.Color.Blue;
            this.ckFinalFlag.Location = new System.Drawing.Point(411, 488);
            this.ckFinalFlag.Name = "ckFinalFlag";
            this.ckFinalFlag.Size = new System.Drawing.Size(141, 25);
            this.ckFinalFlag.TabIndex = 7;
            this.ckFinalFlag.Text = "마지막공정여부";
            this.ckFinalFlag.UseVisualStyleBackColor = true;
            // 
            // P1A04_PROCESS_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(629, 646);
            this.Controls.Add(this.tbTool);
            this.Controls.Add(this.ckFinalFlag);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbKind);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1A04_PROCESS_SUB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1A04_PROCESS_SUB_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbKind;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMsg;
        private UserButtonA btnSave;
        private UserButtonA btnClose;
        private System.Windows.Forms.TextBox tbTool;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.CheckBox ckFinalFlag;
    }
}