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
    public partial class User4Window : Form
    {
        public User4Window()
        {
            InitializeComponent();

            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            panel3.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void User4Window_Load(object sender, EventArgs e)
        {
            string sql = $"select * from t_User where UserID = '{Data.UID}';";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            if (data.Read())
            {
                string id       = data["UserID"].ToString();
                string name     = data["UserName"].ToString();
                string password = data["Password"].ToString();
                label11.Text = $"{id}";
                label8.Text  = $"{name}";
                label12.Text = $"{password}";
            }
            example.Close();

            string sql2 = $"select * from t_Staff where UserID = '{Data.UID}';";
            DBHandle example2 = new DBHandle();
            IDataReader data2 = example2.Read(sql2);
            if (data2.Read())
            {
                string sex       = data2["Sex"].ToString();
                string age       = data2["Age"].ToString();
                string phone     = data2["Phone"].ToString();
                string staffId   = data2["StaffID"].ToString();
                string staffName = data2["StaffName"].ToString();
                label9.Text  = $"{sex}";
                label10.Text = $"{age}";
                label14.Text = $"{phone}";
                label7.Text  = $"{staffId}";
                label16.Text = $"{staffName}";
            }
            example.Close();

            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label18.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #region 按钮按下时触发
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top    = button1.Top;
            panel3.Left   = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Height = button2.Height;
            panel3.Top    = button2.Top;
            panel3.Left   = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            panel3.Top    = button3.Top;
            panel3.Left   = button3.Left;
            button3.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top    = button4.Top;
            panel3.Left   = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);
        }
        #endregion

        #region 按键不再聚焦时（退出时）触发
        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion
    }
}
