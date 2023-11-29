using GUI.ModelsView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm__client : Form
    {
        public frm__client()
        {
            InitializeComponent();
        }

        private void frm__client_Load(object sender, EventArgs e)
        {
            GetUserLogin();

            GetTime();
        }

        private void GetUserLogin()
        {
            var user = UserLogin.Account;
            txt__userlogin.Text = "Hello, " + user.employer__name;
        }

        private void GetTime()
        {
            Timer timerThoiGian = new Timer();
            timerThoiGian.Tick += new EventHandler(OnTick);
            timerThoiGian.Start();
            txt__datetime.Text = DateTime.Now.ToString();
        }

        private void OnTick(object sender, EventArgs e)
        {
            // Lấy thời gian hiện tại theo múi giờ
            DateTime thoiGianHienTai = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);

            // Hiển thị thời gian trên Label
            txt__datetime.Text = thoiGianHienTai.ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void btn__close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình hay không?", "Hệ thống",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
