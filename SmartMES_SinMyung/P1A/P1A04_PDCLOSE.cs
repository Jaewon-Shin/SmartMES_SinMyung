using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1A04_PDCLOSE : SmartMES_SinMyung.FormBasic
    {
        public P1A04_PDCLOSE()
        {
            InitializeComponent();
        }
        private void P1A04_PDCLOSE_Load(object sender, EventArgs e)
        {
            udY.Value = DateTime.Today.Year - 1;

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

            //cbDepot.SelectedIndex = 0;
            cbGubun.SelectedIndex = 0;
            //ListSearch();
        }

        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sY = udY.Value.ToString();
                string sDepot = cbDepot.SelectedValue.ToString();
                string sGubun = cbGubun.Text.Substring(0, 1);

                sP_PdClose_QueryTableAdapter.Fill(dataSetP1A.SP_PdClose_Query, G.Pos, sY, sDepot, sGubun);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
            }
            catch (Exception)
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
            P1A04_PDCLOSE_SUB sub = new P1A04_PDCLOSE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;
            string sDate = string.Empty;
            string sDepot = string.Empty;
            string sProd = string.Empty;
            string sProdName = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sDate = udY.Value.ToString() + "-12-31";
                sDepot = cbDepot.SelectedValue.ToString();
                sProd = dataGridView1.Rows[index].Cells[1].Value.ToString();
                sProdName = dataGridView1.Rows[index].Cells[3].Value.ToString();

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


            DialogResult dr = MessageBox.Show(sProdName + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_gi_pdclose where pos = '" + G.Pos + "' and close_date = '" + sDate + "' and depot = '" + sDepot + "' and prod_id = '" + sProd + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, udY.Value.ToString() + " " + sProdName);

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
        private void udY_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
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
            if (e.ColumnIndex != 1) return;

            P1A04_PDCLOSE_SUB sub = new P1A04_PDCLOSE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        #endregion
    }
}
