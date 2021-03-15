using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    public partial class P1FD02_PROD_BOARD : SmartMES_SinMyung.FormBasic
    {
        MySqlConnection con;

        public P1FD02_PROD_BOARD()
        {
            InitializeComponent();
        }
        private void P1FD02_PROD_BOARD_Load(object sender, EventArgs e)
        {
            facilityInit();
            facilityUpdate();
            graphUpdate();
            oasisUpdate();

            timer3.Start();
            timer5.Start();
        }

        #region 각 화면 그리기
        //1.설비가동현황(설비사진, 설비명, 호기)
        private void facilityInit()
        {
            string FileName;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;

            con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            string query;
            MySqlDataReader myData;

            PictureBox pb;
            Label lbName;
            Label lbNo;

            try
            {
                con.Open();
                cmd.Connection = con;

                for (int i = 1; i <= 15; i++)
                {
                    pb = this.Controls.Find("pbF_" + i.ToString(), true).FirstOrDefault() as PictureBox;
                    lbName = this.Controls.Find("lbName" + i.ToString(), true).FirstOrDefault() as Label;
                    lbNo = this.Controls.Find("lbNo" + i.ToString(), true).FirstOrDefault() as Label;
                    pb.Image = null;
                    lbName.Text = "";
                    lbNo.Text = "";

                    query = "SELECT f.machine_id, f.machine_name, f.machine_no, f.machine_image, f.image_size, ifnull(f.ip,'') as ip from tb_machinecard f where f.machine_id = " + i.ToString();
                    cmd.CommandText = query;

                    myData = cmd.ExecuteReader();

                    if (!myData.HasRows)
                    {
                        myData.Close();
                        continue;
                    }

                    myData.Read();
                    lbName.Text = myData.GetString(myData.GetOrdinal("machine_name"));
                    lbName.Tag = myData.GetString(myData.GetOrdinal("machine_id"));
                    lbNo.Text = myData.GetString(myData.GetOrdinal("machine_no"));
                    lbNo.Tag = myData.GetString(myData.GetOrdinal("ip"));

                    FileSize = myData.GetUInt32(myData.GetOrdinal("image_size"));

                    if (FileSize <= 0)
                    {
                        myData.Close();
                        continue;
                    }

                    rawData = new byte[FileSize];
                    myData.GetBytes(myData.GetOrdinal("machine_image"), 0, rawData, 0, (int)FileSize);

                    FileName = @System.IO.Directory.GetCurrentDirectory();
                    FileName = FileName + "\\" + i.ToString() + ".png";

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    FileInfo file = new FileInfo(FileName);
                    file.Delete();

                    fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                    fs.Write(rawData, 0, (int)FileSize);
                    fs.Close();

                    pb.Image = Image.FromFile(FileName);
                    myData.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        //2.설비가동현황(수치 데이터)
        private void facilityUpdate()
        {
            con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            string query;
            MySqlDataReader myData;

            Label lbName;
            string sID;
            Label lbProd, lbFaA, lbFaB, lbFaC, lbFaD, lbPerA, lbPerB;
            Decimal dmOK = 0, dmPlan = 0;

            try
            {
                con.Open();
                cmd.Connection = con;

                for (int i = 1; i <= 15; i++)
                {
                    lbProd = this.Controls.Find("lbProd" + i.ToString(), true).FirstOrDefault() as Label;
                    lbFaA = this.Controls.Find("lbFaA_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbFaB = this.Controls.Find("lbFaB_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbFaC = this.Controls.Find("lbFaC_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbFaD = this.Controls.Find("lbFaD_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbPerA = this.Controls.Find("lbPerA_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbPerB = this.Controls.Find("lbPerB_" + i.ToString(), true).FirstOrDefault() as Label;
                    lbProd.Text = "";
                    lbFaA.Text = "";
                    lbFaB.Text = "";
                    lbFaC.Text = "";
                    lbFaD.Text = "";
                    lbPerA.Text = "";
                    lbPerB.Text = "";

                    lbName = this.Controls.Find("lbName" + i.ToString(), true).FirstOrDefault() as Label;

                    if (lbName.Tag == null) continue;

                    sID = lbName.Tag.ToString();

                    query = "SELECT pr.add_name AS productName" +
                        ", (select o.order_qty from tb_prod_order o where o.job_no = pr.job_no and o.proc_no = pr.proc_no) AS planQty" +
                        ", pr.gd_qty AS prodQty, pr.ng_qty AS ngQty" +
                        ", ROUND(pr.gd_qty / (pr.gd_qty + pr.ng_qty) * 100, 0) AS vieldPer " +
                        "FROM tb_prod_result pr " +
                        "WHERE pr.machine_id = " + sID +
                        " ORDER BY pr.enter_dt DESC LIMIT 1";

                    cmd.CommandText = query;
                    myData = cmd.ExecuteReader();

                    if (!myData.HasRows)
                    {
                        myData.Close();
                        continue;
                    }

                    myData.Read();
                    lbProd.Text = myData.GetString(myData.GetOrdinal("productName"));
                    lbFaA.Text = "계획량 " + myData.GetString(myData.GetOrdinal("planQty"));
                    lbFaB.Text = "생산량 " + myData.GetString(myData.GetOrdinal("prodQty"));
                    lbFaC.Text = "수율 " + myData.GetString(myData.GetOrdinal("vieldPer")) + "%";
                    lbFaD.Text = "불량 " + myData.GetString(myData.GetOrdinal("ngQty"));

                    dmOK = myData.GetDecimal(myData.GetOrdinal("prodQty"));
                    dmPlan = myData.GetDecimal(myData.GetOrdinal("planQty"));

                    if (dmPlan == 0)
                    {
                        lbPerA.Text = "0";
                        lbPerB.Text = ".0%";
                    }
                    else
                    {
                        lbPerA.Text = Math.Round(dmOK / dmPlan * 100, 1).ToString("0.0") + "%";
                        lbPerB.Text = lbPerA.Text.Substring(lbPerA.Text.IndexOf(".", 0), 3);
                        lbPerA.Text = lbPerA.Text.Substring(0, lbPerA.Text.IndexOf(".", 0));
                    }

                    myData.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        //3.설비가동현황(상단 그래프)
        private void graphUpdate()
        {
            try
            {
                con = new MySqlConnection(G.conStr);
                con.Open();

                string sqlStr = "SELECT IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 0, ps.gd_qty, 0)),0) AS time00" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 1, ps.gd_qty, 0)),0) AS time01" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 2, ps.gd_qty, 0)),0) AS time02" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 3, ps.gd_qty, 0)),0) AS time03" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 4, ps.gd_qty, 0)),0) AS time04" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 5, ps.gd_qty, 0)),0) AS time05" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 6, ps.gd_qty, 0)),0) AS time06" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 7, ps.gd_qty, 0)),0) AS time07" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 8, ps.gd_qty, 0)),0) AS time08" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 9, ps.gd_qty, 0)),0) AS time09" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 10, ps.gd_qty, 0)),0) AS time10" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 11, ps.gd_qty, 0)),0) AS time11" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 12, ps.gd_qty, 0)),0) AS time12" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 13, ps.gd_qty, 0)),0) AS time13" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 14, ps.gd_qty, 0)),0) AS time14" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 15, ps.gd_qty, 0)),0) AS time15" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 16, ps.gd_qty, 0)),0) AS time16" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 17, ps.gd_qty, 0)),0) AS time17" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 18, ps.gd_qty, 0)),0) AS time18" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 19, ps.gd_qty, 0)),0) AS time19" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 20, ps.gd_qty, 0)),0) AS time20" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 21, ps.gd_qty, 0)),0) AS time21" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 22, ps.gd_qty, 0)),0) AS time22" +
                                    ", IFNULL(SUM(IF(HOUR(ps.jobtime_finish) = 23, ps.gd_qty, 0)),0) AS time23" +
                                    ", IFNULL((select SUM(r.gd_qty + r.ng_qty) from tb_prod_result r where ps.jobtime_finish is not null and r.prod_date = CURDATE()),0) AS planQty_d" +
                                    ", IFNULL((select SUM(r.gd_qty) from tb_prod_result r where ps.jobtime_finish is not null and r.prod_date = CURDATE()),0) AS prodQty_d" +
                                    ", IFNULL((select SUM(r.gd_qty + r.ng_qty) from tb_prod_result r where ps.jobtime_finish is not null and r.prod_date between DATE_ADD(CURDATE(),INTERVAL 1-DAY(CURDATE()) DAY) AND LAST_DAY(CURDATE())),0) AS planQty_m" +
                                    ", IFNULL((select SUM(r.gd_qty) from tb_prod_result r where ps.jobtime_finish is not null and r.prod_date between DATE_ADD(CURDATE(),INTERVAL 1-DAY(CURDATE()) DAY) AND LAST_DAY(CURDATE())),0) AS prodQty_m " +

                                    "FROM tb_prod_result ps " +
                            "WHERE ps.jobtime_finish IS NOT NULL AND DATE(ps.jobtime_finish)=CURDATE()";

                MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                MySqlDataReader myData = cmd.ExecuteReader();

                if (myData.Read())
                {
                    string sCheckItem = "가동률";
                    chartA3.Series[sCheckItem].Points.Clear();

                    for (int i = 0; i <= 23; i++)
                    {
                        chartA3.Series[sCheckItem].Points.AddXY(i.ToString(), myData.GetInt32(myData.GetOrdinal("time" + i.ToString("00"))));
                    }

                    decimal dmPlanQty_d, dmProdQty_d, dmPlanQty_m, dmProdQty_m;

                    dmPlanQty_d = myData.GetDecimal(myData.GetOrdinal("planQty_d"));
                    dmProdQty_d = myData.GetDecimal(myData.GetOrdinal("prodQty_d"));

                    if (dmPlanQty_d == 0)
                    {
                        lbResultDayA.Text = "0";
                        lbResultDayB.Text = ".0%";
                    }
                    else
                    {
                        lbResultDayA.Text = Math.Round(dmProdQty_d / dmPlanQty_d * 100, 1).ToString("0.0") + "%";
                        lbResultDayB.Text = lbResultDayA.Text.Substring(lbResultDayA.Text.IndexOf(".", 0), 3);
                        lbResultDayA.Text = lbResultDayA.Text.Substring(0, lbResultDayA.Text.IndexOf(".", 0));
                    }

                    dmPlanQty_m = myData.GetDecimal(myData.GetOrdinal("planQty_m"));
                    dmProdQty_m = myData.GetDecimal(myData.GetOrdinal("prodQty_m"));

                    if (dmPlanQty_m == 0)
                    {
                        lbResultMonthA.Text = "0";
                        lbResultMonthB.Text = ".0%";
                    }
                    else
                    {
                        lbResultMonthA.Text = Math.Round(dmProdQty_m / dmPlanQty_m * 100, 1).ToString("0.0") + "%";
                        lbResultMonthB.Text = lbResultMonthA.Text.Substring(lbResultMonthA.Text.IndexOf(".", 0), 3);
                        lbResultMonthA.Text = lbResultMonthA.Text.Substring(0, lbResultMonthA.Text.IndexOf(".", 0));
                    }


                    chartA1.Series["일간실적"].Points.Clear();
                    chartA1.Series["일간실적"].Points.AddXY(1, 100 - Decimal.Parse(lbResultDayA.Text + lbResultDayB.Text.Replace("%", "")));
                    chartA1.Series["일간실적"].Points.AddXY(1, Decimal.Parse(lbResultDayA.Text + lbResultDayB.Text.Replace("%", "")));
                    chartA1.Series["일간실적"].Points[0].Color = Color.LightGray;
                    chartA1.Series["일간실적"].Points[1].Color = Color.Fuchsia;

                    chartA2.Series["월간실적"].Points.Clear();
                    chartA2.Series["월간실적"].Points.AddXY(1, 100 - Decimal.Parse(lbResultMonthA.Text + lbResultMonthB.Text.Replace("%", "")));
                    chartA2.Series["월간실적"].Points.AddXY(1, Decimal.Parse(lbResultMonthA.Text + lbResultMonthB.Text.Replace("%", "")));
                    chartA2.Series["월간실적"].Points[0].Color = Color.LightGray;
                    chartA2.Series["월간실적"].Points[1].Color = Color.Yellow;
                }

                myData.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        //4.설비가동현황(오아시스)
        private void oasisUpdate()
        {
            PictureBox pb;
            Label codeName;
            int iValueC = 0, iValueD = 0, iValueE = 0, iValueF = 0;
            string sqlStr;
            MySqlCommand cmd;
            MySqlDataReader myData;


            for (int i = 1; i <= 15; i++)
            {
                codeName = this.Controls.Find("lbName" + i.ToString(), true).FirstOrDefault() as Label;
                pb = this.Controls.Find("btn_" + i.ToString(), true).FirstOrDefault() as PictureBox;
                pb.Image = null;

                if (string.IsNullOrEmpty(codeName.Text)) continue;

                try
                {
                    con = new MySqlConnection(G.conStr);
                    con.Open();

                    sqlStr = "SELECT PoC, PoD, PoE, PoF " +
                            "FROM tb_oasis " +
                            "WHERE machine_id = " + codeName.Tag.ToString() +
                            " ORDER BY start_dt DESC LIMIT 1";

                    cmd = new MySqlCommand(sqlStr, con);
                    myData = cmd.ExecuteReader();

                    if (myData.Read())
                    {
                        iValueC = myData.GetInt32(myData.GetOrdinal("PoC")); //RUN
                        iValueD = myData.GetInt32(myData.GetOrdinal("PoD")); //STOP(StandBy)
                        iValueE = myData.GetInt32(myData.GetOrdinal("PoE")); //ALARM
                        iValueF = myData.GetInt32(myData.GetOrdinal("PoF")); //Finish(진행작업 끝)

                        if (iValueC == 1) //OPERATE
                        {
                            pb.Image = Properties.Resources.button가동;
                            pb.Tag = "가동";
                        }
                        else if (iValueD == 1) //STOP(StandBy)
                        {
                            pb.Image = Properties.Resources.button대기;
                            pb.Tag = "대기";
                        }
                        else if (iValueE == 1) //ALARM
                        {
                            pb.Image = Properties.Resources.button알람;
                            pb.Tag = "알람";
                        }                        
                        else if (iValueF == 1) //FINISH
                        {
                            pb.Image = Properties.Resources.button중지;
                            pb.Tag = "중지";
                        }
                        else
                        {
                            pb.Image = Properties.Resources.button종료;
                            pb.Tag = "종료";
                        }
                    }

                    myData.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            //
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
            //
        }
        #endregion

        #region 타이머 Event
        //알람 아이콘 깜박임 타이머
        private void timer3_Tick(object sender, EventArgs e)
        {
            PictureBox pb;

            for (int i = 1; i <= 15; i++)
            {
                pb = this.Controls.Find("btn_" + i.ToString(), true).FirstOrDefault() as PictureBox;

                if (pb.Tag.ToString() == "알람")
                {
                    if (pb.Visible) pb.Visible = false;
                    else pb.Visible = true;
                }
            }
        }
        //현황판 업데이트 타이머
        private void timer5_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            facilityUpdate();
            graphUpdate();
            oasisUpdate();
                
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
