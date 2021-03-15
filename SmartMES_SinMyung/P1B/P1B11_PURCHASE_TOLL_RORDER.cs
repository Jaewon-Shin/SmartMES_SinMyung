using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B11_PURCHASE_TOLL_RORDER : Form
    {
        public P1B11_PURCHASE_TOLL_SUB parentWin;

        public P1B11_PURCHASE_TOLL_RORDER()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_TOLL_RORDER_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_Purchase_ROderTableAdapter.Fill(dataSetP1B.SP_Purchase_ROder, sSearch);

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

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X + 1, pbSearch.Location.Y + 1);
        }
        private void pbSearch_MouseUp(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X - 1, pbSearch.Location.Y - 1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 14) return;

            string sProcStd = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();

            string sql = @"select proc_no, concat(proc_no,'.',proc_name) as proc_name from tb_gi_process where proc_std = '" + sProcStd + "' order by proc_no";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                lbProcList.DataSource = table;
                lbProcList.ValueMember = "proc_no";
                lbProcList.DisplayMember = "proc_name";
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
                        dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Transparent;
                        dataGridView1.Rows[i].Cells[3].Value = "";
                        dataGridView1.Rows[i].Cells[4].Value = "";
                        dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Transparent;
                    }
                    sSujuNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void lbProcList_DoubleClick(object sender, EventArgs e)
        {
            if (lbProcList.SelectedValue == null) return;

            parentWin.tbProcessID.Tag = lbProcList.SelectedValue;
            parentWin.tbProcessID.Text = lbProcList.Text;

            int iCurRow = dataGridView1.CurrentRow.Index;

            parentWin.sROrderNo = dataGridView1.Rows[iCurRow].Cells[0].Value.ToString();
            parentWin.sROrderSeq = dataGridView1.Rows[iCurRow].Cells[7].Value.ToString();
            parentWin.tbProd.Tag = dataGridView1.Rows[iCurRow].Cells[8].Value.ToString();
            parentWin.tbProd.Text = dataGridView1.Rows[iCurRow].Cells[9].Value.ToString();
            parentWin.tbAddName.Text = dataGridView1.Rows[iCurRow].Cells[10].Value.ToString();
            parentWin.tbSize.Text = dataGridView1.Rows[iCurRow].Cells[11].Value.ToString();
            parentWin.tbQty.Text = dataGridView1.Rows[iCurRow].Cells[12].Value.ToString();

            this.Dispose();
        }
    }
}
