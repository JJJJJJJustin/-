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
    public partial class Admin4_3Window : Form
    {
        private int m_Executed;
        private string m_Id;

        public Admin4_3Window()
        {
            InitializeComponent();
        }
        public Admin4_3Window(string id, string stock)
        {
            InitializeComponent();
            m_Id = id;
            textBox1.Text = stock;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_Stock set Stock = '{textBox1.Text}' where ID = '{m_Id}'";
            DBHandle example = new DBHandle();
            if (example.Execute(sql) != 0)
            {
                MessageBox.Show("修改成功！");
                m_Executed++;
                label2.Text = $"已成功添加{m_Executed}个";
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            example.Close();
        }
    }
}
