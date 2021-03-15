using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1A04_PROCESS_SUB : Form
    {
        public P1A04_PROCESS parentWin;

        private int rowIndex = 0;
        private string procStd = string.Empty;
        private string procNo = string.Empty;

        public P1A04_PROCESS_SUB()
        {
            InitializeComponent();
        }

        private void P1A04_PROCESS_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sql = @"select co_code, co_item from tb_gi_common where co_kind = 'D' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbKind.DataSource = table;
                cbKind.ValueMember = "co_code";
                cbKind.DisplayMember = "co_item";
            }

            cbKind.SelectedIndex = parentWin.cbStd.SelectedIndex;

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                cbGroup.Text = "A.CNC";
                this.ActiveControl = tbName;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                procStd = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                procNo = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                tbNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                tbName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbTool.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();

                string sTime = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                if (!string.IsNullOrEmpty(sTime))
                    tbTime.Text = float.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString()).ToString("0.0");

                cbGroup.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                string sFinal = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                if (sFinal == "O") ckFinalFlag.Checked = true;

                cbKind.Enabled = false;
                tbNo.Enabled = false;
                this.ActiveControl = tbName;
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

            string sNo = tbNo.Text.Trim();
            string sName = tbName.Text.Trim();
            string sTool = tbTool.Text.Trim();
            string sTime = tbTime.Text.Trim();
            string sGroup = cbGroup.Text.Substring(0, 1);
            string sFinal = "0";
            if (ckFinalFlag.Checked) sFinal = "1";

            if (String.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "공정번호를 입력해 주세요.";
                tbNo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(sName))
            {
                lblMsg.Text = "공정명을 입력해 주세요.";
                tbName.Focus();
                return;
            }
            float f = 0;
            if (!String.IsNullOrEmpty(sTime) && float.TryParse(sTime, out f) == false)
            {
                lblMsg.Text = "표준공정시간을 확인해 주세요.";
                tbTime.Focus();
                return;
            }
            if (!String.IsNullOrEmpty(sTime) && float.Parse(sTime) < 0)
            {
                lblMsg.Text = "표준공정시간을 확인해 주세요.";
                tbTime.Focus();
                return;
            }
            if (sGroup != "Y" && sFinal == "1")
            {
                lblMsg.Text = "마지막공정은 출하대기 공정이어야 합니다.";
                cbGroup.Focus();
                return;
            }
            if (String.IsNullOrEmpty(sTime)) sTime = "NULL";

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                procStd = cbKind.SelectedValue.ToString();

                if (isExist(procStd, sNo))
                {
                    lblMsg.Text = "이미 존재하는 공정번호입니다.";
                    tbNo.Focus();
                    return;
                }

                sNo = transProcessNo(procStd, sNo);

                if (sFinal == "1")
                {
                    sql = "update tb_gi_process set final_flag = 0 where proc_std = '" + procStd + "'";
                    m.dbCUD(sql, ref msg);
                }

                sql = "insert into tb_gi_process (proc_std, proc_no, proc_name, proc_tools, std_time, job_group, final_flag) " +
                    "values('" + procStd + "'," + sNo + ",'" + sName + "','" + sTool + "'," + sTime + ",'" + sGroup + "'," + sFinal + ")";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                lblMsg.Text = "저장되었습니다.";

                parentWin.cbStd.Text = cbKind.Text;
                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[2].Value.ToString() == sNo)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                tbNo.Text = string.Empty;
                tbName.Text = string.Empty;
                tbTool.Text = string.Empty;
                tbTime.Text = string.Empty;
                ckFinalFlag.Checked = false;
                tbNo.Focus();
            }
            else
            {
                if (sFinal == "1")
                {
                    sql = "update tb_gi_process set final_flag = 0 where proc_std = '" + procStd + "'";
                    m.dbCUD(sql, ref msg);
                }

                sql = "update tb_gi_process " +
                    "set proc_name = '" + sName + "', proc_tools = '" + sTool + "', std_time = " + sTime + ", job_group = '" + sGroup + "', final_flag = " + sFinal +
                    " where proc_std = '" + procStd + "' and proc_no = " + procNo;

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, procStd + " " + cbKind.Text + " " + procNo);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        #region 공정번호 생성/확인/변환
        private string getProcessNo(string _kind)
        {
            string sql = @"select UF_ProcessNoGenerator('" + _kind + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private bool isExist(string _kind, string _no)
        {
            string sql = @"select proc_no from tb_gi_process where proc_std = '" + _kind + "' and proc_no = " + _no;

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object id = m.dbRonlyOne(sql, ref msg);

            if (msg == "OK" && id != null)
                return true;
            else
                return false;
        }
        private string transProcessNo(string _kind, string _no)
        {
            string sql = @"select min(s.proc_no) from tb_gi_process s where s.proc_std = '" + _kind + "' and proc_no > " + _no;

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object maxVal = m.dbRonlyOne(sql, ref msg);

            if (msg != "OK" || maxVal == null || string.IsNullOrEmpty(maxVal.ToString()))
                return getProcessNo(_kind);


            sql = @"select max(s.proc_no) from tb_gi_process s where s.proc_std = '" + _kind + "' and proc_no < " + _no;

            m = new MariaCRUD();
            object minVal = m.dbRonlyOne(sql, ref msg);

            if (msg != "OK" || minVal == null || string.IsNullOrEmpty(minVal.ToString()))
                minVal = 0;

            int q = Int32.Parse(minVal.ToString()) + (Int32.Parse(maxVal.ToString()) - Int32.Parse(minVal.ToString())) / 2 ;
            return q.ToString();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbNo.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbNo.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbNo.SelectionStart = tbNo.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbNo.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                string sKind = cbKind.SelectedValue.ToString();
                if (sKind.Length != 4) return;
                tbNo.Text = getProcessNo(sKind);
                tbName.Focus();
            }
        }
    }
}
