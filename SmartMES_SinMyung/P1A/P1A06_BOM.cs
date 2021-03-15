using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1A06_BOM : SmartMES_SinMyung.FormBasic
    {
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int dragTag;

        public P1A06_BOM()
        {
            InitializeComponent();
        }
        private void P1A06_BOM_Load(object sender, EventArgs e)
        {
            ListSearch1();
            this.ActiveControl = tbSearch1;
        }
        public void ListSearch1()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lblMsg.Text = "";
                string sSearch = tbSearch1.Text.Trim();
                sP_BOM_QueryTableAdapter.Fill(dataSetP1A.SP_BOM_Query, sSearch);

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
        public void ListSearch2(string sProd)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lblMsg.Text = "";
                sP_BOM_SelectTableAdapter.Fill(dataSetP1A.SP_BOM_Select, sProd);

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
        public void ListSearch3(string sProd)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lblMsg.Text = "";
                string sSearch = tbSearch3.Text.Trim();
                sP_BOM_ListTableAdapter.Fill(dataSetP1A.SP_BOM_List, sSearch, sProd);

                dataGridView3.CurrentCell = null;
                dataGridView3.ClearSelection();
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
        private void tbSearch1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch1();
                ListSearch2("-");
                tbSearch3.Text = "";
                ListSearch3("-");
            }
        }
        private void tbSearch3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = dataGridView1.CurrentRow.Index;
                if (index < 0) return;

                string sProd = dataGridView1.Rows[index].Cells[1].Value.ToString();
                ListSearch3(sProd);
            }
        }
        #endregion

        #region GridView Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string sProd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            ListSearch2(sProd);
            tbSearch3.Text = "";
            ListSearch3(sProd);
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 6) return;
            if (e.Value.ToString() == "0") e.Value = null;
        }
        //
        private void dataGridView3_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 2) return;

            if (dataGridView1.CurrentCell == null ||
                    dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string sPCode = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string sMCode = (string)e.Data.GetData(DataFormats.StringFormat);

                string sql = "delete from tb_gi_bom where " +
                    "prod_id = '" + sPCode + "' and material_id = '" + sMCode + "'";

                string msg = string.Empty;
                MariaCRUD m = new MariaCRUD();
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                ListSearch2(sPCode);
                ListSearch3(sPCode);
            }
        }
        private void dataGridView3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void dataGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView3.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void dataGridView3_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    dragTag = 3;
                    string sCode = dataGridView3.Rows[rowIndexFromMouseDown].Cells[1].Value.ToString();

                    DragDropEffects dropEffect = dataGridView3.DoDragDrop(sCode, DragDropEffects.Copy);
                }
            }
        }
        //
        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 3) return;

            if (dataGridView1.CurrentCell == null ||
                    dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string sPCode = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string sMCode = (string)e.Data.GetData(DataFormats.StringFormat);

                string sql = "insert into tb_gi_bom (prod_id, material_id, config_qty) " +
                    "values('" + sPCode + "', '" + sMCode + "', 1)";

                string msg = string.Empty;
                MariaCRUD m = new MariaCRUD();
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                ListSearch2(sPCode);
                ListSearch3(sPCode);
            }
        }
        private void dataGridView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView2.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    dragTag = 2;
                    string sCode = dataGridView2.Rows[rowIndexFromMouseDown].Cells[2].Value.ToString();

                    DragDropEffects dropEffect = dataGridView2.DoDragDrop(sCode, DragDropEffects.Copy);
                }
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch1();
            ListSearch2("-");
            tbSearch3.Text = "";
            ListSearch3("-");
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
            lblMsg.Text = "";
            if (G.Authority == "D") return;

            if (dataGridView2.Rows.Count < 1)
            {
                lblMsg.Text = "구성품 리스트가 존재하지 않습니다.";
                return;
            }

            dataGridView2.CurrentCell = dataGridView2[0, 0];

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sProdID = string.Empty;
            string sMaterialID = string.Empty;
            string sQty = string.Empty;

            int iCnt = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                sProdID = dataGridView2.Rows[i].Cells[1].Value.ToString();
                sMaterialID = dataGridView2.Rows[i].Cells[2].Value.ToString();
                sQty = dataGridView2.Rows[i].Cells[6].Value.ToString();

                if (string.IsNullOrEmpty(sQty)) sQty = "0";

                sql = "update tb_gi_bom set config_qty = " + sQty +
                    " where prod_id = '" + sProdID + "' and material_id = '" + sMaterialID + "'";

                m.dbCUD(sql, ref msg);
                iCnt++;
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sProdID + " " + iCnt.ToString() + "건");
            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }

        #endregion
    }
}
