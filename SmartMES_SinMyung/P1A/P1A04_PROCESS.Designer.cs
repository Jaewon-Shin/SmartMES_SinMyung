namespace SmartMES_SinMyung
{
    partial class P1A04_PROCESS
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.cbStd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPProcessQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1A = new SmartMES_SinMyung.P1A.DataSetP1A();
            this.sP_Process_QueryTableAdapter = new SmartMES_SinMyung.P1A.DataSetP1ATableAdapters.SP_Process_QueryTableAdapter();
            this.표준공정코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.표준공정명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.치공구DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.표준공정시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산그룹 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종공정 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProcessQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1A)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "공정설계";
            // 
            // pbPrint
            // 
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDel
            // 
            this.pbDel.Image = global::SmartMES_SinMyung.Properties.Resources.del_A;
            this.pbDel.Click += new System.EventHandler(this.pbDel_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.cbStd);
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // cbStd
            // 
            this.cbStd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbStd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbStd.FormattingEnabled = true;
            this.cbStd.Location = new System.Drawing.Point(593, 20);
            this.cbStd.Name = "cbStd";
            this.cbStd.Size = new System.Drawing.Size(200, 29);
            this.cbStd.TabIndex = 1;
            this.cbStd.SelectedIndexChanged += new System.EventHandler(this.cbStd_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(499, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "표준공정명";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.표준공정코드DataGridViewTextBoxColumn,
            this.표준공정명DataGridViewTextBoxColumn,
            this.공정번호DataGridViewTextBoxColumn,
            this.공정명DataGridViewTextBoxColumn,
            this.치공구DataGridViewTextBoxColumn,
            this.표준공정시간DataGridViewTextBoxColumn,
            this.생산그룹,
            this.최종공정});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProcessQueryBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 852);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // sPProcessQueryBindingSource
            // 
            this.sPProcessQueryBindingSource.DataMember = "SP_Process_Query";
            this.sPProcessQueryBindingSource.DataSource = this.dataSetP1A;
            // 
            // dataSetP1A
            // 
            this.dataSetP1A.DataSetName = "DataSetP1A";
            this.dataSetP1A.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Process_QueryTableAdapter
            // 
            this.sP_Process_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // 표준공정코드DataGridViewTextBoxColumn
            // 
            this.표준공정코드DataGridViewTextBoxColumn.DataPropertyName = "표준공정코드";
            this.표준공정코드DataGridViewTextBoxColumn.HeaderText = "표준공정코드";
            this.표준공정코드DataGridViewTextBoxColumn.Name = "표준공정코드DataGridViewTextBoxColumn";
            this.표준공정코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.표준공정코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 표준공정명DataGridViewTextBoxColumn
            // 
            this.표준공정명DataGridViewTextBoxColumn.DataPropertyName = "표준공정명";
            this.표준공정명DataGridViewTextBoxColumn.HeaderText = "표준공정명";
            this.표준공정명DataGridViewTextBoxColumn.Name = "표준공정명DataGridViewTextBoxColumn";
            this.표준공정명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 공정번호DataGridViewTextBoxColumn
            // 
            this.공정번호DataGridViewTextBoxColumn.DataPropertyName = "공정번호";
            this.공정번호DataGridViewTextBoxColumn.HeaderText = "공정번호";
            this.공정번호DataGridViewTextBoxColumn.Name = "공정번호DataGridViewTextBoxColumn";
            this.공정번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 공정명DataGridViewTextBoxColumn
            // 
            this.공정명DataGridViewTextBoxColumn.DataPropertyName = "공정명";
            this.공정명DataGridViewTextBoxColumn.HeaderText = "공정명(내용)";
            this.공정명DataGridViewTextBoxColumn.Name = "공정명DataGridViewTextBoxColumn";
            this.공정명DataGridViewTextBoxColumn.ReadOnly = true;
            this.공정명DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.공정명DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 치공구DataGridViewTextBoxColumn
            // 
            this.치공구DataGridViewTextBoxColumn.DataPropertyName = "치공구";
            this.치공구DataGridViewTextBoxColumn.HeaderText = "금형/외주/치공구";
            this.치공구DataGridViewTextBoxColumn.Name = "치공구DataGridViewTextBoxColumn";
            this.치공구DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 표준공정시간DataGridViewTextBoxColumn
            // 
            this.표준공정시간DataGridViewTextBoxColumn.DataPropertyName = "표준공정시간";
            dataGridViewCellStyle3.Format = "0.0h";
            this.표준공정시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.표준공정시간DataGridViewTextBoxColumn.HeaderText = "표준공정시간";
            this.표준공정시간DataGridViewTextBoxColumn.Name = "표준공정시간DataGridViewTextBoxColumn";
            this.표준공정시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 생산그룹
            // 
            this.생산그룹.DataPropertyName = "생산그룹";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.생산그룹.DefaultCellStyle = dataGridViewCellStyle4;
            this.생산그룹.HeaderText = "생산그룹";
            this.생산그룹.Name = "생산그룹";
            this.생산그룹.ReadOnly = true;
            // 
            // 최종공정
            // 
            this.최종공정.DataPropertyName = "최종공정";
            this.최종공정.FillWeight = 50F;
            this.최종공정.HeaderText = "최종공정";
            this.최종공정.Name = "최종공정";
            this.최종공정.ReadOnly = true;
            // 
            // P1A04_PROCESS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1A04_PROCESS";
            this.Text = "P1A04_PROCESS";
            this.Load += new System.EventHandler(this.P1A04_PROCESS_Load);
            this.Controls.SetChildIndex(this.panSearch, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProcessQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox cbStd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource sPProcessQueryBindingSource;
        private P1A.DataSetP1A dataSetP1A;
        private P1A.DataSetP1ATableAdapters.SP_Process_QueryTableAdapter sP_Process_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 표준공정코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 표준공정명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn 공정명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 치공구DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 표준공정시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹;
        private System.Windows.Forms.DataGridViewTextBoxColumn 최종공정;
    }
}
