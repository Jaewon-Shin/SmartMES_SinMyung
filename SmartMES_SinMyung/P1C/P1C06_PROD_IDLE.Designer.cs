namespace SmartMES_SinMyung
{
    partial class P1C06_PROD_IDLE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.cbGrp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.운전자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.규격DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.양품DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동시작DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동종료DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사유DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPProdIdleQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_SinMyung.P1C.DataSetP1C();
            this.sP_ProdIdle_QueryTableAdapter = new SmartMES_SinMyung.P1C.DataSetP1CTableAdapters.SP_ProdIdle_QueryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdIdleQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "설비비가동현황";
            // 
            // pbPrint
            // 
            this.pbPrint.Enabled = true;
            this.pbPrint.Image = global::SmartMES_SinMyung.Properties.Resources.out_A;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDel
            // 
            this.pbDel.Enabled = false;
            this.pbDel.Image = global::SmartMES_SinMyung.Properties.Resources.del_B;
            this.pbDel.Click += new System.EventHandler(this.pbDel_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Enabled = false;
            this.pbAdd.Image = global::SmartMES_SinMyung.Properties.Resources.add_B;
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
            this.panSearch.Controls.Add(this.cbGrp);
            this.panSearch.Controls.Add(this.label4);
            this.panSearch.Controls.Add(this.cbItem);
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.dtpToDate);
            this.panSearch.Controls.Add(this.dtpFromDate);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // cbGrp
            // 
            this.cbGrp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrp.FormattingEnabled = true;
            this.cbGrp.Items.AddRange(new object[] {
            "<전체>",
            "A.CNC",
            "B.MCT",
            "C.5축가공기",
            "D.범용가공기",
            "E.제품생산"});
            this.cbGrp.Location = new System.Drawing.Point(1083, 20);
            this.cbGrp.Name = "cbGrp";
            this.cbGrp.Size = new System.Drawing.Size(133, 29);
            this.cbGrp.TabIndex = 4;
            this.cbGrp.SelectedIndexChanged += new System.EventHandler(this.cbGrp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(671, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "비가동사유";
            // 
            // cbItem
            // 
            this.cbItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(764, 20);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(166, 29);
            this.cbItem.TabIndex = 3;
            this.cbItem.SelectedIndexChanged += new System.EventHandler(this.cbItem_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(352, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "~";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(62, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "생산기간";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Location = new System.Drawing.Point(375, 20);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(211, 29);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Location = new System.Drawing.Point(139, 20);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(211, 29);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(1006, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "생산그룹";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.일자DataGridViewTextBoxColumn,
            this.설비명DataGridViewTextBoxColumn,
            this.운전자DataGridViewTextBoxColumn,
            this.품목IDDataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.제품명DataGridViewTextBoxColumn,
            this.규격DataGridViewTextBoxColumn,
            this.양품DataGridViewTextBoxColumn,
            this.불량DataGridViewTextBoxColumn,
            this.작업시간DataGridViewTextBoxColumn,
            this.jobNoDataGridViewTextBoxColumn,
            this.설비IDDataGridViewTextBoxColumn,
            this.비가동시작DataGridViewTextBoxColumn,
            this.비가동종료DataGridViewTextBoxColumn,
            this.시간DataGridViewTextBoxColumn,
            this.비가동IDDataGridViewTextBoxColumn,
            this.사유DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdIdleQueryBindingSource;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 852);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // 일자DataGridViewTextBoxColumn
            // 
            this.일자DataGridViewTextBoxColumn.DataPropertyName = "일자";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.Format = "MM\\/dd";
            this.일자DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.일자DataGridViewTextBoxColumn.FillWeight = 50F;
            this.일자DataGridViewTextBoxColumn.HeaderText = "일자";
            this.일자DataGridViewTextBoxColumn.Name = "일자DataGridViewTextBoxColumn";
            this.일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 설비명DataGridViewTextBoxColumn
            // 
            this.설비명DataGridViewTextBoxColumn.DataPropertyName = "설비명";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            this.설비명DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.설비명DataGridViewTextBoxColumn.HeaderText = "설비명";
            this.설비명DataGridViewTextBoxColumn.Name = "설비명DataGridViewTextBoxColumn";
            this.설비명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 운전자DataGridViewTextBoxColumn
            // 
            this.운전자DataGridViewTextBoxColumn.DataPropertyName = "운전자";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.운전자DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.운전자DataGridViewTextBoxColumn.FillWeight = 60F;
            this.운전자DataGridViewTextBoxColumn.HeaderText = "운전자";
            this.운전자DataGridViewTextBoxColumn.Name = "운전자DataGridViewTextBoxColumn";
            this.운전자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 품목IDDataGridViewTextBoxColumn
            // 
            this.품목IDDataGridViewTextBoxColumn.DataPropertyName = "품목ID";
            this.품목IDDataGridViewTextBoxColumn.HeaderText = "품목ID";
            this.품목IDDataGridViewTextBoxColumn.Name = "품목IDDataGridViewTextBoxColumn";
            this.품목IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.품목IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목명DataGridViewTextBoxColumn
            // 
            this.품목명DataGridViewTextBoxColumn.DataPropertyName = "품목명";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.품목명DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            this.품목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 제품명DataGridViewTextBoxColumn
            // 
            this.제품명DataGridViewTextBoxColumn.DataPropertyName = "제품명";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Beige;
            this.제품명DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.제품명DataGridViewTextBoxColumn.HeaderText = "제품명";
            this.제품명DataGridViewTextBoxColumn.Name = "제품명DataGridViewTextBoxColumn";
            this.제품명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 규격DataGridViewTextBoxColumn
            // 
            this.규격DataGridViewTextBoxColumn.DataPropertyName = "규격";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.규격DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.규격DataGridViewTextBoxColumn.HeaderText = "규격";
            this.규격DataGridViewTextBoxColumn.Name = "규격DataGridViewTextBoxColumn";
            this.규격DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 양품DataGridViewTextBoxColumn
            // 
            this.양품DataGridViewTextBoxColumn.DataPropertyName = "양품";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle8.Format = "#,##0";
            this.양품DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.양품DataGridViewTextBoxColumn.FillWeight = 60F;
            this.양품DataGridViewTextBoxColumn.HeaderText = "양품";
            this.양품DataGridViewTextBoxColumn.Name = "양품DataGridViewTextBoxColumn";
            this.양품DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 불량DataGridViewTextBoxColumn
            // 
            this.불량DataGridViewTextBoxColumn.DataPropertyName = "불량";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle9.Format = "#,##0";
            this.불량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.불량DataGridViewTextBoxColumn.FillWeight = 60F;
            this.불량DataGridViewTextBoxColumn.HeaderText = "불량";
            this.불량DataGridViewTextBoxColumn.Name = "불량DataGridViewTextBoxColumn";
            this.불량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업시간DataGridViewTextBoxColumn
            // 
            this.작업시간DataGridViewTextBoxColumn.DataPropertyName = "작업시간";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle10.Format = "#,##0.00h";
            this.작업시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.작업시간DataGridViewTextBoxColumn.FillWeight = 60F;
            this.작업시간DataGridViewTextBoxColumn.HeaderText = "작업";
            this.작업시간DataGridViewTextBoxColumn.Name = "작업시간DataGridViewTextBoxColumn";
            this.작업시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jobNoDataGridViewTextBoxColumn
            // 
            this.jobNoDataGridViewTextBoxColumn.DataPropertyName = "JobNo";
            this.jobNoDataGridViewTextBoxColumn.HeaderText = "JobNo";
            this.jobNoDataGridViewTextBoxColumn.Name = "jobNoDataGridViewTextBoxColumn";
            this.jobNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // 설비IDDataGridViewTextBoxColumn
            // 
            this.설비IDDataGridViewTextBoxColumn.DataPropertyName = "설비ID";
            this.설비IDDataGridViewTextBoxColumn.HeaderText = "설비ID";
            this.설비IDDataGridViewTextBoxColumn.Name = "설비IDDataGridViewTextBoxColumn";
            this.설비IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.설비IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 비가동시작DataGridViewTextBoxColumn
            // 
            this.비가동시작DataGridViewTextBoxColumn.DataPropertyName = "비가동시작";
            dataGridViewCellStyle11.Format = "HH:mm:ss";
            this.비가동시작DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.비가동시작DataGridViewTextBoxColumn.FillWeight = 80F;
            this.비가동시작DataGridViewTextBoxColumn.HeaderText = "비가동시작";
            this.비가동시작DataGridViewTextBoxColumn.Name = "비가동시작DataGridViewTextBoxColumn";
            this.비가동시작DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비가동종료DataGridViewTextBoxColumn
            // 
            this.비가동종료DataGridViewTextBoxColumn.DataPropertyName = "비가동종료";
            dataGridViewCellStyle12.Format = "HH:mm:ss";
            this.비가동종료DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.비가동종료DataGridViewTextBoxColumn.FillWeight = 80F;
            this.비가동종료DataGridViewTextBoxColumn.HeaderText = "비가동종료";
            this.비가동종료DataGridViewTextBoxColumn.Name = "비가동종료DataGridViewTextBoxColumn";
            this.비가동종료DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 시간DataGridViewTextBoxColumn
            // 
            this.시간DataGridViewTextBoxColumn.DataPropertyName = "시간";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#,##0.00h";
            this.시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.시간DataGridViewTextBoxColumn.FillWeight = 60F;
            this.시간DataGridViewTextBoxColumn.HeaderText = "시간";
            this.시간DataGridViewTextBoxColumn.Name = "시간DataGridViewTextBoxColumn";
            this.시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비가동IDDataGridViewTextBoxColumn
            // 
            this.비가동IDDataGridViewTextBoxColumn.DataPropertyName = "비가동ID";
            this.비가동IDDataGridViewTextBoxColumn.HeaderText = "비가동ID";
            this.비가동IDDataGridViewTextBoxColumn.Name = "비가동IDDataGridViewTextBoxColumn";
            this.비가동IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.비가동IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 사유DataGridViewTextBoxColumn
            // 
            this.사유DataGridViewTextBoxColumn.DataPropertyName = "사유";
            this.사유DataGridViewTextBoxColumn.HeaderText = "사유";
            this.사유DataGridViewTextBoxColumn.Name = "사유DataGridViewTextBoxColumn";
            this.사유DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPProdIdleQueryBindingSource
            // 
            this.sPProdIdleQueryBindingSource.DataMember = "SP_ProdIdle_Query";
            this.sPProdIdleQueryBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ProdIdle_QueryTableAdapter
            // 
            this.sP_ProdIdle_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // P1C06_PROD_IDLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1C06_PROD_IDLE";
            this.Text = "P1C06_PROD_IDLE";
            this.Activated += new System.EventHandler(this.P1C06_PROD_IDLE_Activated);
            this.Load += new System.EventHandler(this.P1C06_PROD_IDLE_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.sPProdIdleQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.ComboBox cbGrp;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.BindingSource sPProdIdleQueryBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_ProdIdle_QueryTableAdapter sP_ProdIdle_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 운전자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 양품DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동시작DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동종료DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 사유DataGridViewTextBoxColumn;
    }
}
