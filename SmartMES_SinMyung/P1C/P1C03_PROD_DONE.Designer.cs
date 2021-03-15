namespace SmartMES_SinMyung
{
    partial class P1C03_PROD_DONE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.userButtonA2 = new SmartMES_SinMyung.UserButtonA();
            this.userButtonA1 = new SmartMES_SinMyung.UserButtonA();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.생산그룹DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.호기DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.운전자IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.운전자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.규격DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.양품수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산합계DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량사유DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량내역DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업시작DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업종료DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.소요시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.실가동DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종공정여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.sPProdDoneQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_SinMyung.P1C.DataSetP1C();
            this.sP_ProdDone_QueryTableAdapter = new SmartMES_SinMyung.P1C.DataSetP1CTableAdapters.SP_ProdDone_QueryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdDoneQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "생산완료현황";
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
            this.panSearch.Controls.Add(this.userButtonA2);
            this.panSearch.Controls.Add(this.userButtonA1);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.dtpDate);
            this.panSearch.Controls.Add(this.cbPart);
            this.panSearch.Controls.Add(this.label7);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // userButtonA2
            // 
            this.userButtonA2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userButtonA2.BackColor = System.Drawing.Color.Transparent;
            this.userButtonA2.BackgroundImage = global::SmartMES_SinMyung.Properties.Resources.right2;
            this.userButtonA2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userButtonA2.buttonImage = global::SmartMES_SinMyung.Properties.Resources.right2;
            this.userButtonA2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userButtonA2.Location = new System.Drawing.Point(768, 24);
            this.userButtonA2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButtonA2.Name = "userButtonA2";
            this.userButtonA2.Size = new System.Drawing.Size(60, 20);
            this.userButtonA2.TabIndex = 3;
            this.userButtonA2.Click += new System.EventHandler(this.userButtonA2_Click);
            // 
            // userButtonA1
            // 
            this.userButtonA1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userButtonA1.BackColor = System.Drawing.Color.Transparent;
            this.userButtonA1.BackgroundImage = global::SmartMES_SinMyung.Properties.Resources.left2;
            this.userButtonA1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userButtonA1.buttonImage = global::SmartMES_SinMyung.Properties.Resources.left2;
            this.userButtonA1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userButtonA1.Location = new System.Drawing.Point(487, 24);
            this.userButtonA1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButtonA1.Name = "userButtonA1";
            this.userButtonA1.Size = new System.Drawing.Size(60, 20);
            this.userButtonA1.TabIndex = 1;
            this.userButtonA1.Click += new System.EventHandler(this.userButtonA1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(407, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "생산일자";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Location = new System.Drawing.Point(552, 20);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(211, 29);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cbPart
            // 
            this.cbPart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Items.AddRange(new object[] {
            "A조",
            "B조",
            "C조"});
            this.cbPart.Location = new System.Drawing.Point(963, 19);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(117, 29);
            this.cbPart.TabIndex = 4;
            this.cbPart.Visible = false;
            this.cbPart.SelectedIndexChanged += new System.EventHandler(this.cbPart_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(902, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "작업조";
            this.label7.Visible = false;
            // 
            // dataGridView1
            // 
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
            this.ColDel,
            this.생산그룹DataGridViewTextBoxColumn,
            this.jobNoDataGridViewTextBoxColumn,
            this.설비코드DataGridViewTextBoxColumn,
            this.호기DataGridViewTextBoxColumn,
            this.설비명DataGridViewTextBoxColumn,
            this.운전자IDDataGridViewTextBoxColumn,
            this.운전자DataGridViewTextBoxColumn,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.제품명DataGridViewTextBoxColumn,
            this.규격DataGridViewTextBoxColumn,
            this.양품수량DataGridViewTextBoxColumn,
            this.불량수량DataGridViewTextBoxColumn,
            this.생산합계DataGridViewTextBoxColumn,
            this.불량사유DataGridViewTextBoxColumn,
            this.불량내역DataGridViewTextBoxColumn,
            this.작업시작DataGridViewTextBoxColumn,
            this.작업종료DataGridViewTextBoxColumn,
            this.소요시간DataGridViewTextBoxColumn,
            this.비가동DataGridViewTextBoxColumn,
            this.실가동DataGridViewTextBoxColumn,
            this.비고DataGridViewTextBoxColumn,
            this.최종공정여부,
            this.수주번호,
            this.수주순번,
            this.공정번호,
            this.공정});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdDoneQueryBindingSource;
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
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // ColDel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "X";
            this.ColDel.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColDel.FillWeight = 30F;
            this.ColDel.HeaderText = "";
            this.ColDel.Name = "ColDel";
            this.ColDel.ReadOnly = true;
            this.ColDel.Text = "X";
            // 
            // 생산그룹DataGridViewTextBoxColumn
            // 
            this.생산그룹DataGridViewTextBoxColumn.DataPropertyName = "생산그룹";
            this.생산그룹DataGridViewTextBoxColumn.HeaderText = "생산그룹";
            this.생산그룹DataGridViewTextBoxColumn.Name = "생산그룹DataGridViewTextBoxColumn";
            this.생산그룹DataGridViewTextBoxColumn.ReadOnly = true;
            this.생산그룹DataGridViewTextBoxColumn.Visible = false;
            // 
            // jobNoDataGridViewTextBoxColumn
            // 
            this.jobNoDataGridViewTextBoxColumn.DataPropertyName = "JobNo";
            this.jobNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.jobNoDataGridViewTextBoxColumn.Name = "jobNoDataGridViewTextBoxColumn";
            this.jobNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 설비코드DataGridViewTextBoxColumn
            // 
            this.설비코드DataGridViewTextBoxColumn.DataPropertyName = "설비코드";
            this.설비코드DataGridViewTextBoxColumn.HeaderText = "설비코드";
            this.설비코드DataGridViewTextBoxColumn.Name = "설비코드DataGridViewTextBoxColumn";
            this.설비코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.설비코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 호기DataGridViewTextBoxColumn
            // 
            this.호기DataGridViewTextBoxColumn.DataPropertyName = "호기";
            this.호기DataGridViewTextBoxColumn.HeaderText = "호기";
            this.호기DataGridViewTextBoxColumn.Name = "호기DataGridViewTextBoxColumn";
            this.호기DataGridViewTextBoxColumn.ReadOnly = true;
            this.호기DataGridViewTextBoxColumn.Visible = false;
            // 
            // 설비명DataGridViewTextBoxColumn
            // 
            this.설비명DataGridViewTextBoxColumn.DataPropertyName = "설비명";
            this.설비명DataGridViewTextBoxColumn.FillWeight = 150F;
            this.설비명DataGridViewTextBoxColumn.HeaderText = "설비명";
            this.설비명DataGridViewTextBoxColumn.Name = "설비명DataGridViewTextBoxColumn";
            this.설비명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 운전자IDDataGridViewTextBoxColumn
            // 
            this.운전자IDDataGridViewTextBoxColumn.DataPropertyName = "운전자ID";
            this.운전자IDDataGridViewTextBoxColumn.HeaderText = "운전자ID";
            this.운전자IDDataGridViewTextBoxColumn.Name = "운전자IDDataGridViewTextBoxColumn";
            this.운전자IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.운전자IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 운전자DataGridViewTextBoxColumn
            // 
            this.운전자DataGridViewTextBoxColumn.DataPropertyName = "운전자";
            this.운전자DataGridViewTextBoxColumn.HeaderText = "운전자";
            this.운전자DataGridViewTextBoxColumn.Name = "운전자DataGridViewTextBoxColumn";
            this.운전자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 품목코드DataGridViewTextBoxColumn
            // 
            this.품목코드DataGridViewTextBoxColumn.DataPropertyName = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.HeaderText = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.Name = "품목코드DataGridViewTextBoxColumn";
            this.품목코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.품목코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목명DataGridViewTextBoxColumn
            // 
            this.품목명DataGridViewTextBoxColumn.DataPropertyName = "품목명";
            this.품목명DataGridViewTextBoxColumn.FillWeight = 150F;
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            this.품목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 제품명DataGridViewTextBoxColumn
            // 
            this.제품명DataGridViewTextBoxColumn.DataPropertyName = "제품명";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.제품명DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.제품명DataGridViewTextBoxColumn.FillWeight = 150F;
            this.제품명DataGridViewTextBoxColumn.HeaderText = "제품명";
            this.제품명DataGridViewTextBoxColumn.Name = "제품명DataGridViewTextBoxColumn";
            this.제품명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 규격DataGridViewTextBoxColumn
            // 
            this.규격DataGridViewTextBoxColumn.DataPropertyName = "규격";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.규격DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.규격DataGridViewTextBoxColumn.HeaderText = "규격";
            this.규격DataGridViewTextBoxColumn.Name = "규격DataGridViewTextBoxColumn";
            this.규격DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 양품수량DataGridViewTextBoxColumn
            // 
            this.양품수량DataGridViewTextBoxColumn.DataPropertyName = "양품수량";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.양품수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.양품수량DataGridViewTextBoxColumn.HeaderText = "양품";
            this.양품수량DataGridViewTextBoxColumn.Name = "양품수량DataGridViewTextBoxColumn";
            this.양품수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 불량수량DataGridViewTextBoxColumn
            // 
            this.불량수량DataGridViewTextBoxColumn.DataPropertyName = "불량수량";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.불량수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.불량수량DataGridViewTextBoxColumn.HeaderText = "불량";
            this.불량수량DataGridViewTextBoxColumn.Name = "불량수량DataGridViewTextBoxColumn";
            this.불량수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 생산합계DataGridViewTextBoxColumn
            // 
            this.생산합계DataGridViewTextBoxColumn.DataPropertyName = "생산합계";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.생산합계DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.생산합계DataGridViewTextBoxColumn.HeaderText = "합계";
            this.생산합계DataGridViewTextBoxColumn.Name = "생산합계DataGridViewTextBoxColumn";
            this.생산합계DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 불량사유DataGridViewTextBoxColumn
            // 
            this.불량사유DataGridViewTextBoxColumn.DataPropertyName = "불량사유";
            this.불량사유DataGridViewTextBoxColumn.HeaderText = "불량사유";
            this.불량사유DataGridViewTextBoxColumn.Name = "불량사유DataGridViewTextBoxColumn";
            this.불량사유DataGridViewTextBoxColumn.ReadOnly = true;
            this.불량사유DataGridViewTextBoxColumn.Visible = false;
            // 
            // 불량내역DataGridViewTextBoxColumn
            // 
            this.불량내역DataGridViewTextBoxColumn.DataPropertyName = "불량내역";
            this.불량내역DataGridViewTextBoxColumn.HeaderText = "불량내역";
            this.불량내역DataGridViewTextBoxColumn.Name = "불량내역DataGridViewTextBoxColumn";
            this.불량내역DataGridViewTextBoxColumn.ReadOnly = true;
            this.불량내역DataGridViewTextBoxColumn.Visible = false;
            // 
            // 작업시작DataGridViewTextBoxColumn
            // 
            this.작업시작DataGridViewTextBoxColumn.DataPropertyName = "작업시작";
            dataGridViewCellStyle9.Format = "HH:mm:ss";
            this.작업시작DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.작업시작DataGridViewTextBoxColumn.FillWeight = 120F;
            this.작업시작DataGridViewTextBoxColumn.HeaderText = "작업시작";
            this.작업시작DataGridViewTextBoxColumn.Name = "작업시작DataGridViewTextBoxColumn";
            this.작업시작DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업종료DataGridViewTextBoxColumn
            // 
            this.작업종료DataGridViewTextBoxColumn.DataPropertyName = "작업종료";
            dataGridViewCellStyle10.Format = "HH:mm:ss";
            this.작업종료DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.작업종료DataGridViewTextBoxColumn.FillWeight = 120F;
            this.작업종료DataGridViewTextBoxColumn.HeaderText = "작업종료";
            this.작업종료DataGridViewTextBoxColumn.Name = "작업종료DataGridViewTextBoxColumn";
            this.작업종료DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 소요시간DataGridViewTextBoxColumn
            // 
            this.소요시간DataGridViewTextBoxColumn.DataPropertyName = "소요시간";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#,##0.00h";
            this.소요시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.소요시간DataGridViewTextBoxColumn.HeaderText = "소요시간";
            this.소요시간DataGridViewTextBoxColumn.Name = "소요시간DataGridViewTextBoxColumn";
            this.소요시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비가동DataGridViewTextBoxColumn
            // 
            this.비가동DataGridViewTextBoxColumn.DataPropertyName = "비가동";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0.00h";
            this.비가동DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.비가동DataGridViewTextBoxColumn.HeaderText = "비가동";
            this.비가동DataGridViewTextBoxColumn.Name = "비가동DataGridViewTextBoxColumn";
            this.비가동DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 실가동DataGridViewTextBoxColumn
            // 
            this.실가동DataGridViewTextBoxColumn.DataPropertyName = "실가동";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#,##0.00h";
            this.실가동DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.실가동DataGridViewTextBoxColumn.HeaderText = "실가동";
            this.실가동DataGridViewTextBoxColumn.Name = "실가동DataGridViewTextBoxColumn";
            this.실가동DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비고DataGridViewTextBoxColumn
            // 
            this.비고DataGridViewTextBoxColumn.DataPropertyName = "비고";
            this.비고DataGridViewTextBoxColumn.HeaderText = "비고";
            this.비고DataGridViewTextBoxColumn.Name = "비고DataGridViewTextBoxColumn";
            this.비고DataGridViewTextBoxColumn.ReadOnly = true;
            this.비고DataGridViewTextBoxColumn.Visible = false;
            // 
            // 최종공정여부
            // 
            this.최종공정여부.DataPropertyName = "최종공정여부";
            this.최종공정여부.HeaderText = "최종공정여부";
            this.최종공정여부.Name = "최종공정여부";
            this.최종공정여부.ReadOnly = true;
            this.최종공정여부.Visible = false;
            // 
            // 수주번호
            // 
            this.수주번호.DataPropertyName = "수주번호";
            this.수주번호.HeaderText = "수주번호";
            this.수주번호.Name = "수주번호";
            this.수주번호.ReadOnly = true;
            this.수주번호.Visible = false;
            // 
            // 수주순번
            // 
            this.수주순번.DataPropertyName = "수주순번";
            this.수주순번.HeaderText = "수주순번";
            this.수주순번.Name = "수주순번";
            this.수주순번.ReadOnly = true;
            this.수주순번.Visible = false;
            // 
            // 공정번호
            // 
            this.공정번호.DataPropertyName = "공정번호";
            this.공정번호.HeaderText = "공정번호";
            this.공정번호.Name = "공정번호";
            this.공정번호.ReadOnly = true;
            this.공정번호.Visible = false;
            // 
            // 공정
            // 
            this.공정.DataPropertyName = "공정";
            this.공정.HeaderText = "공정";
            this.공정.Name = "공정";
            this.공정.ReadOnly = true;
            this.공정.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.공정.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sPProdDoneQueryBindingSource
            // 
            this.sPProdDoneQueryBindingSource.DataMember = "SP_ProdDone_Query";
            this.sPProdDoneQueryBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ProdDone_QueryTableAdapter
            // 
            this.sP_ProdDone_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // P1C03_PROD_DONE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1C03_PROD_DONE";
            this.Text = "P1C03_PROD_DONE";
            this.Activated += new System.EventHandler(this.P1C03_PROD_DONE_Activated);
            this.Load += new System.EventHandler(this.P1C03_PROD_DONE_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.sPProdDoneQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        private UserButtonA userButtonA2;
        private UserButtonA userButtonA1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource sPProdDoneQueryBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_ProdDone_QueryTableAdapter sP_ProdDone_QueryTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.DataGridViewButtonColumn ColDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 호기DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 운전자IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 운전자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 양품수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산합계DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량사유DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량내역DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업시작DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업종료DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 소요시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 실가동DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 최종공정여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주순번;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호;
        private System.Windows.Forms.DataGridViewLinkColumn 공정;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}
