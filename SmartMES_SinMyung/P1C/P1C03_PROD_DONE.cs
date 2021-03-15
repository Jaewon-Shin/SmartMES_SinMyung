using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C03_PROD_DONE : SmartMES_SinMyung.FormBasic
    {
        public P1C03_PROD_DONE()
        {
            InitializeComponent();
        }
        private void P1C03_PROD_DONE_Load(object sender, EventArgs e)
        {
            cbPart.SelectedIndex = 0;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtDate = DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd"));
                string sPart = cbPart.Text.Substring(0, 1);

                sP_ProdDone_QueryTableAdapter.Fill(dataSetP1C.SP_ProdDone_Query, dtDate, sPart);

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
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion        

        #region GridView Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (dataGridView1.RowCount <= 1) return;
            if (e.ColumnIndex != 0) return;

            string sJobNo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string sFacID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string sFacName = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string sProcNo = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();

            if (string.IsNullOrEmpty(sFacID)) return;

            DialogResult dr = MessageBox.Show("JobNo.: " + sJobNo + "\r설비명 : " + sFacName + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;


            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_prod_result where job_no = '" + sJobNo + "' and proc_no = " + sProcNo + " and machine_id = " + sFacID;
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            sql = "update tb_prod_order set prod_flag = 0 where job_no = '" + sJobNo + "' and proc_no = " + sProcNo;
            m.dbCUD(sql, ref msg);

            string finalFlag = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
            string sujuNo = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
            string sujuSeq = dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString();

            if (finalFlag == "1")
            {
                sql = "update tb_rorder_sub set prod_flag = 0 where rorder_id = '" + sujuNo + "' and rorder_seq = " + sujuSeq;
                m.dbCUD(sql, ref msg);
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sJobNo + " " + sFacID + "-" + sFacName);

            ListSearch();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 27) return;
            if (dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible) == e.RowIndex) return;

            
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentCell.Selected = true;

            P1C03_PROD_DONE_SUB sub = new P1C03_PROD_DONE_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1[2, rowIndex].Value = rowIndex.ToString() + "건";

            //

            long iSum1 = 0, iSum2 = 0, iSum3 = 0;
            float fSum1 = 0, fSum2 = 0, fSum3 = 0;

            for (int i = 0; i < rowIndex; i++)
            {
                iSum1 += long.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                iSum2 += long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                iSum3 += long.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());

                fSum1 += float.Parse(dataGridView1.Rows[i].Cells[19].Value.ToString());
                fSum2 += float.Parse(dataGridView1.Rows[i].Cells[20].Value.ToString());
                fSum3 += float.Parse(dataGridView1.Rows[i].Cells[21].Value.ToString());
            }

            dataGridView1[12, rowIndex].Value = iSum1;
            dataGridView1[13, rowIndex].Value = iSum2;
            dataGridView1[14, rowIndex].Value = iSum3;

            dataGridView1[19, rowIndex].Value = fSum1;
            dataGridView1[20, rowIndex].Value = fSum2;
            dataGridView1[21, rowIndex].Value = fSum3;
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

            string reportFileName = "SmartMES_SinMyung.Reports.P1C03_PROD_DONE.rdlc";

            string reportParm1 = "생산일자 : ";
            //string reportParm2 = "작 업 조 : ";
            string reportParm2 = "";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpDate.Value.ToString("yyyy-MM-dd");
            //reportParm2 = reportParm2 + cbPart.Text;

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdDoneQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }

        #endregion

        private void P1C03_PROD_DONE_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}
