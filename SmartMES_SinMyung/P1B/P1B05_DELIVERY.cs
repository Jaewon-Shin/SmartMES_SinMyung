using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B05_DELIVERY : SmartMES_SinMyung.FormBasic
    {
        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B05_DELIVERY()
        {
            InitializeComponent();
        }
        private void P1B05_DELIVERY_Load(object sender, EventArgs e)
        {
            this.sP_Z_Common_IDTableAdapter.Fill(this.dataSetP1B.SP_Z_Common_ID, "B"); //출하창고
            ListSearch1();
            cbDeliCar.SelectedIndex = 0;
        }
        public void ListSearch1()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_DeliveryMain_QueryTableAdapter.Fill(dataSetP1B.SP_DeliveryMain_Query, sSearch);

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
            tbProject.Text = dataGridViewList.Rows[rowIndex].Cells[6].Value.ToString();
            tbPlace.Text = dataGridViewList.Rows[rowIndex].Cells[7].Value.ToString();
            tbSaleMan.Text = dataGridViewList.Rows[rowIndex].Cells[5].Value.ToString();

            string sCar = dataGridViewList.Rows[rowIndex].Cells[8].Value.ToString();
            if (sCar == "9") cbDeliCar.SelectedIndex = cbDeliCar.Items.Count - 1;
            else cbDeliCar.SelectedIndex = Int32.Parse(sCar) - 1;

            tbROderNo.Text = dataGridViewList.Rows[rowIndex].Cells[10].Value.ToString();
            tbDeliInfo.Text = dataGridViewList.Rows[rowIndex].Cells[9].Value.ToString();
            tbContents.Text = dataGridViewList.Rows[rowIndex].Cells[11].Value.ToString();

            Cursor.Current = Cursors.Default;
        }
        public void ListSearch3()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sNo = tbNo.Text;

                sP_DeliverySub_QueryTableAdapter.Fill(dataSetP1B.SP_DeliverySub_Query, sNo);

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
                long lTot = 0;
                string sMoneySum;
                string sMoneyTot;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value != null) iCnt++;
                    //
                    if (dataGridView1.Rows[i].Cells[8].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString()))
                        sMoneySum = "0";
                    else
                        sMoneySum = dataGridView1.Rows[i].Cells[8].Value.ToString();

                    lSum += long.Parse(sMoneySum);
                    //
                    if (dataGridView1.Rows[i].Cells[10].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[10].Value.ToString()))
                        sMoneyTot = "0";
                    else
                        sMoneyTot = dataGridView1.Rows[i].Cells[10].Value.ToString();

                    lTot += long.Parse(sMoneyTot);
                }

                lblSumMoney.Text = "합계금액 : " + lSum.ToString("#,##0") + "원";
                lblTotMoney.Text = "전체금액 : " + lTot.ToString("#,##0") + "원";
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
            tbProject.Text = string.Empty;
            tbPlace.Text = string.Empty;
            tbSaleMan.Text = string.Empty;
            tbROderNo.Text = string.Empty;
            tbDeliInfo.Text = string.Empty;
            tbContents.Text = string.Empty;

            sP_DeliverySub_QueryTableAdapter.Fill(dataSetP1B.SP_DeliverySub_Query, "");

            lblSumMoney.Text = "합계금액 : 0원";
            lblTotMoney.Text = "전체금액 : 0원";
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

                    if (columnIndex == 11)
                        dataGridView1.CurrentCell = dataGridView1[3, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
                }
                if (e.KeyCode == Keys.Tab)
                {
                    e.Handled = true;
                }
            }
            //catch (ArgumentOutOfRangeException)
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

                int money1 = 0;
                int money2 = 0;
                int moneyMon = 0;

                if (columnIndex == 6 || columnIndex == 7) //수량, 단가
                {
                    if (dataGridView1.Rows[rowIndex].Cells[6].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[6].Value.ToString().Length != 0)
                        money1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[7].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[7].Value.ToString().Length != 0)
                        money2 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());

                    moneyMon = money1 * money2;
                    dataGridView1.Rows[rowIndex].Cells[8].Value = moneyMon;
                    dataGridView1.Rows[rowIndex].Cells[9].Value = Math.Round(moneyMon * 0.1);
                    dataGridView1.Rows[rowIndex].Cells[10].Value = moneyMon + Math.Round(moneyMon * 0.1);

                    ListSearch4();
                }
                else if (columnIndex == 8) //금액
                {
                    if (dataGridView1.Rows[rowIndex].Cells[8].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length != 0)
                        moneyMon = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[9].Value = Math.Round(moneyMon * 0.1);
                    dataGridView1.Rows[rowIndex].Cells[10].Value = moneyMon + Math.Round(moneyMon * 0.1);

                    ListSearch4();
                }
                else if (columnIndex == 9) //부가세
                {
                    if (dataGridView1.Rows[rowIndex].Cells[8].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length != 0)
                        money1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[9].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[9].Value.ToString().Length != 0)
                        money2 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());

                    moneyMon = money1 + money2;
                    dataGridView1.Rows[rowIndex].Cells[10].Value = moneyMon;

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
                    if (columnIndex == 11)
                        dataGridView1.CurrentCell = dataGridView1[3, rowIndex + 1];
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

            if (e.ColumnIndex == 14)
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
                    string sql = "delete from tb_delivery_sub where deli_id = '" + sNo + "' and deli_seq = " + sSeq;
                    string msg = string.Empty;
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }

                    string sROrderNo = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    string sROrderSeq = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                    if (!string.IsNullOrEmpty(sROrderNo))
                    {
                        sql = "update tb_rorder_sub set deli_flag = 0 where rorder_id = '" + sROrderNo + "' and rorder_seq = " + sROrderSeq;
                        m.dbCUD(sql, ref msg);
                    }

                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sSeq);
                }
                //catch (InvalidOperationException)
                catch (Exception)
                {
                    return;
                }
            }

            ListSearch4();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            long lQty = 0;
            long lDanga = 0;
            long lAmount = 0;
            long lVat = 0;
            long lTot = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lQty = Convert.ToInt64(row.Cells[6].Value);
                    lDanga = Convert.ToInt64(row.Cells[7].Value);
                    lAmount = Convert.ToInt64(row.Cells[8].Value);
                    lVat = Convert.ToInt64(row.Cells[9].Value);
                    lTot = Convert.ToInt64(row.Cells[10].Value);

                    if ((lQty * lDanga) == lAmount)
                        row.Cells[8].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[8].Style.ForeColor = Color.Red;

                    if ((lAmount + lVat) == lTot)
                        row.Cells[10].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[10].Style.ForeColor = Color.Red;
                }
                ListSearch4();
            }
            //catch (InvalidCastException)
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

            P1B05_DELIVERY_SUB sub = new P1B05_DELIVERY_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "삭제할 전표번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 전표번호만 삭제할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("전표번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_delivery_main where deli_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show("전표번호 : '" + sNo + "'\r\r이미 타 업무에서 사용중인 전표번호이므로,\r삭제할 수 없습니다.");
                return;
            }

            string sROrderNo = tbROderNo.Text;
            if (!string.IsNullOrEmpty(sROrderNo))
            {
                sql = "update tb_rorder_sub set deli_flag = 0 where rorder_id = '" + sROrderNo + "'";
                m.dbCUD(sql, ref msg);
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + tbProject.Text);

            ListSearch1();
            ListInit();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            dataGridView1.CurrentCell = dataGridView1[3, 0];
            lblMsg.Text = "";

            string sROrderNo = tbROderNo.Text;

            if (string.IsNullOrEmpty(sROrderNo))
            {
                lblMsg.Text = "출하건이 선택되지 않았습니다.";
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
            string sPlace = tbPlace.Text.Trim();
            string sDeliCar = cbDeliCar.Text.Substring(0, 1);
            string sDeliInfo = tbDeliInfo.Text.Trim();
            string sContents = tbContents.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sSeq = string.Empty;
            string sDepot = string.Empty;
            string sProdID = string.Empty;
            string sAddName = string.Empty;
            string sAddSize = string.Empty;
            string sQty = string.Empty;
            string sDanga = string.Empty;
            string sAmount = string.Empty;
            string sVat = string.Empty;
            string sROrderSeq = string.Empty;

            if (string.IsNullOrEmpty(sNo)) //추가
            {
                sNo = getDeliNo();
                sql = "insert into tb_delivery_main (deli_id, pos, deli_date, cust_id, place, deli_car, deli_info, rorder_id, contents, enter_man) " +
                    "values('" + sNo + "','" + G.Pos + "','" + sDate + "','" + sCust + "','" + sPlace + "'," + sDeliCar + ",'" + sDeliInfo + "','" + sROrderNo + "','" + sContents + "','" + G.UserID + "')";

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
                    sDepot = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    sAddName = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                    sAddSize = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sVat = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sROrderSeq = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";
                    if (string.IsNullOrEmpty(sVat)) sVat = "0";

                    sql = "insert into tb_delivery_sub (deli_id, deli_seq, depot, prod_id, add_name, add_size, qty, danga, amount, vat, rorder_id, rorder_seq) " +
                          "values('" + sNo + "'," + sSeq + ",'" + sDepot + "','" + sProdID + "','" + sAddName + "','" + sAddSize + "'," + sQty + "," + sDanga + "," + sAmount + "," + sVat + ",'" + sROrderNo + "'," + sROrderSeq + ")";
                    m.dbCUD(sql, ref msg);

                    sql = "update tb_rorder_sub " +
                        "set deli_flag = if(qty > ifnull((select sum(qty) from tb_delivery_sub where rorder_id = '" + sROrderNo + "' and rorder_seq = " + sROrderSeq + "),0),0,1) " +
                        "where rorder_id = '" + sROrderNo + "' and rorder_seq = " + sROrderSeq;
                    m.dbCUD(sql, ref msg);
                }
            }
            else //수정
            {
                sql = "update tb_delivery_main " +
                    "set deli_date = '" + sDate + "', cust_id = '" + sCust + "', place = '" + sPlace + "', deli_car = '" + sDeliCar + "', deli_info = '" + sDeliInfo + "', rorder_id = '" + sROrderNo + "', contents = '" + sContents + "'" +
                    " where deli_id = '" + sNo + "'";

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

                    sDepot = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    sAddName = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                    sAddSize = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sVat = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sROrderSeq = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells[1].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                        sSeq = getDeliSeq(sNo);
                    else
                        sSeq = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";
                    if (string.IsNullOrEmpty(sVat)) sVat = "0";

                    sql = "insert into tb_delivery_sub (deli_id, deli_seq, depot, prod_id, add_name, add_size, qty, danga, amount, vat, rorder_id, rorder_seq)" +
                        " values('" + sNo + "'," + sSeq + ",'" + sDepot + "','" + sProdID + "','" + sAddName + "','" + sAddSize + "'," + sQty + "," + sDanga + "," + sAmount + "," + sVat + ",'" + sROrderNo + "'," + sROrderSeq + ")" +
                        " on duplicate key update" +
                        " depot = '" + sDepot + "', prod_id = '" + sProdID + "', add_name = '" + sAddName + "', add_size = '" + sAddSize + "', qty = " + sQty + ", danga = " + sDanga + ", amount = " + sAmount + ", vat = " + sVat + ", rorder_id = '" + sROrderNo + "', rorder_seq = " + sROrderSeq;

                    m.dbCUD(sql, ref msg);
                }
            }

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

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + "-" + tbProject.Text);
            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 출하건만 명세서 출력이 가능합니다.";
                return;
            }

            sP_Delivery_PrintTableAdapter.Fill(dataSetP1B.SP_Delivery_Print, sNo);

            string sql = @"select sum(amount+vat) from tb_delivery_sub where deli_id = '" + sNo + "'";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            long lTotAmount = long.Parse(m.dbRonlyOne(sql, ref msg).ToString());

            //

            string reportFileName = "SmartMES_SinMyung.Reports.P1B05_DELIVERY.rdlc";

            string reportParm1 = "합계금액 : ";
            reportParm1 = reportParm1 + new MyClass().Number2Hangle(lTotAmount) + " 원정";


            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPDeliveryPrintBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        #region 출하번호 생성
        private string getDeliNo()
        {
            string sql = @"select UF_DeliveryNoGenerator('" + G.Pos + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private string getDeliSeq(string sNo)
        {
            string sql = @"select UF_DeliverySeqGenerator('" + sNo + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion
    }
}
