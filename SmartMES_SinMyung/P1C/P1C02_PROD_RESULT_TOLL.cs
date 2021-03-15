using System;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C02_PROD_RESULT_TOLL : Form
    {
        public P1C02_PROD_RESULT parentWin;
        private int rowIndex;
        private string jobNo;
        private string procNo;

        public P1C02_PROD_RESULT_TOLL()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_TOLL_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            rowIndex = parentWin.dataGridViewX.CurrentCell.RowIndex;

            jobNo = parentWin.dataGridViewX.Rows[rowIndex].Cells[0].Value.ToString();
            procNo = parentWin.dataGridViewX.Rows[rowIndex].Cells[1].Value.ToString();
            tbJobNo.Text = jobNo;
            dtpDate.Value = DateTime.Parse(parentWin.dataGridViewX.Rows[rowIndex].Cells[14].Value.ToString());
            tbQty.Text = parentWin.dataGridViewX.Rows[rowIndex].Cells[15].Value.ToString();
            tbMent.Text = parentWin.dataGridViewX.Rows[rowIndex].Cells[16].Value.ToString();

            if (parentWin.dataGridViewX.Rows[rowIndex].Cells[17].Value.ToString() == "O")
            {
                btnOk.Enabled = false;
                this.ActiveControl = btnCancel;
            }
            else
            {
                btnCancel.Enabled = false;
                this.ActiveControl = btnOk;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save("1");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Save("0");
        }
        private void Save(string flag)
        {
            lblMsg.Text = "";

            string sQty = tbQty.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "수량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sMent = tbMent.Text.Trim();

            string sql = "update tb_prod_order " +
                "set rorder_date = '" + sDate + "', order_qty = " + sQty + ", ment = '" + sMent + "', prod_flag = " + flag +
                " where job_no = '" + jobNo + "' and proc_no = " + procNo;

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            parentWin.ListSearch();
            parentWin.dataGridViewX.CurrentCell = parentWin.dataGridViewX[0, rowIndex];
            parentWin.dataGridViewX.CurrentCell.Selected = true;

            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
