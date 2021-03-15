using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C09_PROD_NG : SmartMES_SinMyung.FormBasic
    {
        public P1C09_PROD_NG()
        {
            InitializeComponent();
        }
        private void P1C09_PROD_NG_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));

            string sql = @"select t.co_code, t.co_item
                            from(
                            select '%' as co_code, '<전체>' as co_item
                            union 
                            select co_code, co_item from tb_gi_common where co_kind = 'L') as t
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

                sP_ProdNg_QueryTableAdapter.Fill(dataSetP1C.SP_ProdNg_Query, dtFromDate, dtToDate, sItem, sGrp);

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

            dataGridView1[5, rowIndex].Value = rowIndex.ToString() + "건";

            //

            long iSum1 = 0, iSum2 = 0, iSum3 = 0;
            float fTot1 = 0;

            for (int i = 0; i < rowIndex; i++)
            {
                iSum1 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                iSum2 += long.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                iSum3 += long.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
            }

            dataGridView1[8, rowIndex].Value = iSum1;
            dataGridView1[9, rowIndex].Value = iSum2;
            dataGridView1[10, rowIndex].Value = iSum3;

            fTot1 = float.Parse(iSum3.ToString()) / float.Parse(iSum1.ToString());
            dataGridView1[11, rowIndex].Value = fTot1;
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

            string reportFileName = "SmartMES_SinMyung.Reports.P1C09_PROD_NG.rdlc";

            string reportParm1 = "생산기간 : ";
            string reportParm2 = "불량항목 : ";
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

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdNgQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void P1C09_PROD_NG_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}