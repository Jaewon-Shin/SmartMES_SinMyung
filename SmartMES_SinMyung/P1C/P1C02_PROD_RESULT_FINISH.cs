using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C02_PROD_RESULT_FINISH : Form
    {
        public P1C02_PROD_RESULT parentWin;
        private int rowIndex;
        private string jobNo;
        private string procNo;

        public P1C02_PROD_RESULT_FINISH()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_FINISH_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            //제품창고
            string sql = @"select co_code, co_item from tb_gi_common where co_kind = 'B' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbDepot.DataSource = table;
                cbDepot.ValueMember = "co_code";
                cbDepot.DisplayMember = "co_item";
            }

            rowIndex = parentWin.dataGridViewY.CurrentCell.RowIndex;

            jobNo = parentWin.dataGridViewY.Rows[rowIndex].Cells[0].Value.ToString();
            procNo = parentWin.dataGridViewY.Rows[rowIndex].Cells[1].Value.ToString();
            tbJobNo.Text = jobNo;
            dtpDate.Value = DateTime.Parse(parentWin.dataGridViewY.Rows[rowIndex].Cells[14].Value.ToString());
            tbQty.Text = parentWin.dataGridViewY.Rows[rowIndex].Cells[15].Value.ToString();

            if (parentWin.dataGridViewY.Rows[rowIndex].Cells[17].Value.ToString() == "O")
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
            lblMsg.Text = "";

            string sql = @"select count(*) from tb_prod_result " + 
                "where job_no = '" + tbJobNo.Text + "' and jobtime_finish is not null";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            string com = m.dbRonlyOne(sql, ref msg).ToString();

            if (msg == "OK" && Int32.Parse(com) > 0) Save("1");
            else
            {
                lblMsg.Text = "생산 진행중인 LotNo.로 생산종료할 수 없습니다.";
                return;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Save("0");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
            string sDepot = cbDepot.SelectedValue.ToString();

            string sql = "update tb_prod_order " +
                "set rorder_date = '" + sDate + "', order_qty = " + sQty + ", prod_flag = " + flag +
                " where job_no = '" + jobNo + "' and proc_no = " + procNo;

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            if (flag == "1")
            {
                sql = "insert into tb_prod_done (job_no, pos, done_date, prod_id, add_name, add_size, rorder_id, rorder_seq, proc_std, done_qty, contents, depot, enter_man) " +
                "select p.job_no, '" + G.Pos + "','" + sDate + "', p.prod_id, p.add_name, p.add_size, p.rorder_id, p.rorder_seq, p.proc_std, " + sQty + ", p.ment, '" + sDepot + "','" + G.UserID + "' " +
                "from tb_prod_order p where p.job_no = '" + jobNo + "' and p.proc_no = " + procNo;
            }
            else
            {
                sql = "delete from tb_prod_done where job_no = '" + jobNo + "'";
            }

            m = new MariaCRUD();
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            parentWin.ListSearch();
            parentWin.dataGridViewY.CurrentCell = parentWin.dataGridViewY[0, rowIndex];
            parentWin.dataGridViewY.CurrentCell.Selected = true;

            this.DialogResult = DialogResult.OK;
        }

    }
}
