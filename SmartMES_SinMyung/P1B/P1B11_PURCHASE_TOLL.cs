using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B11_PURCHASE_TOLL : SmartMES_SinMyung.FormBasic
    {
        public P1B11_PURCHASE_TOLL()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_TOLL_Load(object sender, EventArgs e)
        {
            cbTerm.SelectedIndex = 0;
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            cbGubun.SelectedIndex = 0;

            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sFlag = cbTerm.Text.Substring(0, 1);
                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                string sSearch = tbSearch.Text.Trim();
                string sGubun = cbGubun.Text;
                if (sGubun == "<전체>") sGubun = "%";
                else if (!string.IsNullOrEmpty(sGubun)) sGubun = sGubun.Substring(0, 1);

                sP_PurchaseToll_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseToll_Query, sFlag, dtFromDate, dtToDate, sSearch, sGubun);

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

        #region Condition Bar Events
        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void cbGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1[3, rowIndex].Value = rowIndex.ToString() + "건";

            //

            try
            {
                long iSum1 = 0, iSum2 = 0, iSum3 = 0, iSum4 = 0, iSum5 = 0, iSum6 = 0;
                DataGridViewButtonCell buttonCell;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                    iSum3 += long.Parse(dataGridView1.Rows[i].Cells[20].Value.ToString());
                    iSum4 += long.Parse(dataGridView1.Rows[i].Cells[21].Value.ToString());
                    iSum5 += long.Parse(dataGridView1.Rows[i].Cells[22].Value.ToString());
                    iSum6 += long.Parse(dataGridView1.Rows[i].Cells[23].Value.ToString());

                    if (!(dataGridView1.Rows[i].Cells[26].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[26].Value.ToString())))
                    {
                        buttonCell = (DataGridViewButtonCell)dataGridView1.Rows[i].Cells[17];
                        buttonCell.FlatStyle = FlatStyle.Popup;
                        buttonCell.Style.ForeColor = System.Drawing.Color.Red;
                    }
                }

                dataGridView1[8, rowIndex].Value = iSum1;
                dataGridView1[10, rowIndex].Value = iSum2;
                dataGridView1[20, rowIndex].Value = iSum3;
                dataGridView1[21, rowIndex].Value = iSum4;
                dataGridView1[22, rowIndex].Value = iSum5;
                dataGridView1[23, rowIndex].Value = iSum6;
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.RowIndex == dataGridView1.RowCount - 1) return;

            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentCell.Selected = true;

            if (e.ColumnIndex == 5)
            {
                P1B11_PURCHASE_TOLL_SUB sub = new P1B11_PURCHASE_TOLL_SUB();
                sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
                sub.parentWin = this;
                sub.ShowDialog();
            }
            else if (e.ColumnIndex == 17)
            {
                P1B11_PURCHASE_TOLL_IN sub = new P1B11_PURCHASE_TOLL_IN();
                if (dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString() == "0")
                    sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
                else
                    sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
                sub.parentWin = this;
                sub.ShowDialog();
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dataGridView1.RowCount - 1) return;

            if (!(e.ColumnIndex == 20 || e.ColumnIndex == 21 || e.ColumnIndex == 22 || e.ColumnIndex == 23))
                return;

            if (e.Value.ToString() == "0")
                e.CellStyle.ForeColor = Color.Transparent;
            else
            {
                if (e.ColumnIndex == 21)
                {
                    long lQty = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString());
                    long lDanga = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    long lAmount = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString());

                    if ((lQty * lDanga) == lAmount)
                        e.CellStyle.ForeColor = Color.Black;
                    else
                        e.CellStyle.ForeColor = Color.Red;
                }
                else
                    e.CellStyle.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            P1B11_PURCHASE_TOLL_SUB sub = new P1B11_PURCHASE_TOLL_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;
            string sNo = string.Empty;
            string sCustName = string.Empty;
            string sProdName = string.Empty;
            string sAddName = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sNo = dataGridView1.Rows[index].Cells[0].Value.ToString();
                sCustName = dataGridView1.Rows[index].Cells[3].Value.ToString();
                sProdName = dataGridView1.Rows[index].Cells[5].Value.ToString();
                sAddName = dataGridView1.Rows[index].Cells[6].Value.ToString();

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


            DialogResult dr = MessageBox.Show(sNo + "\r" + sCustName + "\r(" + sProdName + "-" + sAddName + ")\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_purchase_toll where purch_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sCustName + " (" + sProdName + "-" + sAddName + ")");

            ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_SinMyung.Reports.P1B11_PURCHASE_TOLL.rdlc";

            string reportParm1 = cbTerm.Text.Substring(2, cbTerm.Text.Length - 2) + " : ";
            string reportParm2 = "가공처/품목명/자재명 : ";
            string reportParm3 = "구 분 : ";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            reportParm3 = reportParm3 + cbGubun.Text;

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPPurchaseTollQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}
