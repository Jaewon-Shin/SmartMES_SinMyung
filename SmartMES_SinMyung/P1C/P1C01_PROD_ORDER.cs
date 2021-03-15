using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C01_PROD_ORDER : SmartMES_SinMyung.FormBasic
    {
        public P1C01_PROD_ORDER()
        {
            InitializeComponent();
        }
        private void P1C01_PROD_ORDER_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sFrom = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string sTo = dtpToDate.Value.ToString("yyyy-MM-dd");
                string sSearch = tbSearch.Text.Trim();

                sP_ProdOrder_QueryTableAdapter.Fill(dataSetP1C.SP_ProdOrder_Query, G.Pos, DateTime.Parse(sFrom), DateTime.Parse(sTo), sSearch);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
                LotSearch("-");
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
        public void LotSearch(string lotno)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ProdOrder_ProcTableAdapter.Fill(dataSetP1C.SP_ProdOrder_Proc, lotno);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
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
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        #endregion

        #region GridView Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (e.RowIndex < 0) return;

            int index = dataGridView1.CurrentRow.Index;
            string lotno = dataGridView1.Rows[index].Cells[1].Value.ToString();

            LotSearch(lotno);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lblMsg.Text = "";
            //if (G.Authority == "D") return;
            //if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 1) return;

            //P1C01_PROD_ORDER_SUB sub = new P1C01_PROD_ORDER_SUB();
            //sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            //sub.parentWin = this;
            //sub.Width = 412;
            //sub.ShowDialog();
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            P1C01_PROD_ORDER_SUB sub = new P1C01_PROD_ORDER_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (dataGridView1.RowCount == 0) return;

            int index = 0;
            string sLotNo = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sLotNo = dataGridView1.Rows[index].Cells[1].Value.ToString();

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

            DialogResult dr = MessageBox.Show("LotNo. : " + sLotNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;


            string sql = @"select count(job_no) from tb_prod_result where job_no = '" + sLotNo + "'";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            string com = m.dbRonlyOne(sql, ref msg).ToString();

            if (msg == "OK" && Int32.Parse(com) > 0)
            {
                MessageBox.Show("실적처리된 Lot번호는 삭제할 수 없습니다.");
                return;
            }

            sql = "delete from tb_prod_order where job_no = '" + sLotNo + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sLotNo);

            ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (dataGridView2.RowCount == 0) return;

            try
            {
                dataGridView2.CurrentCell = dataGridView2[1, 0];
            }
            catch (InvalidOperationException)
            {
                return;
            }

            int iCnt1 = 0, iCnt2 = 0;
            DateTime result;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells[5].Value == null ||
                    string.IsNullOrEmpty(dataGridView2.Rows[i].Cells[5].Value.ToString()) ||
                    !DateTime.TryParse(dataGridView2.Rows[i].Cells[5].Value.ToString(), out result)) iCnt1++;

                if (dataGridView2.Rows[i].Cells[7].Value == null ||
                    string.IsNullOrEmpty(dataGridView2.Rows[i].Cells[7].Value.ToString())) iCnt2++;
            }

            if (iCnt1 > 0)
            {
                lblMsg.Text = "생산일자를 확인해 주세요.";
                return;
            }
            if (iCnt2 > 0)
            {
                lblMsg.Text = "지시수량을 확인해 주세요.";
                return;
            }

            //

            string sLogNo = dataGridView2.Rows[0].Cells[0].Value.ToString();
            string sProcNo = string.Empty;
            string sDate = string.Empty;
            string sJobPart = string.Empty;
            string sOrderQty = string.Empty;
            string sMent = string.Empty;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                sProcNo = dataGridView2.Rows[i].Cells[1].Value.ToString();
                sDate = DateTime.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString().Trim()).ToString("yyyy-MM-dd");
                sJobPart = dataGridView2.Rows[i].Cells[6].Value.ToString().Substring(0, 1);
                sOrderQty = dataGridView2.Rows[i].Cells[7].Value.ToString().Trim();
                sMent = dataGridView2.Rows[i].Cells[8].Value.ToString().Trim();

                sql = "update tb_prod_order set rorder_date = '" + sDate + "', job_part = '" + sJobPart + "', order_qty = " + sOrderQty + ", ment = '" + sMent +
                    "' where job_no = '" + sLogNo + "' and proc_no = " + sProcNo;

                m.dbCUD(sql, ref msg);
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sLogNo);
            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            sP_ProdOrder_PrintTableAdapter.Fill(dataSetP1C.SP_ProdOrder_Print, DateTime.Parse(sDate));


            string reportFileName = "SmartMES_SinMyung.Reports.P1C01_PROD_ORDER.rdlc";

            string reportParm1 = "생산일자 : ";
            string reportParm2 = "";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpDate.Value.ToString("yyyy-MM-dd");


            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdOrderPrintBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}

