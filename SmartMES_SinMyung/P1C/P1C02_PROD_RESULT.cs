using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C02_PROD_RESULT : SmartMES_SinMyung.FormBasic
    {
        public P1C02_PROD_RESULT()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_Shown(object sender, EventArgs e)
        {
            dataGridViewA.CurrentCell = null;
            dataGridViewA.ClearSelection();
        }
        private void P1C02_PROD_RESULT_Load(object sender, EventArgs e)
        {
            //작업조
            cbPart.SelectedIndex = 0;

            //설비명
            string sql = @"select machine_id, machine_name from tb_machinecard order by machine_no";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbFacilityA.DataSource = table;
                cbFacilityA.ValueMember = "machine_id";
                cbFacilityA.DisplayMember = "machine_name";
                cbFacilityB.DataSource = table;
                cbFacilityB.ValueMember = "machine_id";
                cbFacilityB.DisplayMember = "machine_name";
                cbFacilityC.DataSource = table;
                cbFacilityC.ValueMember = "machine_id";
                cbFacilityC.DisplayMember = "machine_name";
                cbFacilityD.DataSource = table;
                cbFacilityD.ValueMember = "machine_id";
                cbFacilityD.DisplayMember = "machine_name";
                cbFacilityE.DataSource = table;
                cbFacilityE.ValueMember = "machine_id";
                cbFacilityE.DisplayMember = "machine_name";
            }

            //운전자
            sql = @"select user_id, user_name from tb_sys_user where user_flag = 1 and authority = 'C' order by authority, user_id";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbUserA.DataSource = table;
                cbUserA.ValueMember = "user_id";
                cbUserA.DisplayMember = "user_name";
                cbUserB.DataSource = table;
                cbUserB.ValueMember = "user_id";
                cbUserB.DisplayMember = "user_name";
                cbUserC.DataSource = table;
                cbUserC.ValueMember = "user_id";
                cbUserC.DisplayMember = "user_name";
                cbUserD.DataSource = table;
                cbUserD.ValueMember = "user_id";
                cbUserD.DisplayMember = "user_name";
                cbUserE.DataSource = table;
                cbUserE.ValueMember = "user_id";
                cbUserE.DisplayMember = "user_name";
            }
            cbUserA.SelectedValue = G.UserID;

            ////제품창고
            //sql = @"select co_code, co_item from tb_gi_common where co_kind = 'B' order by co_code";
            //m = new MariaCRUD();
            //msg = string.Empty;
            //table = m.dbDataTable(sql, ref msg);

            //if (msg == "OK")
            //{
            //    cbDepotA.DataSource = table;
            //    cbDepotA.ValueMember = "co_code";
            //    cbDepotA.DisplayMember = "co_item";
            //    cbDepotB.DataSource = table;
            //    cbDepotB.ValueMember = "co_code";
            //    cbDepotB.DisplayMember = "co_item";
            //    cbDepotC.DataSource = table;
            //    cbDepotC.ValueMember = "co_code";
            //    cbDepotC.DisplayMember = "co_item";
            //    cbDepotD.DataSource = table;
            //    cbDepotD.ValueMember = "co_code";
            //    cbDepotD.DisplayMember = "co_item";
            //    cbDepotE.DataSource = table;
            //    cbDepotE.ValueMember = "co_code";
            //    cbDepotE.DisplayMember = "co_item";
            //}
        }
        public void ListSearch()
        {
            lblMsgA.Text = "";
            lblMsgB.Text = "";
            lblMsgC.Text = "";
            lblMsgD.Text = "";
            lblMsgE.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtDate = DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd"));
                string sPart = cbPart.Text.Substring(0, 1);

                sP_ProdResult_QueryATableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryA, dtDate, sPart, "A");
                sP_ProdResult_QueryBTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryB, dtDate, sPart, "B");
                sP_ProdResult_QueryCTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryC, dtDate, sPart, "C");
                sP_ProdResult_QueryDTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryD, dtDate, sPart, "D");
                sP_ProdResult_QueryETableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryE, dtDate, sPart, "E");
                sP_ProdResult_XTableAdapter.Fill(dataSetP1C.SP_ProdResult_X, dtDate, "X");
                sP_ProdResult_YTableAdapter.Fill(dataSetP1C.SP_ProdResult_Y, dtDate, "Y");

                dataGridViewA.CurrentCell = null;
                dataGridViewB.CurrentCell = null;
                dataGridViewC.CurrentCell = null;
                dataGridViewD.CurrentCell = null;
                dataGridViewE.CurrentCell = null;
                dataGridViewX.CurrentCell = null;
                dataGridViewY.CurrentCell = null;
                dataGridViewA.ClearSelection();
                dataGridViewB.ClearSelection();
                dataGridViewC.ClearSelection();
                dataGridViewD.ClearSelection();
                dataGridViewE.ClearSelection();
                dataGridViewX.ClearSelection();
                dataGridViewY.ClearSelection();

                InitControls();
            }
            catch (NullReferenceException)
            {
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void InitControls()
        {
            timer1.Stop();
            timer2.Stop();

            lblMsgA.Text = "";
            tbJobNoA.Text = string.Empty;
            tbProdA.Tag = string.Empty;
            tbProdA.Text = string.Empty;
            tbNameA.Text = string.Empty;
            tbSizeA.Text = string.Empty;
            tbGdQtyA.Text = string.Empty;
            tbNgQtyA.Tag = string.Empty;
            tbNgQtyA.Text = string.Empty;
            tbSumQtyA.Text = string.Empty;
            tbJobTimeA.Text = "00 : 00 : 00";
            tbIdleTimeA.Text = "00 : 00 : 00";
            tbRealDriveTimeA.Text = "00 : 00 : 00";
            btnStartA.Tag = null;
            btnFinishA.Tag = null;
            lblProcA.Tag = null;
            sP_ProdResult_IdleATableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleA, "-", 0, 0);

            lblMsgB.Text = "";
            tbJobNoB.Text = string.Empty;
            tbProdB.Tag = string.Empty;
            tbProdB.Text = string.Empty;
            tbNameB.Text = string.Empty;
            tbSizeB.Text = string.Empty;
            tbGdQtyB.Text = string.Empty;
            tbNgQtyB.Tag = string.Empty;
            tbNgQtyB.Text = string.Empty;
            tbSumQtyB.Text = string.Empty;
            tbJobTimeB.Text = "00 : 00 : 00";
            tbIdleTimeB.Text = "00 : 00 : 00";
            tbRealDriveTimeB.Text = "00 : 00 : 00";
            btnStartB.Tag = null;
            btnFinishB.Tag = null;
            lblProcB.Tag = null;
            sP_ProdResult_IdleBTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleB, "-", 0, 0);

            lblMsgC.Text = "";
            tbJobNoC.Text = string.Empty;
            tbProdC.Tag = string.Empty;
            tbProdC.Text = string.Empty;
            tbNameC.Text = string.Empty;
            tbSizeC.Text = string.Empty;
            tbGdQtyC.Text = string.Empty;
            tbNgQtyC.Tag = string.Empty;
            tbNgQtyC.Text = string.Empty;
            tbSumQtyC.Text = string.Empty;
            tbJobTimeC.Text = "00 : 00 : 00";
            tbIdleTimeC.Text = "00 : 00 : 00";
            tbRealDriveTimeC.Text = "00 : 00 : 00";
            btnStartC.Tag = null;
            btnFinishC.Tag = null;
            lblProcC.Tag = null;
            sP_ProdResult_IdleCTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleC, "-", 0, 0);

            lblMsgD.Text = "";
            tbJobNoD.Text = string.Empty;
            tbProdD.Tag = string.Empty;
            tbProdD.Text = string.Empty;
            tbNameD.Text = string.Empty;
            tbSizeD.Text = string.Empty;
            tbGdQtyD.Text = string.Empty;
            tbNgQtyD.Tag = string.Empty;
            tbNgQtyD.Text = string.Empty;
            tbSumQtyD.Text = string.Empty;
            tbJobTimeD.Text = "00 : 00 : 00";
            tbIdleTimeD.Text = "00 : 00 : 00";
            tbRealDriveTimeD.Text = "00 : 00 : 00";
            btnStartD.Tag = null;
            btnFinishD.Tag = null;
            lblProcD.Tag = null;
            sP_ProdResult_IdleDTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleD, "-", 0, 0);

            lblMsgE.Text = "";
            tbJobNoE.Text = string.Empty;
            tbProdE.Tag = string.Empty;
            tbProdE.Text = string.Empty;
            tbNameE.Text = string.Empty;
            tbSizeE.Text = string.Empty;
            tbGdQtyE.Text = string.Empty;
            tbNgQtyE.Tag = string.Empty;
            tbNgQtyE.Text = string.Empty;
            tbSumQtyE.Text = string.Empty;
            tbJobTimeE.Text = "00 : 00 : 00";
            tbIdleTimeE.Text = "00 : 00 : 00";
            tbRealDriveTimeE.Text = "00 : 00 : 00";
            btnStartE.Tag = null;
            btnFinishE.Tag = null;
            lblProcE.Tag = null;
            sP_ProdResult_IdleETableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleE, "-", 0, 0);
        }

        #region Condition Bar Events1
        private void userButtonA1_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
            ListSearch();
        }
        private void userButtonA2_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
            ListSearch();
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events1
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = (DataGridView)sender;
            int rowIndex = dgv.CurrentCell.RowIndex;

            SettingValues(TabControl1.SelectedTab.Text.Substring(0, 1), rowIndex);
        }
        public void SettingValues(string grp, int rowIndex)
        {
            try
            {
                if (grp == "A")
                {
                    lblMsgA.Text = "";
                    tbJobNoA.Text = dataGridViewA.Rows[rowIndex].Cells[0].Value.ToString();
                    cbFacilityA.SelectedValue = dataGridViewA.Rows[rowIndex].Cells[1].Value.ToString();
                    cbFacilityA.Enabled = false;
                    cbUserA.SelectedValue = dataGridViewA.Rows[rowIndex].Cells[4].Value.ToString();
                    tbProdA.Tag = dataGridViewA.Rows[rowIndex].Cells[6].Value.ToString();
                    tbProdA.Text = dataGridViewA.Rows[rowIndex].Cells[7].Value.ToString();
                    tbNameA.Text = dataGridViewA.Rows[rowIndex].Cells[8].Value.ToString();
                    tbSizeA.Text = dataGridViewA.Rows[rowIndex].Cells[9].Value.ToString();
                    tbGdQtyA.Text = dataGridViewA.Rows[rowIndex].Cells[10].Value.ToString();
                    tbNgQtyA.Tag = dataGridViewA.Rows[rowIndex].Cells[13].Value.ToString();
                    tbNgQtyA.Text = dataGridViewA.Rows[rowIndex].Cells[11].Value.ToString();
                    tbSumQtyA.Text = (Int32.Parse(dataGridViewA.Rows[rowIndex].Cells[10].Value.ToString()) +
                        Int32.Parse(dataGridViewA.Rows[rowIndex].Cells[11].Value.ToString())).ToString("#,##0");
                    lblProcA.Tag = dataGridViewA.Rows[rowIndex].Cells[20].Value.ToString();

                    btnStartA.Tag = dataGridViewA.Rows[rowIndex].Cells[15].Value.ToString();

                    if (string.IsNullOrEmpty(dataGridViewA.Rows[rowIndex].Cells[16].Value.ToString()))
                        btnFinishA.Tag = null;
                    else
                        btnFinishA.Tag = dataGridViewA.Rows[rowIndex].Cells[16].Value.ToString();

                    sP_ProdResult_IdleATableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleA, tbJobNoA.Text, Int32.Parse(lblProcA.Tag.ToString()), Int32.Parse(cbFacilityA.SelectedValue.ToString()));
                }
                else if (grp == "B")
                {
                    lblMsgB.Text = "";
                    tbJobNoB.Text = dataGridViewB.Rows[rowIndex].Cells[0].Value.ToString();
                    cbFacilityB.SelectedValue = dataGridViewB.Rows[rowIndex].Cells[1].Value.ToString();
                    cbFacilityB.Enabled = false;
                    cbUserB.SelectedValue = dataGridViewB.Rows[rowIndex].Cells[4].Value.ToString();
                    tbProdB.Tag = dataGridViewB.Rows[rowIndex].Cells[6].Value.ToString();
                    tbProdB.Text = dataGridViewB.Rows[rowIndex].Cells[7].Value.ToString();
                    tbNameB.Text = dataGridViewB.Rows[rowIndex].Cells[8].Value.ToString();
                    tbSizeB.Text = dataGridViewB.Rows[rowIndex].Cells[9].Value.ToString();
                    tbGdQtyB.Text = dataGridViewB.Rows[rowIndex].Cells[10].Value.ToString();
                    tbNgQtyB.Tag = dataGridViewB.Rows[rowIndex].Cells[13].Value.ToString();
                    tbNgQtyB.Text = dataGridViewB.Rows[rowIndex].Cells[11].Value.ToString();
                    tbSumQtyB.Text = (Int32.Parse(dataGridViewB.Rows[rowIndex].Cells[10].Value.ToString()) +
                        Int32.Parse(dataGridViewB.Rows[rowIndex].Cells[11].Value.ToString())).ToString("#,##0");
                    lblProcB.Tag = dataGridViewB.Rows[rowIndex].Cells[20].Value.ToString();

                    btnStartB.Tag = dataGridViewB.Rows[rowIndex].Cells[15].Value.ToString();

                    if (string.IsNullOrEmpty(dataGridViewB.Rows[rowIndex].Cells[16].Value.ToString()))
                        btnFinishB.Tag = null;
                    else
                        btnFinishB.Tag = dataGridViewB.Rows[rowIndex].Cells[16].Value.ToString();

                    sP_ProdResult_IdleBTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleB, tbJobNoB.Text, Int32.Parse(lblProcB.Tag.ToString()), Int32.Parse(cbFacilityB.SelectedValue.ToString()));
                }
                else if (grp == "C")
                {
                    lblMsgC.Text = "";
                    tbJobNoC.Text = dataGridViewC.Rows[rowIndex].Cells[0].Value.ToString();
                    cbFacilityC.SelectedValue = dataGridViewC.Rows[rowIndex].Cells[1].Value.ToString();
                    cbFacilityC.Enabled = false;
                    cbUserC.SelectedValue = dataGridViewC.Rows[rowIndex].Cells[4].Value.ToString();
                    tbProdC.Tag = dataGridViewC.Rows[rowIndex].Cells[6].Value.ToString();
                    tbProdC.Text = dataGridViewC.Rows[rowIndex].Cells[7].Value.ToString();
                    tbNameC.Text = dataGridViewC.Rows[rowIndex].Cells[8].Value.ToString();
                    tbSizeC.Text = dataGridViewC.Rows[rowIndex].Cells[9].Value.ToString();
                    tbGdQtyC.Text = dataGridViewC.Rows[rowIndex].Cells[10].Value.ToString();
                    tbNgQtyC.Tag = dataGridViewC.Rows[rowIndex].Cells[13].Value.ToString();
                    tbNgQtyC.Text = dataGridViewC.Rows[rowIndex].Cells[11].Value.ToString();
                    tbSumQtyC.Text = (Int32.Parse(dataGridViewC.Rows[rowIndex].Cells[10].Value.ToString()) +
                        Int32.Parse(dataGridViewC.Rows[rowIndex].Cells[11].Value.ToString())).ToString("#,##0");
                    lblProcC.Tag = dataGridViewC.Rows[rowIndex].Cells[20].Value.ToString();

                    btnStartC.Tag = dataGridViewC.Rows[rowIndex].Cells[15].Value.ToString();

                    if (string.IsNullOrEmpty(dataGridViewC.Rows[rowIndex].Cells[16].Value.ToString()))
                        btnFinishC.Tag = null;
                    else
                        btnFinishC.Tag = dataGridViewC.Rows[rowIndex].Cells[16].Value.ToString();

                    sP_ProdResult_IdleCTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleC, tbJobNoC.Text, Int32.Parse(lblProcC.Tag.ToString()), Int32.Parse(cbFacilityC.SelectedValue.ToString()));
                }
                else if (grp == "D")
                {
                    lblMsgD.Text = "";
                    tbJobNoD.Text = dataGridViewD.Rows[rowIndex].Cells[0].Value.ToString();
                    cbFacilityD.SelectedValue = dataGridViewD.Rows[rowIndex].Cells[1].Value.ToString();
                    cbFacilityD.Enabled = false;
                    cbUserD.SelectedValue = dataGridViewD.Rows[rowIndex].Cells[4].Value.ToString();
                    tbProdD.Tag = dataGridViewD.Rows[rowIndex].Cells[6].Value.ToString();
                    tbProdD.Text = dataGridViewD.Rows[rowIndex].Cells[7].Value.ToString();
                    tbNameD.Text = dataGridViewD.Rows[rowIndex].Cells[8].Value.ToString();
                    tbSizeD.Text = dataGridViewD.Rows[rowIndex].Cells[9].Value.ToString();
                    tbGdQtyD.Text = dataGridViewD.Rows[rowIndex].Cells[10].Value.ToString();
                    tbNgQtyD.Tag = dataGridViewD.Rows[rowIndex].Cells[13].Value.ToString();
                    tbNgQtyD.Text = dataGridViewD.Rows[rowIndex].Cells[11].Value.ToString();
                    tbSumQtyD.Text = (Int32.Parse(dataGridViewD.Rows[rowIndex].Cells[10].Value.ToString()) +
                        Int32.Parse(dataGridViewD.Rows[rowIndex].Cells[11].Value.ToString())).ToString("#,##0");
                    lblProcD.Tag = dataGridViewD.Rows[rowIndex].Cells[20].Value.ToString();

                    btnStartD.Tag = dataGridViewD.Rows[rowIndex].Cells[15].Value.ToString();

                    if (string.IsNullOrEmpty(dataGridViewD.Rows[rowIndex].Cells[16].Value.ToString()))
                        btnFinishD.Tag = null;
                    else
                        btnFinishD.Tag = dataGridViewD.Rows[rowIndex].Cells[16].Value.ToString();

                    sP_ProdResult_IdleDTableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleD, tbJobNoD.Text, Int32.Parse(lblProcD.Tag.ToString()), Int32.Parse(cbFacilityD.SelectedValue.ToString()));
                }
                else if (grp == "E")
                {
                    lblMsgE.Text = "";
                    tbJobNoE.Text = dataGridViewE.Rows[rowIndex].Cells[0].Value.ToString();
                    cbFacilityE.SelectedValue = dataGridViewE.Rows[rowIndex].Cells[1].Value.ToString();
                    cbFacilityE.Enabled = false;
                    cbUserE.SelectedValue = dataGridViewE.Rows[rowIndex].Cells[4].Value.ToString();
                    tbProdE.Tag = dataGridViewE.Rows[rowIndex].Cells[6].Value.ToString();
                    tbProdE.Text = dataGridViewE.Rows[rowIndex].Cells[7].Value.ToString();
                    tbNameE.Text = dataGridViewE.Rows[rowIndex].Cells[8].Value.ToString();
                    tbSizeE.Text = dataGridViewE.Rows[rowIndex].Cells[9].Value.ToString();
                    tbGdQtyE.Text = dataGridViewE.Rows[rowIndex].Cells[10].Value.ToString();
                    tbNgQtyE.Tag = dataGridViewE.Rows[rowIndex].Cells[13].Value.ToString();
                    tbNgQtyE.Text = dataGridViewE.Rows[rowIndex].Cells[11].Value.ToString();
                    tbSumQtyE.Text = (Int32.Parse(dataGridViewE.Rows[rowIndex].Cells[10].Value.ToString()) +
                        Int32.Parse(dataGridViewE.Rows[rowIndex].Cells[11].Value.ToString())).ToString("#,##0");
                    lblProcE.Tag = dataGridViewE.Rows[rowIndex].Cells[20].Value.ToString();

                    btnStartE.Tag = dataGridViewE.Rows[rowIndex].Cells[15].Value.ToString();

                    if (string.IsNullOrEmpty(dataGridViewE.Rows[rowIndex].Cells[16].Value.ToString()))
                        btnFinishE.Tag = null;
                    else
                        btnFinishE.Tag = dataGridViewE.Rows[rowIndex].Cells[16].Value.ToString();

                    sP_ProdResult_IdleETableAdapter.Fill(dataSetP1C.SP_ProdResult_IdleE, tbJobNoE.Text, Int32.Parse(lblProcE.Tag.ToString()), Int32.Parse(cbFacilityE.SelectedValue.ToString()));
                }

                timer1.Start();
                timer2.Start();
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }
        private void gridIdle_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.ClearSelection();
        }
        #endregion

        #region GridView Events2
        private void dataGridViewX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            P1C02_PROD_RESULT_TOLL sub = new P1C02_PROD_RESULT_TOLL();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void dataGridViewY_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            P1C02_PROD_RESULT_FINISH sub = new P1C02_PROD_RESULT_FINISH();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        #endregion

        #region Condition Bar Events2        
        private void btnStart_Click(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);

            Label lblMsg = this.Controls.Find("lblMsg" + grp, true).FirstOrDefault() as Label;
            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;
            Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
            ComboBox cbFacility = this.Controls.Find("cbFacility" + grp, true).FirstOrDefault() as ComboBox;
            ComboBox cbUser = this.Controls.Find("cbUser" + grp, true).FirstOrDefault() as ComboBox;
            TextBox tbProd = this.Controls.Find("tbProd" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbName = this.Controls.Find("tbName" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbSize = this.Controls.Find("tbSize" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbGdQty = this.Controls.Find("tbGdQty" + grp, true).FirstOrDefault() as TextBox;
            CheckBox chbFinalFlag = this.Controls.Find("chbFinalFlag" + grp, true).FirstOrDefault() as CheckBox;
            ComboBox cbDepot = this.Controls.Find("cbDepot" + grp, true).FirstOrDefault() as ComboBox;
            DataGridView dataGridView = this.Controls.Find("dataGridView" + grp, true).FirstOrDefault() as DataGridView;
            Label lblProc = this.Controls.Find("lblProc" + grp, true).FirstOrDefault() as Label;

            //

            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                lblMsg.Text = "LotNo.를 생성해 주세요.";
                return;
            }
            if (btnStart.Tag != null)
            {
                lblMsg.Text = "이미 작업시작된 Lot입니다.";
                return;
            }
            if (string.IsNullOrEmpty(cbUser.Text))
            {
                lblMsg.Text = "운전자가 선택되지 않았습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("설비명 : " + cbFacility.Text + "\r\r운전자 : " + cbUser.Text + "\r\r양품수량 : " + tbGdQty.Text + "\r\r해당 정보로 작업시작 하시겠습니까?", lblProc.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.No) return;


            string sJobNo = tbJobNo.Text;
            string sMachine = cbFacility.SelectedValue.ToString();
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sPart = cbPart.Text.Substring(0, 1);
            string sUser = cbUser.SelectedValue.ToString();
            string sProd = tbProd.Tag.ToString();
            string sName = tbName.Text;
            string sSize = tbSize.Text;
            string sGdQty = tbGdQty.Text.Replace(",", "");
            string sStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sProc = lblProc.Tag.ToString();

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "insert into tb_prod_result (job_no, proc_no, machine_id, pos, prod_date, job_part, job_group, user_id, prod_id, add_name, add_size, gd_qty, jobtime_start, enter_man) " +
                    "values('" + sJobNo + "'," + sProc + "," + sMachine + ",'" + G.Pos + "','" + sDate + "','" + sPart + "','" + grp + "','" + sUser + "','" + sProd + "','" + sName + "','" + sSize + "'," + sGdQty + ",'" + sStart + "','" + G.UserID + "')";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = "이미 Lot 배당된 설비이거나 저장에 문제가 있습니다.";
                return;
            }


            if (grp == "A") sP_ProdResult_QueryATableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryA, DateTime.Parse(sDate), sPart, grp);
            else if (grp == "B") sP_ProdResult_QueryBTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryB, DateTime.Parse(sDate), sPart, grp);
            else if (grp == "C") sP_ProdResult_QueryCTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryC, DateTime.Parse(sDate), sPart, grp);
            else if (grp == "D") sP_ProdResult_QueryDTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryD, DateTime.Parse(sDate), sPart, grp);
            else if (grp == "E") sP_ProdResult_QueryETableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryE, DateTime.Parse(sDate), sPart, grp);

            int rowIndex = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value.ToString() == sJobNo
                    && dataGridView.Rows[i].Cells[1].Value.ToString() == sMachine
                    && dataGridView.Rows[i].Cells[20].Value.ToString() == sProc)
                {
                    dataGridView.CurrentCell = dataGridView[3, i];
                    dataGridView.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }

            SettingValues(grp, rowIndex);
            lblMsg.Text = "작업시작되었습니다.";
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);

            Label lblMsg = this.Controls.Find("lblMsg" + grp, true).FirstOrDefault() as Label;
            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;
            Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
            Button btnFinish = this.Controls.Find("btnFinish" + grp, true).FirstOrDefault() as Button;
            ComboBox cbFacility = this.Controls.Find("cbFacility" + grp, true).FirstOrDefault() as ComboBox;
            ComboBox cbUser = this.Controls.Find("cbUser" + grp, true).FirstOrDefault() as ComboBox;
            TextBox tbGdQty = this.Controls.Find("tbGdQty" + grp, true).FirstOrDefault() as TextBox;
            CheckBox chbFinalFlag = this.Controls.Find("chbFinalFlag" + grp, true).FirstOrDefault() as CheckBox;
            ComboBox cbDepot = this.Controls.Find("cbDepot" + grp, true).FirstOrDefault() as ComboBox;
            DataGridView dataGridView = this.Controls.Find("dataGridView" + grp, true).FirstOrDefault() as DataGridView;
            Label lblProc = this.Controls.Find("lblProc" + grp, true).FirstOrDefault() as Label;

            //

            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }
            if (btnStart.Tag == null)
            {
                lblMsg.Text = "작업시작되지 않은 LotNo.입니다.";
                return;
            }
            if (dataGridView.CurrentRow.Cells[19].Value.ToString() == "비가동")
            {
                lblMsg.Text = "비가동종료 후 작업종료 가능합니다.";
                return;
            }
            if (btnFinish.Tag != null)
            {
                lblMsg.Text = "이미 작업종료된 LotNo.입니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("설비명 : " + cbFacility.Text + "\r\r운전자 : " + cbUser.Text + "\r\r양품수량 : " + tbGdQty.Text + "\r\r해당 정보로 작업종료 하시겠습니까?", lblProc.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.No) return;


            string sJobNo = tbJobNo.Text;
            string sMachine = cbFacility.SelectedValue.ToString();
            string sUser = cbUser.SelectedValue.ToString();
            string sFinish = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sQty = tbGdQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sQty)) sQty = "0";
            string sProcNo = lblProc.Tag.ToString();

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "update tb_prod_result set user_id = '" + sUser + "', gd_qty = " + sQty + ", jobtime_finish = '" + sFinish + "' " +
                "where job_no = '" + sJobNo + "' and proc_no = " + sProcNo + " and machine_id = " + sMachine;

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "update tb_prod_order set prod_flag = 1 where job_no = '" + sJobNo + "' and proc_no = " + sProcNo;
            m.dbCUD(sql, ref msg);

            DateTime dtDate = dtpDate.Value;
            string sPart = cbPart.Text.Substring(0, 1);

            if (grp == "A") sP_ProdResult_QueryATableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryA, dtDate, sPart, grp);
            else if (grp == "B") sP_ProdResult_QueryBTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryB, dtDate, sPart, grp);
            else if (grp == "C") sP_ProdResult_QueryCTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryC, dtDate, sPart, grp);
            else if (grp == "D") sP_ProdResult_QueryDTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryD, dtDate, sPart, grp);
            else if (grp == "E") sP_ProdResult_QueryETableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryE, dtDate, sPart, grp);

            int rowIndex = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value.ToString() == sJobNo
                    && dataGridView.Rows[i].Cells[1].Value.ToString() == sMachine
                    && dataGridView.Rows[i].Cells[20].Value.ToString() == sProcNo)
                {
                    dataGridView.CurrentCell = dataGridView[3, i];
                    dataGridView.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }

            SettingValues(grp, rowIndex);
            lblMsg.Text = "작업종료되었습니다.";
        }
        private void btnIdle_Click(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);

            Label lblMsg = this.Controls.Find("lblMsg" + grp, true).FirstOrDefault() as Label;
            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;
            Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
            Button btnFinish = this.Controls.Find("btnFinish" + grp, true).FirstOrDefault() as Button;
            ComboBox cbFacility = this.Controls.Find("cbFacility" + grp, true).FirstOrDefault() as ComboBox;
            Label lblProc = this.Controls.Find("lblProc" + grp, true).FirstOrDefault() as Label;

            //

            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }
            if (btnStart.Tag == null)
            {
                lblMsg.Text = "작업시작되지 않은 LotNo.입니다.";
                return;
            }
            if (btnFinish.Tag != null)
            {
                lblMsg.Text = "이미 작업종료된 LotNo.입니다.";
                return;
            }

            P1C02_PROD_RESULT_IDLE sub = new P1C02_PROD_RESULT_IDLE();
            sub.parentWin = this;
            sub.jobNo = tbJobNo.Text;
            sub.procNo = lblProc.Tag.ToString();
            sub.facID = cbFacility.SelectedValue.ToString();
            sub.sGroup = grp;
            sub.ShowDialog();
        }
        private void btnNg_Click(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);

            Label lblMsg = this.Controls.Find("lblMsg" + grp, true).FirstOrDefault() as Label;
            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;
            Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
            ComboBox cbFacility = this.Controls.Find("cbFacility" + grp, true).FirstOrDefault() as ComboBox;
            Label lblProc = this.Controls.Find("lblProc" + grp, true).FirstOrDefault() as Label;

            //

            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }
            if (btnStart.Tag == null)
            {
                lblMsg.Text = "작업시작되지 않은 LotNo.입니다.";
                return;
            }

            P1C02_PROD_RESULT_NG sub = new P1C02_PROD_RESULT_NG();
            sub.parentWin = this;
            sub.jobNo = tbJobNo.Text;
            sub.procNo = lblProc.Tag.ToString();
            sub.facID = cbFacility.SelectedValue.ToString();
            sub.sGroup = grp;
            sub.ShowDialog();
        }
        #endregion


        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            string sGroup = TabControl1.SelectedTab.Text.Substring(0, 1);

            if (sGroup == "X" || sGroup == "Y") return;

            P1C02_PROD_RESULT_ORDER sub = new P1C02_PROD_RESULT_ORDER();
            sub.parentWin = this;
            sub.dtDate = dtpDate.Value;
            sub.sPart = cbPart.Text.Substring(0, 1);
            sub.sGroup = sGroup;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);

            if (grp == "X" || grp == "Y") return;

            Label lblMsg = this.Controls.Find("lblMsg" + grp, true).FirstOrDefault() as Label;
            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;
            Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
            ComboBox cbFacility = this.Controls.Find("cbFacility" + grp, true).FirstOrDefault() as ComboBox;
            ComboBox cbUser = this.Controls.Find("cbUser" + grp, true).FirstOrDefault() as ComboBox;
            TextBox tbProd = this.Controls.Find("tbProd" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbName = this.Controls.Find("tbName" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbSize = this.Controls.Find("tbSize" + grp, true).FirstOrDefault() as TextBox;
            TextBox tbGdQty = this.Controls.Find("tbGdQty" + grp, true).FirstOrDefault() as TextBox;
            CheckBox chbFinalFlag = this.Controls.Find("chbFinalFlag" + grp, true).FirstOrDefault() as CheckBox;
            ComboBox cbDepot = this.Controls.Find("cbDepot" + grp, true).FirstOrDefault() as ComboBox;
            DataGridView dataGridView = this.Controls.Find("dataGridView" + grp, true).FirstOrDefault() as DataGridView;
            Label lblProc = this.Controls.Find("lblProc" + grp, true).FirstOrDefault() as Label;

            //

            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }
            if (btnStart.Tag == null)
            {
                lblMsg.Text = "작업시작되지 않은 LotNo.입니다.";
                return;
            }

            string sJobNo = tbJobNo.Text;
            string sProc = lblProc.Tag.ToString();
            string sMachine = cbFacility.SelectedValue.ToString();
            string sUser = cbUser.SelectedValue.ToString();
            string sQty = tbGdQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sQty)) sQty = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "update tb_prod_result set user_id = '" + sUser + "', gd_qty = " + sQty +
                " where job_no = '" + sJobNo + "' and proc_no = " + sProc + " and machine_id = " + sMachine;

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            DateTime dtDate = dtpDate.Value;
            string sPart = cbPart.Text.Substring(0, 1);

            if (grp == "A") sP_ProdResult_QueryATableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryA, dtDate, sPart, grp);
            else if (grp == "B") sP_ProdResult_QueryBTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryB, dtDate, sPart, grp);
            else if (grp == "C") sP_ProdResult_QueryCTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryC, dtDate, sPart, grp);
            else if (grp == "D") sP_ProdResult_QueryDTableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryD, dtDate, sPart, grp);
            else if (grp == "E") sP_ProdResult_QueryETableAdapter.Fill(dataSetP1C.SP_ProdResult_QueryE, dtDate, sPart, grp);


            int rowIndex = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value.ToString() == sJobNo
                    && dataGridView.Rows[i].Cells[1].Value.ToString() == sMachine
                    && dataGridView.Rows[i].Cells[20].Value.ToString() == sProc)
                {
                    dataGridView.CurrentCell = dataGridView[3, i];
                    dataGridView.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }

            SettingValues(grp, rowIndex);
            lblMsg.Text = "저장 되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string grp = TabControl1.SelectedTab.Text.Substring(0, 1);
                Button btnStart = this.Controls.Find("btnStart" + grp, true).FirstOrDefault() as Button;
                Button btnFinish = this.Controls.Find("btnFinish" + grp, true).FirstOrDefault() as Button;
                TextBox tbRealDriveTime = this.Controls.Find("tbRealDriveTime" + grp, true).FirstOrDefault() as TextBox;
                TextBox tbJobTime = this.Controls.Find("tbJobTime" + grp, true).FirstOrDefault() as TextBox;
                TextBox tbIdleTime = this.Controls.Find("tbIdleTime" + grp, true).FirstOrDefault() as TextBox;

                string sStart = btnStart.Tag.ToString();
                string sFinish = DateTime.Now.ToString();
                if (btnFinish.Tag != null && !string.IsNullOrEmpty(btnFinish.Tag.ToString()))
                    sFinish = btnFinish.Tag.ToString();

                TimeSpan result = DateTime.Parse(sFinish) - DateTime.Parse(sStart);

                tbJobTime.Text = result.TotalHours.ToString("00") + " : " + result.Minutes.ToString("00") + " : " + result.Seconds.ToString("00");

                string sIdel = tbIdleTime.Text;
                if (sIdel == "00 : 00 : 00")
                    tbRealDriveTime.Text = tbJobTime.Text;
                else
                {
                    TimeSpan ts = new TimeSpan(Int32.Parse(sIdel.Substring(0, 2)), Int32.Parse(sIdel.Substring(5, 2)), Int32.Parse(sIdel.Substring(10, 2)));
                    result = result - ts;

                    tbRealDriveTime.Text = result.TotalHours.ToString("00") + " : " + result.Minutes.ToString("00") + " : " + result.Seconds.ToString("00");
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string grp = TabControl1.SelectedTab.Text.Substring(0, 1);
                TextBox tbIdleTime = this.Controls.Find("tbIdleTime" + grp, true).FirstOrDefault() as TextBox;
                DataGridView gridIdle = this.Controls.Find("gridIdle" + grp, true).FirstOrDefault() as DataGridView;

                DateTime dt1, dt2;
                TimeSpan ts = new TimeSpan(00, 00, 00);

                for (int i = 0; i < gridIdle.RowCount; i++)
                {
                    dt1 = DateTime.Parse(gridIdle.Rows[i].Cells[4].Value.ToString());
                    if (string.IsNullOrEmpty(gridIdle.Rows[i].Cells[5].Value.ToString())) dt2 = DateTime.Now;
                    else dt2 = DateTime.Parse(gridIdle.Rows[i].Cells[5].Value.ToString());
                    ts = ts + (dt2 - dt1);
                }

                tbIdleTime.Text = ts.TotalHours.ToString("00") + " : " + ts.Minutes.ToString("00") + " : " + ts.Seconds.ToString("00");
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        #region 텍스트 박스 숫자 처리
        private void tbGdQty_TextChanged(object sender, EventArgs e)
        {
            TextBox tbGdQty = (TextBox)sender;
            try
            {
                string lgsText = tbGdQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbGdQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbGdQty.SelectionStart = tbGdQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbGdQty.SelectionLength = 0;

                //

                string grp = TabControl1.SelectedTab.Text.Substring(0, 1);
                TextBox tbNgQty = this.Controls.Find("tbNgQty" + grp, true).FirstOrDefault() as TextBox;
                TextBox tbSumQty = this.Controls.Find("tbSumQty" + grp, true).FirstOrDefault() as TextBox;

                long lQty = long.Parse(tbGdQty.Text.Replace(",", "").Trim());
                long lNg = 0;
                if (!string.IsNullOrEmpty(tbNgQty.Text))
                    lNg = long.Parse(tbNgQty.Text.Replace(",", "").Trim());

                tbSumQty.Text = (lQty + lNg).ToString("#,##0");
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string grp = TabControl1.SelectedTab.Text.Substring(0, 1);
            DataGridView dataGridView = this.Controls.Find("dataGridView" + grp, true).FirstOrDefault() as DataGridView;

            if (grp == "X" || grp == "Y")
            {
                dataGridView.CurrentCell = null;
                dataGridView.ClearSelection();
                return;
            }

            TextBox tbJobNo = this.Controls.Find("tbJobNo" + grp, true).FirstOrDefault() as TextBox;

            if (string.IsNullOrEmpty(tbJobNo.Text))
            {
                dataGridView.CurrentCell = null;
                dataGridView.ClearSelection();
            }
        }

    }
}

