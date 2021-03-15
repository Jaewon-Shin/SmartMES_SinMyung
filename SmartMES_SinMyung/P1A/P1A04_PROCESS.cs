using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1A04_PROCESS : SmartMES_SinMyung.FormBasic
    {
        public P1A04_PROCESS()
        {
            InitializeComponent();
        }
        private void P1A04_PROCESS_Load(object sender, EventArgs e)
        {
            string sql = @"select co_code, co_item from tb_gi_common where co_kind = 'D' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbStd.DataSource = table;
                cbStd.ValueMember = "co_code";
                cbStd.DisplayMember = "co_item";
                cbStd.SelectedIndex = 0;
            }

            this.ActiveControl = cbStd;
        }

        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sKind = cbStd.SelectedValue.ToString();
                if (sKind.Length != 4) return;

                sP_Process_QueryTableAdapter.Fill(dataSetP1A.SP_Process_Query, sKind);

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

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            P1A04_PROCESS_SUB sub = new P1A04_PROCESS_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;
            string sStd = string.Empty;
            string sStdName = string.Empty;
            string sNo = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sStd = dataGridView1.Rows[index].Cells[0].Value.ToString();
                sStdName = dataGridView1.Rows[index].Cells[1].Value.ToString();
                sNo = dataGridView1.Rows[index].Cells[2].Value.ToString();

                if (dataGridView1.Rows[index].Selected != true)
                {
                    MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult dr = MessageBox.Show(sStdName + "\r" + sNo + " 공정\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_gi_process where proc_std = '" + sStd + "' and proc_no = " + sNo;
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sStdName + " " + sNo);

            ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Condition Bar Events
        private void cbStd_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 3) return;

            P1A04_PROCESS_SUB sub = new P1A04_PROCESS_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        #endregion
    }
}
