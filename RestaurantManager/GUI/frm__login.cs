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
        private bool click = false;
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
                    this.Hide();
                    switch (acc.role)
                    {
                        case 1:
                            frm__admin admin = new frm__admin();
                            admin.ShowDialog();
                            break;
                        case 0:
                            frm__client client = new frm__client();
                            client.ShowDialog();
                            break;
                        default:
                            throw new Exception("Cann't often!");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt__password_TextChanged(object sender, EventArgs e)
        {
            if (txt__password.Text.Trim().Length > 0)
            {
                pic__showpassword.Visible = true;
            }

            if (txt__password.Text.Trim().Length == 0)
            {
                pic__showpassword.Visible = false;
            }
        }

        private void pic__showpassword_Click(object sender, EventArgs e)
        {
            if (!click)
            {
                txt__password.PasswordChar = '\0';
                pic__showpassword.Image = null;
                pic__showpassword.Image = global::GUI.Properties.Resources.show;
                click = true;
            }
            else
            {
                txt__password.PasswordChar = '*';
                pic__showpassword.Image = null;
                pic__showpassword.Image = global::GUI.Properties.Resources.hide;
                click = false;

            }
        }
    }
}
