using System;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B11_PURCHASE_TOLL_SUB : Form
    {
        public P1B11_PURCHASE_TOLL parentWin;

        private int rowIndex = 0;
        private string sNo = string.Empty;
        public string sROrderNo = string.Empty;
        public string sROrderSeq = string.Empty;

        public P1B11_PURCHASE_TOLL_SUB()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_TOLL_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                this.ActiveControl = lblCust;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                sNo = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                tbNo.Text = sNo;
                tbCust.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                tbCust.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                dtpPutchDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                dtpRequestDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());
                sROrderNo = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                sROrderSeq = parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();
                tbProcessID.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value.ToString();
                tbProcessID.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[16].Value.ToString();
                tbProd.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                tbProd.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                tbAddName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                tbSize.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                tbQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                tbDanga.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                tbMoney.Text = (long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString()) * long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString())).ToString("#,##0");

                this.ActiveControl = btnSave;
            }
        }

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

        #region 발주처/품목선택
        private void lblCust_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            CustFinder sub = new CustFinder();
            sub.FormSendEvent += new CustFinder.FormSendDataHandler(CustEventMethod);
            sub._gubun = "023";
            sub.ShowDialog();
        }
        private void CustEventMethod(object sender)
        {
            string sCust = sender.ToString();

            if (string.IsNullOrEmpty(sCust)) return;

            tbCust.Tag = sCust.Substring(0, 7);
            tbCust.Text = sCust.Substring(8, sCust.Length - 8);
        }
        private void lblProcess_Click(object sender, EventArgs e)
        {
            P1B11_PURCHASE_TOLL_RORDER sub = new P1B11_PURCHASE_TOLL_RORDER();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void lblProd_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            ProdFinder pop = new ProdFinder();
            pop.cbGubun.SelectedIndex = 0;
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
            tbSize.Focus();
        }
        #endregion

        #region 발주번호 생성
        private string getCode(string _kind)
        {
            string sql = @"select UF_PurchaseNoGenerator('" + _kind + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbQty.SelectionStart = tbQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbQty.SelectionLength = 0;

                //

                long lQty = long.Parse(tbQty.Text.Replace(",", "").Trim());
                long lDanga = long.Parse(tbDanga.Text.Replace(",", "").Trim());
                tbMoney.Text = (lQty * lDanga).ToString("#,##0");
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbDanga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbDanga.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbDanga.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbDanga.SelectionStart = tbDanga.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbDanga.SelectionLength = 0;

                //

                long lQty = long.Parse(tbQty.Text.Replace(",", "").Trim());
                long lDanga = long.Parse(tbDanga.Text.Replace(",", "").Trim());
                tbMoney.Text = (lQty * lDanga).ToString("#,##0");
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

            string sCust = string.Empty;
            string sProd = string.Empty;
            if (tbCust.Tag != null) sCust = tbCust.Tag.ToString();
            if (tbProd.Tag != null) sProd = tbProd.Tag.ToString();

            string sQty = tbQty.Text.Replace(",", "").Trim();
            string sDanga = tbDanga.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sCust))
            {
                lblMsg.Text = "가공처를 선택해 주세요.";
                tbCust.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sProd))
            {
                lblMsg.Text = "품목명을 선택해 주세요.";
                tbProd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "발주수량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sDanga))
            {
                lblMsg.Text = "단가를 입력해 주세요.";
                tbDanga.Focus();
                return;
            }
            if (dtpPutchDate.Value.Date > dtpRequestDate.Value.Date)
            {
                lblMsg.Text = "입고요청일자를 다시 확인해 주세요.";
                dtpRequestDate.Focus();
                return;
            }

            string sPutchDate = dtpPutchDate.Value.ToString("yyyy-MM-dd");
            string sRequestDate = dtpRequestDate.Value.ToString("yyyy-MM-dd");
            string sAddName = tbAddName.Text.Trim();
            string sSize = tbSize.Text.Trim();
            string sProcessID = string.Empty;
            if (tbProcessID.Tag == null || string.IsNullOrEmpty(tbProcessID.Tag.ToString()))
            {
                sROrderNo = "";
                sROrderSeq = "null";
                sProcessID = "null";
            }
            else
            {
                sProcessID = tbProcessID.Tag.ToString();
            }

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                sNo = getCode("PT");

                sql = "insert into tb_purchase_toll (purch_id, pos, putch_date, cust_id, request_date, prod_id, add_name, add_size, putch_qty, danga, rorder_id, rorder_seq, process_id, enter_man1) " +
                    "values('" + sNo + "','" + G.Pos + "','" + sPutchDate + "','" + sCust + "','" + sRequestDate + "','" + sProd + "','" + sAddName + "','" + sSize + "'," + sQty + "," + sDanga + ",'" + sROrderNo + "'," + sROrderSeq + "," + sProcessID + ",'" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                lblMsg.Text = "저장되었습니다.";

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                sNo = string.Empty;
                tbAddName.Text = string.Empty;
                tbSize.Text = string.Empty;
                tbQty.Text = string.Empty;
                tbDanga.Text = string.Empty;
                tbMoney.Text = string.Empty;
                tbAddName.Focus();
            }
            else
            {
                sql = "update tb_purchase_toll " +
                    "set putch_date = '" + sPutchDate + "', cust_id = '" + sCust + "', request_date = '" + sRequestDate + "', prod_id = '" + sProd + "', add_name = '" + sAddName + "', add_size = '" + sSize + "', putch_qty = " + sQty + ", danga = " + sDanga + ", rorder_id = '" + sROrderNo + "', rorder_seq = " + sROrderSeq + ", process_id = " + sProcessID +
                    " where purch_id = '" + sNo + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + " " + sPutchDate + " " + tbCust.Text + " " + tbProd.Text);

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
