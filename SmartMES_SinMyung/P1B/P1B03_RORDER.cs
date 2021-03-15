using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B03_RORDER : SmartMES_SinMyung.FormBasic
    {
        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B03_RORDER()
        {
            InitializeComponent();
        }
        private void P1B03_RORDER_Load(object sender, EventArgs e)
        {
            ListSearch1();
        }
        public void ListSearch1()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_ROrderMain_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderMain_Query, sSearch);

                dataGridViewList.CurrentCell = null;
                dataGridViewList.ClearSelection();
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
        public void ListSearch2(int rowIndex)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblMsg.Text = "";

            cbNo.Checked = false;
            tbNo.Text = dataGridViewList.Rows[rowIndex].Cells[0].Value.ToString();
            dtpDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[2].Value.ToString());
            tbCust.Tag = dataGridViewList.Rows[rowIndex].Cells[3].Value.ToString();
            tbCust.Text = dataGridViewList.Rows[rowIndex].Cells[4].Value.ToString();
            tbPlace.Text = dataGridViewList.Rows[rowIndex].Cells[6].Value.ToString();
            dtpDeliDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[7].Value.ToString());
            tbContents.Text = dataGridViewList.Rows[rowIndex].Cells[8].Value.ToString();
            
            Cursor.Current = Cursors.Default;
        }
        public void ListSearch3()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sNo = tbNo.Text;

                sP_ROrderSub_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderSub_Query, sNo);

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
        public void ListSearch4()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int iCnt = 0;
                long lSum = 0;
                string sMoney;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value != null) iCnt++;

                    if (dataGridView1.Rows[i].Cells[12].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[12].Value.ToString()))
                        sMoney = "0";
                    else
                        sMoney = dataGridView1.Rows[i].Cells[12].Value.ToString();

                    lSum += long.Parse(sMoney);
                }

                lblSumMoney.Text = "합계금액 : " + lSum.ToString("#,##0") + "원";
                lblCnt.Text = iCnt.ToString() + "건";
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
        public void ListInit()
        {
            lblMsg.Text = "";

            cbNo.Checked = false;
            tbNo.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
            tbCust.Tag = string.Empty;
            tbCust.Text = string.Empty;
            tbPlace.Text = string.Empty;
            //dtpDeliDate.Value = DateTime.Today;            
            tbContents.Text = string.Empty;

            sP_ROrderSub_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderSub_Query, "");

            lblSumMoney.Text = "합계금액 : 0원";
            lblCnt.Text = "0건";
        }

        #region Controls Event
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch1();
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "복사할 수주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 수주번호만 복사할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("수주번호 : " + sNo + "\r\r해당 수주정보를 새로운 수주번호로 복사하시겠습니까?", this.lblTitle.Text + "[수주복사]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sNewNo = getROrderNo();

            sql = "insert into tb_rorder_main (rorder_id, pos, rorder_date, cust_id, project, place, deli_date, enter_man) " +
                  "select '" + sNewNo + "','" + G.Pos + "', CURDATE(), cust_id, project, place, CURDATE(), '" + G.UserID + "' " +
                  "from tb_rorder_main " +
                  "where rorder_id = '" + sNo + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "insert into tb_rorder_sub (rorder_id, rorder_seq, prod_id, add_name, add_size, qty, weight, danga, cost1, cost2, amount, vat, doc_no, prod_no, mat_kind, bigo, proc_std) " +
                  "select '" + sNewNo + "', rorder_seq, prod_id, add_name, add_size, qty, weight, danga, cost1, cost2, amount, vat, doc_no, prod_no, mat_kind, bigo, proc_std " +
                  "from tb_rorder_sub " +
                  "where rorder_id = '" + sNo + "' " +
                  "order by rorder_seq";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNewNo)
                {
                    dataGridViewList.CurrentCell = dataGridViewList[2, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            lblMsg.Text = "복사되었습니다.";
        }        
        private void lblCust_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            CustFinder sub = new CustFinder();
            sub.FormSendEvent += new CustFinder.FormSendDataHandler(PostEventMethod);
            sub._gubun = "103";
            sub.ShowDialog();
        }
        private void PostEventMethod(object sender)
        {
            string sCust = sender.ToString();

            if (string.IsNullOrEmpty(sCust)) return;

            tbCust.Tag = sCust.Substring(0, 7);
            tbCust.Text = sCust.Substring(8, sCust.Length - 8);
            tbPlace.Focus();
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

        #region GridView Events
        private void dataGridViewList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int index = dataGridViewList.CurrentRow.Index;

            ListSearch2(index);
            ListSearch3();
            ListSearch4();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 15)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
                }
                if (e.KeyCode == Keys.Tab)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                rowIndex = dataGridView1.CurrentCell.RowIndex;
                endEdit = true;

                float money1 = 0;
                float money2 = 0;
                float money3 = 0;
                long moneyA = 0;
                long moneyB = 0;

                if (columnIndex == 7 || columnIndex == 8 || columnIndex == 9)
                {
                    if (dataGridView1.Rows[rowIndex].Cells[7].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[7].Value.ToString().Length != 0)
                        money1 = float.Parse(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[8].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length != 0)
                        money2 = float.Parse(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[9].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[9].Value.ToString().Length != 0)
                        money3 = float.Parse(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());

                    moneyA = (long)(money1 * money2 * money3);
                    dataGridView1.Rows[rowIndex].Cells[10].Value = moneyA;

                    //

                    if (dataGridView1.Rows[rowIndex].Cells[11].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[11].Value.ToString().Length != 0)
                        moneyB = long.Parse(dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[12].Value = (moneyA + moneyB);

                    ListSearch4();
                }
                else if (columnIndex == 10 || columnIndex == 11)
                {
                    if (dataGridView1.Rows[rowIndex].Cells[10].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[10].Value.ToString().Length != 0)
                        moneyA = long.Parse(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[11].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[11].Value.ToString().Length != 0)
                        moneyB = long.Parse(dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[12].Value = (moneyA + moneyB);
                    ListSearch4();
                }
            }
            catch(Exception)
            {
                return;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null && endEdit)
                {
                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 15)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];

                    endEdit = false;
                }
            }
            catch(Exception)
            {
                return;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 3) //"품목"
            {
                ProdFinder pop = new ProdFinder();
                pop.cbGubun.SelectedIndex = 1;
                pop._kind = "%";
                pop._stockFlag = "%";
                pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
                pop.ShowDialog();
            }
            else if (e.ColumnIndex == 23) //"도면 자료관리"
            {
                int lastRow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
                if (e.RowIndex == lastRow) return;

                if ((dataGridView1.Rows[e.RowIndex].Cells[0].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())) ||
                    (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())))
                {
                    lblMsg.Text = "저장 후 사용이 가능합니다.";
                    return;
                }

                P1B03_RORDER_DOC sub = new P1B03_RORDER_DOC();
                sub.parentWin = this;
                sub.rowIdx = e.RowIndex;
                sub.sNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                sub.sSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  
                sub.sFileName = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                sub.ShowDialog();
            }
            else if (e.ColumnIndex == 24) //"X"
            {
                try
                {
                    string sNo = tbNo.Text;

                    if (string.IsNullOrEmpty(sNo))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        return;
                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        return;
                    }

                    string sSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    DialogResult dr = MessageBox.Show("해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;

                    MariaCRUD m = new MariaCRUD();
                    string sql = "delete from tb_rorder_sub where rorder_id = '" + sNo + "' and rorder_seq = " + sSeq;
                    string msg = string.Empty;
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }

                    //string sEstimateNo = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                    //string sEstimateSeq = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                    //if (!string.IsNullOrEmpty(sEstimateNo))
                    //{
                    //    sql = "update tb_estimate_sub set rorder_flag = 0 where estimate_id = '" + sEstimateNo + "' and estimate_seq = " + sEstimateSeq;
                    //    m.dbCUD(sql, ref msg);
                    //}

                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sSeq);
                }
                catch (Exception)
                {
                    return;
                }
            }

            ListSearch4();
        }
        private void ProdEventMethod(object sender)
        {
            try
            {
                string sProd = sender.ToString();
                if (string.IsNullOrEmpty(sProd)) return;

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;

                dataGridView1.Rows[rowIndex].Cells[2].Value = sProd.Substring(0, 8);
                dataGridView1.Rows[rowIndex].Cells[4].Value = sProd.Substring(9, sProd.Length - 9);
                dataGridView1.CurrentCell = dataGridView1[5, rowIndex];

                //if (rowIndex < 1)
                //    dataGridView1.Rows[rowIndex].Cells[21].Value = "0001";
                //else
                //    dataGridView1.Rows[rowIndex].Cells[21].Value = dataGridView1.Rows[rowIndex - 1].Cells[21].Value;
            }
            catch(Exception)
            {
                return;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            long lCost1 = 0;
            long lCost2 = 0;
            long lAmount = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lCost1 = Convert.ToInt64(row.Cells[10].Value);
                    lCost2 = Convert.ToInt64(row.Cells[11].Value);
                    lAmount = Convert.ToInt64(row.Cells[12].Value);

                    if ((lCost1 + lCost2) == lAmount)
                        row.Cells[12].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[12].Style.ForeColor = Color.Red;

                    //

                    if (row.Cells[22].Value == null || string.IsNullOrEmpty(row.Cells[22].Value.ToString()))
                        row.Cells[23].Value = Properties.Resources.clipB;
                    else
                        row.Cells[23].Value = Properties.Resources.clipA;
                }

                int lastRow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
                dataGridView1.Rows[lastRow].Cells[23].Value = Properties.Resources.empty;

                ListSearch4();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch1();

            string sNo = tbNo.Text;
            if (string.IsNullOrEmpty(sNo))
            {
                ListInit();
            }
            else
            {
                for (int i = 0; i < dataGridViewList.Rows.Count; i++)
                {
                    if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        dataGridViewList.CurrentCell = dataGridViewList[2, i];
                        dataGridViewList.CurrentCell.Selected = true;

                        ListSearch2(i);
                        ListSearch3();
                        ListSearch4();
                        break;
                    }
                }
            }
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            ListSearch1();
            ListInit();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "삭제할 수주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 수주번호만 삭제할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("수주번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_rorder_main where rorder_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            //string sEstimateNo = tbEstimateNo.Text;
            //if (!string.IsNullOrEmpty(sEstimateNo))
            //{
            //    sql = "update tb_estimate_main set rorder_flag = 0 where estimate_id = '" + sEstimateNo + "'";
            //    m.dbCUD(sql, ref msg);
            //    sql = "update tb_estimate_sub set rorder_flag = 0 where estimate_id = '" + sEstimateNo + "'";
            //    m.dbCUD(sql, ref msg);
            //}

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + tbCust.Text);

            ListSearch1();
            ListInit();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            dataGridView1.CurrentCell = dataGridView1[4, 0];
            lblMsg.Text = "";

            

            if (tbCust.Tag == null || string.IsNullOrEmpty(tbCust.Tag.ToString()))
            {
                lblMsg.Text = "거래처명을 선택해 주세요.";
                lblCust.Focus();
                return;
            }

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!(dataGridView1.Rows[i].Cells[2].Value == null ||
                    string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))) iCnt++;
            }

            if (iCnt == 0)
            {
                lblMsg.Text = "품목정보를 확인해 주세요.";
                dataGridView1.Focus();
                return;
            }

            //

            string sNo = tbNo.Text;
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sCust = tbCust.Tag.ToString();
            string sCustName = tbCust.Text;
            string sProject = tbCust.Text + "의 건";
            string sPlace = tbPlace.Text.Trim();
            string sDeliDate = dtpDeliDate.Value.ToString("yyyy-MM-dd");
            string sContents = tbContents.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sSeq = string.Empty;
            string sProdID = string.Empty;
            string sAddSize = string.Empty;
            string sAddName = string.Empty;
            string sQty = string.Empty;
            string sWeight = string.Empty;
            string sDanga = string.Empty;
            string sCost1 = string.Empty;
            string sCost2 = string.Empty;
            string sAmount = string.Empty;
            string sDocNo = string.Empty;
            string sProdNo = string.Empty;
            string sMatKind = string.Empty;
            string sProcStd = "0001";

            if (string.IsNullOrEmpty(sNo)) //추가
            {
                sNo = getROrderNo();
                sql = "insert into tb_rorder_main (rorder_id, pos, rorder_date, cust_id, project, place, deli_date, contents, enter_man) " +
                    "values('" + sNo + "','" + G.Pos + "','" + sDate + "','" + sCust + "','" + sProject + "','" + sPlace + "','" + sDeliDate + "','" + sContents + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                tbNo.Text = sNo;

                int seq = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString())) continue;

                    seq = seq + 10;
                    sSeq = seq.ToString();
                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    sAddSize = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sAddName = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sWeight = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sCost1 = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                    sCost2 = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                    sDocNo = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sProdNo = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();
                    sMatKind = dataGridView1.Rows[i].Cells[15].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sWeight)) sWeight = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sCost1)) sCost1 = "0";
                    if (string.IsNullOrEmpty(sCost2)) sCost2 = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = "insert into tb_rorder_sub (rorder_id, rorder_seq, prod_id, add_name, add_size, qty, weight, danga, cost1, cost2, amount, doc_no, prod_no, mat_kind, proc_std) " +
                          "values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sAddName + "','" + sAddSize + "'," + sQty + "," + sWeight + "," + sDanga + "," + sCost1 + "," + sCost2 + "," + sAmount + ",'" + sDocNo + "','" + sProdNo + "','" + sMatKind + "','" + sProcStd + "')";

                    m.dbCUD(sql, ref msg);
                }
            }
            else //수정
            {
                sql = "update tb_rorder_main " +
                    "set rorder_date = '" + sDate + "', cust_id = '" + sCust + "', project = '" + sProject + "', place = '" + sPlace + "', deli_date = '" + sDeliDate + "', contents = '" + sContents + "'" +
                    " where rorder_id = '" + sNo + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString())) continue;

                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    sAddSize = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sAddName = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sWeight = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sCost1 = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                    sCost2 = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                    sDocNo = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sProdNo = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();
                    sMatKind = dataGridView1.Rows[i].Cells[15].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells[1].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                        sSeq = getROrderSeq(sNo);
                    else
                        sSeq = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sWeight)) sWeight = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sCost1)) sCost1 = "0";
                    if (string.IsNullOrEmpty(sCost2)) sCost2 = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = "insert into tb_rorder_sub (rorder_id, rorder_seq, prod_id, add_name, add_size, qty, weight, danga, cost1, cost2, amount, doc_no, prod_no, mat_kind, proc_std)" +
                        " values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sAddName + "','" + sAddSize + "'," + sQty + "," + sWeight + "," + sDanga + "," + sCost1 + "," + sCost2 + "," + sAmount + ",'" + sDocNo + "','" + sProdNo + "','" + sMatKind + "','" + sProcStd + "')" +
                        " on duplicate key update" +
                        " prod_id = '" + sProdID + "', add_name = '" + sAddName + "', add_size = '" + sAddSize + "', qty = " + sQty + ", weight = " + sWeight + ", danga = " + sDanga + ", cost1 = " + sCost1 + ", cost2 = " + sCost2 + ", amount = " + sAmount + ", doc_no = '" + sDocNo + "', prod_no = '" + sProdNo + "', mat_kind = '" + sMatKind + "', proc_std = '" + sProcStd + "'";

                    m.dbCUD(sql, ref msg);
                }
            }

            ////견적정보 업데이트
            //if (!string.IsNullOrEmpty(sEstimateNo))
            //    estimateUpdate(sEstimateNo);


            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                {
                    dataGridViewList.CurrentCell = dataGridViewList[2, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + "-" + tbCust.Text);
            lblMsg.Text = "저장되었습니다.";
        }
        //private void estimateUpdate(string sNo)
        //{
        //    string sql = string.Empty;
        //    string msg = string.Empty;
        //    MariaCRUD m = new MariaCRUD();

        //    sql = "update tb_estimate_main set rorder_flag = 1 where estimate_id = '" + sNo + "'";

        //    m.dbCUD(sql, ref msg);

        //    if (msg != "OK")
        //    {
        //        MessageBox.Show(msg);
        //        return;
        //    }

        //    //

        //    sql = "update tb_estimate_sub set rorder_flag = 0 where estimate_id = '" + sNo + "'";

        //    m.dbCUD(sql, ref msg);

        //    if (msg != "OK")
        //    {
        //        MessageBox.Show(msg);
        //        return;
        //    }

        //    string sSeq = string.Empty;

        //    for (int i = 0; i < dataGridView1.RowCount; i++)
        //    {
        //        if (dataGridView1.Rows[i].Cells[2].Value == null ||
        //            string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString())) continue;

        //        sSeq = dataGridView1.Rows[i].Cells[17].Value.ToString();

        //        if (!string.IsNullOrEmpty(sSeq))
        //        {
        //            sql = "update tb_estimate_sub set rorder_flag = 1 where estimate_id = '" + sNo + "' and estimate_seq = " + sSeq;
        //            m.dbCUD(sql, ref msg);
        //        }
        //    }
        //}
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region 수주번호 생성
        private string getROrderNo()
        {
            string sql = @"select UF_ROrderNoGenerator('" + G.Pos + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private string getROrderSeq(string sNo)
        {
            string sql = @"select UF_ROrderSeqGenerator('" + sNo + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

    }
}
