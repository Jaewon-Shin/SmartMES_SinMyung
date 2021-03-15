using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1B07_DELI_REPORT : SmartMES_SinMyung.FormBasic
    {
        string sOutNo = string.Empty;
        Color c = Color.Beige;

        public P1B07_DELI_REPORT()
        {
            InitializeComponent();
        }
        private void P1B07_DELI_REPORT_Load(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtDate = DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd"));
                string sSearch = tbSearch.Text.Trim();

                sP_DeliReport_QueryTableAdapter.Fill(dataSetP1B.SP_DeliReport_Query, dtDate, sSearch);

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
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void userButtonA1_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
            ListSearch();
        }
        private void userButtonA2_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
            ListSearch();
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
                if (rowIndex <= 0) return;

                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

                dataGridView1[3, rowIndex].Value = rowIndex.ToString() + "건";

                //

                long iSum1 = 0, iSum2 = 0, iSum3 = 0, iSum4 = 0, iSum5 = 0;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                    iSum3 += long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                    iSum4 += long.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());
                    iSum5 += long.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
                }

                dataGridView1[11, rowIndex].Value = iSum1;
                dataGridView1[12, rowIndex].Value = iSum2;
                dataGridView1[13, rowIndex].Value = iSum3;
                dataGridView1[14, rowIndex].Value = iSum4;
                dataGridView1[15, rowIndex].Value = iSum5;

                //

                if (dataGridView1.RowCount < 3) return;

                string sNo = dataGridView1.Rows[0].Cells[0].Value.ToString();

                for (int i = 1; i < dataGridView1.RowCount - 1; i++)
                {
                    if (sNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "";
                        dataGridView1.Rows[i].Cells[3].Value = "";
                        dataGridView1.Rows[i].Cells[4].Value = "";
                        dataGridView1.Rows[i].Cells[5].Value = "";

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = c;
                    }
                    else
                    {
                        if (c == Color.Beige) c = Color.White;
                        else c = Color.Beige;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = c;
                    }
                    sNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                }
            }
            catch (NullReferenceException)
            {
                return;
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

            string reportFileName = "SmartMES_SinMyung.Reports.P1B07_DELI_REPORT.rdlc";

            string reportParm1 = "출하일자 : ";
            string reportParm2 = "전표번호/거래처/영업담당/현장/품목명 : ";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            reportParm3 = reportParm3 + "";

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPDeliReportQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void P1B07_DELI_REPORT_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}
