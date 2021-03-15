using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1C02_PROD_RESULT_ORDER : Form
    {
        public P1C02_PROD_RESULT parentWin;
        public DateTime dtDate;
        public string sPart;
        public string sGroup;

        public P1C02_PROD_RESULT_ORDER()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_ORDER_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = dataGridView1;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ProdResult_OrderTableAdapter.Fill(dataSetP1C.SP_ProdResult_Order, dtDate, sPart, sGroup);

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            Label lblMsg = parentWin.Controls.Find("lblMsg" + sGroup, true).FirstOrDefault() as Label;
            TextBox tbJobNo = parentWin.Controls.Find("tbJobNo" + sGroup, true).FirstOrDefault() as TextBox;
            Button btnStart = parentWin.Controls.Find("btnStart" + sGroup, true).FirstOrDefault() as Button;
            Button btnFinish = parentWin.Controls.Find("btnFinish" + sGroup, true).FirstOrDefault() as Button;
            ComboBox cbFacility = parentWin.Controls.Find("cbFacility" + sGroup, true).FirstOrDefault() as ComboBox;
            TextBox tbProd = parentWin.Controls.Find("tbProd" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbName = parentWin.Controls.Find("tbName" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbSize = parentWin.Controls.Find("tbSize" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbGdQty = parentWin.Controls.Find("tbGdQty" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbNgQty = parentWin.Controls.Find("tbNgQty" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbSumQty = parentWin.Controls.Find("tbSumQty" + sGroup, true).FirstOrDefault() as TextBox;
            DataGridView dataGridView = parentWin.Controls.Find("dataGridView" + sGroup, true).FirstOrDefault() as DataGridView;
            TextBox tbJobTime = parentWin.Controls.Find("tbJobTime" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbIdleTime = parentWin.Controls.Find("tbIdleTime" + sGroup, true).FirstOrDefault() as TextBox;
            TextBox tbRealDriveTime = parentWin.Controls.Find("tbRealDriveTime" + sGroup, true).FirstOrDefault() as TextBox;
            Label lblProc = parentWin.Controls.Find("lblProc" + sGroup, true).FirstOrDefault() as Label;
            //

            tbJobNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbFacility.Enabled = true;
            tbProd.Tag = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbProd.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbSize.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            tbGdQty.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            tbNgQty.Text = "0";
            tbSumQty.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            lblProc.Tag = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            parentWin.timer1.Stop();
            parentWin.timer2.Stop();
            btnStart.Tag = null;
            btnFinish.Tag = null;
            tbJobTime.Text = "00 : 00 : 00";
            tbIdleTime.Text = "00 : 00 : 00";
            tbRealDriveTime.Text = "00 : 00 : 00";

            if (sGroup == "A") parentWin.sP_ProdResult_IdleATableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_IdleA, "-", 0, 0);
            else if (sGroup == "B") parentWin.sP_ProdResult_IdleBTableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_IdleB, "-", 0, 0);
            else if (sGroup == "C") parentWin.sP_ProdResult_IdleCTableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_IdleC, "-", 0, 0);
            else if (sGroup == "D") parentWin.sP_ProdResult_IdleDTableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_IdleD, "-", 0, 0);
            else if (sGroup == "E") parentWin.sP_ProdResult_IdleETableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_IdleE, "-", 0, 0);

            dataGridView.CurrentCell = null;
            dataGridView.ClearSelection();
            lblMsg.Text = "작업시작 할 수 있습니다.";

            this.Dispose();
        }
    }
}
