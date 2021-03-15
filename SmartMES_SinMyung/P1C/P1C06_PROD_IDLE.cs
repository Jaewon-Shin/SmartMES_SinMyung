using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C06_PROD_IDLE : SmartMES_SinMyung.FormBasic
    {
        public P1C06_PROD_IDLE()
        {
            InitializeComponent();
        }
        private void P1C06_PROD_IDLE_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));

            string sql = @"select t.co_code, t.co_item
                            from(
                            select '%' as co_code, '<전체>' as co_item
                            union 
                            select co_code, co_item from tb_gi_common where co_kind = 'F') as t
                            order by t.co_code";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbItem.DataSource = table;
                cbItem.ValueMember = "co_code";
                cbItem.DisplayMember = "co_item";
            }
            cbGrp.SelectedIndex = 0;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                string sItem = cbItem.SelectedValue.ToString();
                string sGrp = cbGrp.Text;
                if (sGrp == "<전체>") sGrp = "%";
                else sGrp = sGrp.Substring(0, 1);

                sP_ProdIdle_QueryTableAdapter.Fill(dataSetP1C.SP_ProdIdle_Query, dtFromDate, dtToDate, sItem, sGrp);

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

        #region Condition Bar Events
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cbGrp_SelectedIndexChanged(object sender, EventArgs e)
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

            dataGridView1[16, rowIndex].Value = rowIndex.ToString() + "건";

            //

            long iSum1 = long.Parse(dataGridView1.Rows[0].Cells[7].Value.ToString());
            long iSum2 = long.Parse(dataGridView1.Rows[0].Cells[8].Value.ToString());
            float fSum1 = float.Parse(dataGridView1.Rows[0].Cells[9].Value.ToString());
            float fSum2 = float.Parse(dataGridView1.Rows[0].Cells[14].Value.ToString());

            if (dataGridView1.RowCount < 3)
            {
                dataGridView1[7, 1].Value = iSum1;
                dataGridView1[8, 1].Value = iSum2;
                dataGridView1[9, 1].Value = fSum1;
                dataGridView1[14, 1].Value = fSum1;
                return;
            }

            string sJobNo = dataGridView1.Rows[0].Cells[10].Value.ToString();
            string sFacID = dataGridView1.Rows[0].Cells[11].Value.ToString();

            for (int i = 1; i < dataGridView1.RowCount - 1; i++)
            {
                if (sJobNo == dataGridView1.Rows[i].Cells[10].Value.ToString()
                    && sFacID == dataGridView1.Rows[i].Cells[11].Value.ToString())
                {
                    dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[7].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[8].Style.ForeColor = Color.Transparent;
                    dataGridView1.Rows[i].Cells[9].Style.ForeColor = Color.Transparent;
                }
                else
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    fSum1 += float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                }

                fSum2 += float.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());

                sJobNo = dataGridView1.Rows[i].Cells[10].Value.ToString();
                sFacID = dataGridView1.Rows[i].Cells[11].Value.ToString();
            }

            dataGridView1[7, rowIndex].Value = iSum1;
            dataGridView1[8, rowIndex].Value = iSum2;
            dataGridView1[9, rowIndex].Value = fSum1;
            dataGridView1[14, rowIndex].Value = fSum2;
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;

            string reportFileName = "SmartMES_SinMyung.Reports.P1C06_PROD_IDLE.rdlc";

            string reportParm1 = "생산기간 : ";
            string reportParm2 = "비가동사유 : ";
            string reportParm3 = "생산그룹 : ";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");
            reportParm2 = reportParm2 + cbItem.Text;
            reportParm3 = reportParm3 + cbGrp.Text;

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdIdleQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void P1C06_PROD_IDLE_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}