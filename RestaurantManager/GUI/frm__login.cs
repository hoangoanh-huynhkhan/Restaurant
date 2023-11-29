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
using GUI.ModelsView;

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

        private Employer GetLogin()
        {
            Employer acc = employers.FirstOrDefault(x => x.employer__id == txt__username.Text);
            if(acc == null)
            {
                throw new Exception("Not foud account!");
            }
            else
            {
                if(acc.password == txt__password.Text)
                {
                    return acc;
                }
                else
                {
                    throw new Exception("Not foud account!");
                }
            }
        }

        private void btn__login_Click(object sender, EventArgs e)
        {
            try
            {
                Employer acc = GetLogin();
                if (acc != null)
                {
                    UserLogin.Account = acc;

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
