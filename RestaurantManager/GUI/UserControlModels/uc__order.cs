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


namespace GUI.UserControlModels
{
    public partial class uc__order : UserControl
    {

        private List<Table> tables;
        private List<TableLocal> locals;

        public uc__order()
        {
            tables = TableDAO.GetAll();
            InitializeComponent();
            this.Load += Uc__order_Load;
        }

        private void Uc__order_Load(object sender, EventArgs e)
        {
            CreateTable();
        }
    }
}
