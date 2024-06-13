using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class User1Window : Form
    {
        public User1Window()
        {
            InitializeComponent();
        }

        private void 售货订单ToolStripMenuItem_Click(object sender, EventArgs e)        //"下订单"
        {
            User2Window BuyWindow = new User2Window();
            BuyWindow.ShowDialog();
        }

        private void 退货ToolStripMenuItem_Click(object sender, EventArgs e)            //"退货"
        {
            User3Window CancellationWindow = new User3Window();
            CancellationWindow.ShowDialog();
        }

        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User4Window InfoWindow = new User4Window();
            InfoWindow.ShowDialog();
        }

        private void c官方文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User1Help1Window window = new User1Help1Window();
            window.ShowDialog();
        }

        private void 监测内存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User1Help2Window window = new User1Help2Window();
            window.ShowDialog();
        }

        private void 问题自检ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User1Help3Window window = new User1Help3Window();
            window.ShowDialog();
        }
    }
}
