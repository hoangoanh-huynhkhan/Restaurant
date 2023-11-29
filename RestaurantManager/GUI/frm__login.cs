using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;
using DAO;

namespace GUI
{
    public partial class frm__login : Form
    {
        private List<Employer> employers;
        public frm__login()
        {
            InitializeComponent();
            this.Load += Frm__login_Load;
        }

        private void Frm__login_Load(object sender, EventArgs e)
        {
            employers = EmployerDAO.GetAll();
        }

        private void btn__close_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình hay không?", "Hệ thống",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
