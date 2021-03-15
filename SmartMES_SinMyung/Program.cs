using System;
using System.Windows.Forms;

namespace SmartMES_SinMyung
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            G.UserID = "admin";
            G.Pos = "A";
            G.ComName = "(주)신명금속";
            G.PosName = "신명";
            G.UserName = "신재원";
            G.Authority = "A";
            Application.Run(new MDIForm());

            //using (var form = new FormLogin())
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //        Application.Run(new MDIForm());
            //}
        }
    }
}
