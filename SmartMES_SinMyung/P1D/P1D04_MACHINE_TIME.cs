using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1D04_MACHINE_TIME : SmartMES_SinMyung.FormBasic
    {
        public P1D04_MACHINE_TIME()
        {
            InitializeComponent();
        }
        private void P1D04_MACHINE_TIME_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));

            string sql = @"select t.co_code, t.co_item
                            from(
                            select '%' as co_code, '<전체>' as co_item
                            union 
                            select co_code, co_item from tb_gi_common where co_kind = 'Z') as t
                            order by t.co_code";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbGrp.DataSource = table;
                cbGrp.ValueMember = "co_code";
                cbGrp.DisplayMember = "co_item";
            }
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

                string sGrp = cbGrp.SelectedValue.ToString();

                sP_MachineTime_QueryTableAdapter.Fill(dataSetP1D.SP_MachineTime_Query, dtFromDate, dtToDate, sGrp);

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

            dataGridView1[4, rowIndex].Value = rowIndex.ToString() + "기";

            //

            float fSum1 = 0, fSum2 = 0, fSum3 = 0;
            float fTot1 = 0, fTot2 = 0;
            int iDo = 0;
            string sDo = string.Empty;

            for (int i = 0; i < rowIndex; i++)
            {
                fSum1 += float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                fSum2 += float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                fSum3 += float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());

                iDo = (int)Math.Ceiling(float.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()) * 100);
                if (iDo <= 0) sDo = "□□□□□□□□□□";
                else if (iDo >= 100) sDo = "■■■■■■■■■■";
                else
                {
                    iDo = iDo / 10;
                    if (iDo == 1) sDo = "■□□□□□□□□□";
                    else if (iDo == 2) sDo = "■■□□□□□□□□";
                    else if (iDo == 3) sDo = "■■■□□□□□□□";
                    else if (iDo == 4) sDo = "■■■■□□□□□□";
                    else if (iDo == 5) sDo = "■■■■■□□□□□";
                    else if (iDo == 6) sDo = "■■■■■■□□□□";
                    else if (iDo == 7) sDo = "■■■■■■■□□□";
                    else if (iDo == 8) sDo = "■■■■■■■■□□";
                    else if (iDo == 9) sDo = "■■■■■■■■■□";
                }
                dataGridView1.Rows[i].Cells[11].Value = sDo;
            }

            dataGridView1[6, rowIndex].Value = fSum1;
            dataGridView1[7, rowIndex].Value = fSum2;
            dataGridView1[8, rowIndex].Value = fSum3;

            fTot1 = float.Parse(fSum3.ToString()) / float.Parse(fSum1.ToString());
            TimeSpan ts = dtpToDate.Value - dtpFromDate.Value;
            fTot2 = float.Parse(fSum3.ToString()) / ((ts.Days + 1) * 8);

            dataGridView1[9, rowIndex].Value = fTot1;
            dataGridView1[10, rowIndex].Value = fTot2;
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

            string reportFileName = "SmartMES_SinMyung.Reports.P1D04_MACHINE_TIME.rdlc";

            string reportParm1 = "가동기간 : ";
            string reportParm2 = "설비그룹 : ";
            string reportParm3 = "";
            string reportParmH = "";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");
            reportParm2 = reportParm2 + cbGrp.Text;

            TimeSpan ts = dtpToDate.Value - dtpFromDate.Value;
            reportParmH = ((ts.Days + 1) * 8).ToString();

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            ReportParameter rpH = new ReportParameter("ReportParameterH", reportParmH);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rpH });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPMachineTimeQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void P1D04_MACHINE_TIME_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}