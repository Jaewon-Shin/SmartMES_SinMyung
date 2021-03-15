using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C07_PROD_MACHINE : SmartMES_SinMyung.FormBasic
    {
        public P1C07_PROD_MACHINE()
        {
            InitializeComponent();
        }
        private void P1C07_PROD_MACHINE_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            ListSearch();
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

                sP_ProdMachine_QueryTableAdapter.Fill(dataSetP1C.SP_ProdMachine_Query, dtFromDate, dtToDate);

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

            long iSum1 = 0, iSum2 = 0, iSum3 = 0;
            float fSum1 = 0, fSum2 = 0, fSum3 = 0;
            float fTot1 = 0, fTot2 = 0;

            for (int i = 0; i < rowIndex; i++)
            {
                iSum1 += long.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                iSum2 += long.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                iSum3 += long.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                fSum1 += float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                fSum2 += float.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                fSum3 += float.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
            }

            dataGridView1[5, rowIndex].Value = iSum1;
            dataGridView1[6, rowIndex].Value = iSum2;
            dataGridView1[7, rowIndex].Value = iSum3;
            dataGridView1[9, rowIndex].Value = fSum1;
            dataGridView1[10, rowIndex].Value = fSum2;
            dataGridView1[11, rowIndex].Value = fSum3;

            fTot1 = float.Parse(iSum2.ToString()) / float.Parse(iSum3.ToString());
            fTot2 = fSum3 / fSum1;
            dataGridView1[8, rowIndex].Value = fTot1;
            dataGridView1[12, rowIndex].Value = fTot2;
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

            string reportFileName = "SmartMES_SinMyung.Reports.P1C07_PROD_MACHINE.rdlc";

            string reportParm1 = "생산기간 : ";
            string reportParm2 = "";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdMachineQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

    }
}
