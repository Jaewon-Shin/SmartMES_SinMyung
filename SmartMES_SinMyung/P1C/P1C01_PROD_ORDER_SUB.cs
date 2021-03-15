using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C01_PROD_ORDER_SUB : Form
    {
        public P1C01_PROD_ORDER parentWin;
        //private int rowIndex;
        private string rorderID;
        private string rorderSeq;

        public P1C01_PROD_ORDER_SUB()
        {
            InitializeComponent();
        }
        private void P1C01_PROD_ORDER_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            tbJobNo.Text = getCode();
            cbPart.SelectedIndex = 0;

            string sql = @"select co_code, co_item from tb_gi_common where co_kind = 'D' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbProcStd.DataSource = table;
                cbProcStd.ValueMember = "co_code";
                cbProcStd.DisplayMember = "co_item";
            }

            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_ProdOrder_ROderTableAdapter.Fill(dataSetP1C.SP_ProdOrder_ROder, sSearch);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
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

        #region 품목명
        private void lblProd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            ProdFinder pop = new ProdFinder();
            pop.cbGubun.Text = "<전체>";
            pop._kind = "%";
            pop._stockFlag = "%";
            pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
            pop.ShowDialog();
        }
        private void ProdEventMethod(object sender)
        {
            string sProd = sender.ToString();

            if (string.IsNullOrEmpty(sProd)) return;

            tbProd.Tag = sProd.Substring(0, 8);
            tbProd.Text = sProd.Substring(9, sProd.Length - 9);
            tbName.Focus();
        }
        #endregion

        #region 엔터키로 포커스 이동
        public bool NextFocus(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                return true;
            }
            return false;
        }
        private void nextFocus_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = NextFocus(sender, e);
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbQty.SelectionStart = tbQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbQty.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (!(e.ColumnIndex == 2 || e.ColumnIndex == 7)) return;

            if (e.ColumnIndex == 2)
            {
                string sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        dataGridView1.Rows[i].Cells[4].Value = 1;
                    else
                        dataGridView1.Rows[i].Cells[4].Value = 0;
                }
            }
            else if (e.ColumnIndex == 7)
            {
                tbProd.Tag = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbProd.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                tbSize.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                tbQty.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                cbProcStd.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

                rorderID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                rorderSeq = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                //

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[4].Value = 0;
                }
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = 1;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            try
            {
                string sSujuNo = dataGridView1.Rows[0].Cells[0].Value.ToString();

                for (int i = 1; i < dataGridView1.RowCount; i++)
                {
                    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        //dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Transparent;
                        //dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Transparent;
                        //dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Transparent;
                        dataGridView1.Rows[i].Cells[1].Value = "";
                        dataGridView1.Rows[i].Cells[2].Value = "";
                        dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Transparent;
                    }
                    sSujuNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void Save()
        {
            lblMsg.Text = "";

            if (tbProd.Tag == null)
            {
                lblMsg.Text = "품목명을 선택해 주세요.";
                lblProd.Focus();
                return;
            }

            string sQty = tbQty.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "지시수량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sPart = cbPart.Text.Substring(0, 1);
            string sProd = tbProd.Tag.ToString();
            string sName = tbName.Text.Trim();
            string sSize = tbSize.Text.Trim();
            string sProc = cbProcStd.SelectedValue.ToString();
            string sJobNo = getCode();
            string sSujuQty = sQty;

            if (string.IsNullOrEmpty(rorderSeq))
            {
                rorderSeq = "null";
            }
            else
            {
                string sqlQty = "select qty from vw_rorder where rorder_id = '" + rorderID + "' and rorder_seq = " + rorderSeq;
                MariaCRUD mQty = new MariaCRUD();
                string msgQty = string.Empty;
                string com = mQty.dbRonlyOne(sqlQty, ref msgQty).ToString();

                if (msgQty == "OK") sSujuQty = com;
            }

            string sql = "insert into tb_prod_order (job_no, proc_no, pos, lot_date, prod_id, add_name, add_size, rorder_id, rorder_seq, proc_std, rorder_date, job_part, order_qty, enter_man) " +
                "select '" + sJobNo + "',p.proc_no,'" + G.Pos + "','" + sDate + "','" + sProd + "','" + sName + "','" + sSize + "','" + rorderID + "'," + rorderSeq + ",'" + sProc + "','" + sDate + "','" + sPart + "'," + sSujuQty + " - ifnull((select sum(v.gd_qty) from vw_production v where v.rorder_id = '" + rorderID + "' and v.rorder_seq = " + rorderSeq + " and v.proc_no = p.proc_no),0),'" + G.UserID + "' " +
                "from tb_gi_process p where p.proc_std = '" + sProc + "' order by p.proc_no";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            lblMsg.Text = "저장되었습니다.";

            parentWin.ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sJobNo)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    parentWin.LotSearch(sJobNo);
                    break;
                }
            }

            tbJobNo.Text = getCode();
            tbProd.Tag = null;
            tbProd.Text = string.Empty;
            tbName.Text = string.Empty;
            tbSize.Text = string.Empty;
            tbQty.Text = string.Empty;
        }

        #region JobNo.(LotNo.) 생성
        private string getCode()
        {
            string sql = @"select UF_JobNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        private void btnBatch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;
            int iNoCnt = 0;
            string sSujuNo = string.Empty;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value != null &&
                    dataGridView1.Rows[i].Cells[4].Value.ToString() == "1")
                {
                    iCnt++;
                    if (iCnt == 1)
                        sSujuNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    else
                        if (sSujuNo != dataGridView1.Rows[i].Cells[0].Value.ToString()) iNoCnt++;
                }
            }

            if (iCnt < 1)
            {
                MessageBox.Show("작업지시대상이 선택되지 않았습니다.");
                return;
            }
            if (iNoCnt > 0)
            {
                MessageBox.Show("동일 수주건만 선택 가능합니다.");
                return;
            }

            //

            string sql;
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;

            string sProc = cbProcStd.SelectedValue.ToString();
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProd = string.Empty;
            string sName = string.Empty;
            string sSize = string.Empty;
            string sSujuSeq = string.Empty;
            string sPart = cbPart.Text.Substring(0, 1);
            string sQty = string.Empty;
            string sSujuQty = sQty;

            string sqlQty;
            MariaCRUD mQty;
            string msgQty = string.Empty;
            string com;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value != null &&
                    dataGridView1.Rows[i].Cells[4].Value.ToString() == "1")
                {
                    sSujuNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    sProd = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    sName = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    sSize = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    sSujuSeq = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    sQty = dataGridView1.Rows[i].Cells[10].Value.ToString();

                    //
                    sqlQty = "select qty from vw_rorder where rorder_id = '" + sSujuNo + "' and rorder_seq = " + sSujuSeq;
                    mQty = new MariaCRUD();
                    
                    com = mQty.dbRonlyOne(sqlQty, ref msgQty).ToString();

                    if (msgQty == "OK") sSujuQty = com;
                    //

                    sql = "insert into tb_prod_order (job_no, proc_no, pos, lot_date, prod_id, add_name, add_size, rorder_id, rorder_seq, proc_std, rorder_date, job_part, order_qty, enter_man) " +
                        "select '" + getCode() + "',p.proc_no,'" + G.Pos + "','" + sDate + "','" + sProd + "','" + sName + "','" + sSize + "','" + sSujuNo + "'," + sSujuSeq + ",'" + sProc + "','" + sDate + "','" + sPart + "'," + sSujuQty + " - ifnull((select sum(v.gd_qty) from vw_production v where v.rorder_id = '" + sSujuNo + "' and v.rorder_seq = " + sSujuSeq + " and v.proc_no = p.proc_no),0),'" + G.UserID + "' " +
                        "from tb_gi_process p where p.proc_std = '" + sProc + "' order by p.proc_no";

                    //m = new MariaCRUD();
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        lblMsg.Text = msg;
                        return;
                    }
                    //
                }
            }

            parentWin.ListSearch();
            this.Dispose();
        }
    }
}
