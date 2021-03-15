using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1A04_PDCLOSE_SUB : Form
    {
        public P1A04_PDCLOSE parentWin;
        private int rowIndex = 0;

        public P1A04_PDCLOSE_SUB()
        {
            InitializeComponent();
        }

        private void P1A04_PDCLOSE_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

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

            udY.Value = parentWin.udY.Value;
            cbDepot.SelectedIndex = parentWin.cbDepot.SelectedIndex;

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                this.ActiveControl = lblProd;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                tbProd.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                tbProd.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();

                udY.Enabled = false;
                cbDepot.Enabled = false;
                lblProd.Enabled = false;
                lblProd.Font = new Font(lblProd.Font, FontStyle.Regular);

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

        private void Save()
        {
            lblMsg.Text = "";

            if (tbProd.Tag == null)
            {
                lblMsg.Text = "품목명을 선택해 주세요.";
                lblProd.Focus();
                return;
            }

            string sProd = tbProd.Tag.ToString();
            string sQty = tbQty.Text.Replace(",", "").Trim();

            if (String.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "마감량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }

            string sDate = udY.Value.ToString() + "-12-31";
            string sDepot = cbDepot.SelectedValue.ToString();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                if (isPdCloseExist(G.Pos, sDate, sDepot, sProd))
                {
                    lblMsg.Text = "이미 존재하는 마감 품목입니다.";
                    lblProd.Focus();
                    return;
                }

                sql = "insert into tb_gi_pdclose (pos, close_date, depot, prod_id, close_qty, enter_man) " +
                    "values('" + G.Pos + "','" + sDate + "','" + sDepot + "','" + sProd + "'," + sQty + ",'" + G.UserID + "')";

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
                    if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sProd)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                tbProd.Tag = null;
                tbProd.Text = string.Empty;
                tbQty.Text = string.Empty;
                lblMsg.Focus();
            }
            else
            {
                sql = "update tb_gi_pdclose " +
                    "set close_qty = " + sQty +
                    " where pos = '" + G.Pos + "' and close_date = '" + sDate + "' and depot = '" + sDepot + "' and prod_id = '" + sProd + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sDate + " " + cbDepot.Text + " " + tbProd.Text);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        #region 재고 확인
        private bool isPdCloseExist(string _pos, string _date, string _depot, string _prod)
        {
            string sql = @"select prod_id from tb_gi_pdclose where pos = '" + _pos + "' and close_date = '" + _date + "' and depot = '" + _depot + "' and prod_id = '" + _prod + "'";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object id = m.dbRonlyOne(sql, ref msg);

            if (msg == "OK" && id != null)
                return true;
            else
                return false;
        }
        #endregion

        #region 품목명
        private void lblProd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            ProdFinder pop = new ProdFinder();
            pop.cbGubun.Text = parentWin.cbGubun.Text;
            pop._kind = "%";
            pop._stockFlag = "1";
            pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
            pop.ShowDialog();
        }
        private void ProdEventMethod(object sender)
        {
            string sProd = sender.ToString();

            if (string.IsNullOrEmpty(sProd)) return;

            tbProd.Tag = sProd.Substring(0, 8);
            tbProd.Text = sProd.Substring(9, sProd.Length - 9);
            tbQty.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
