using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class Admin4_1Window : Form
    {
        private int m_ExecutedSQL = 0;
        private int m_Id;
        private Admin4_1_1Window m_IdWindow;
        private Admin4_1_2Window m_NameWindow;
        private bool m_WindowOpen;

        public Admin4_1Window()
        {
            InitializeComponent();
        }
        public Admin4_1Window(string id)
        {
            InitializeComponent();

            m_Id = int.Parse(id);
            if (m_Id < 11111) { m_Id += 1; }
        }
        private void Admin4_1Window_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"{m_Id.ToString("D5")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "") {
                string sql = $"insert into t_Stock values ('{textBox1.Text}', '{textBox2.Text}', {textBox4.Text}, '{textBox5.Text}', {textBox3.Text});";
                DBHandle example = new DBHandle();
                try {
                    example.Execute(sql);                               //执行SQL语句的函数，如果执行成功返回受影响行数
                    MessageBox.Show("添加成功！ :-}");

                    m_Id += 1;
                    m_ExecutedSQL++;
                    label5.Text = $"已成功添加{m_ExecutedSQL}个";
                }
                catch (SqlException ex)
                {
                    StackFrame frame = new StackFrame(1);

                    MessageBox.Show($"添加失败！\n" +
                        $"错误位置->文件：{frame.GetFileName()}, 位于{frame.GetFileLineNumber()}行， 方法：{frame.GetMethod().Name}\n" +
                        $"错误信息：{ex.Message}， 错误代码：{sql} \n" + 
                        "请尝试更改后重新填入 :-)");
                }
            }
            //else { MessageBox.Show("该编号不在可用范围中（00000~11111）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                MessageBox.Show("商品信息不能为空！");
            }
            textBox1.Text = $"{m_Id.ToString("D5")}";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (m_WindowOpen)
            {
                // 如果已有子窗口存在，则关闭它
                if (m_IdWindow != null && !m_IdWindow.IsDisposed)
                {
                    m_IdWindow.Close();
                    m_IdWindow.Dispose(); // 释放资源
                }

                // 创建新的子窗口并显示
                m_IdWindow = new Admin4_1_1Window(textBox1.Text);
                m_IdWindow.Show();
                textBox1.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (m_WindowOpen)
            {
                // 如果已有子窗口存在，则关闭它
                if (m_NameWindow != null && !m_NameWindow.IsDisposed)
                {
                m_NameWindow.Close();
                m_NameWindow.Dispose(); // 释放资源
                }

                // 创建新的子窗口并显示
                m_NameWindow = new Admin4_1_2Window(textBox2.Text);
                m_NameWindow.Show();
                textBox2.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                m_WindowOpen = true;
            else
            {
                m_WindowOpen = false;
                // 如果已有ID子窗口存在，则关闭它
                if (m_IdWindow != null && !m_IdWindow.IsDisposed)
                {
                    m_IdWindow.Close();
                    m_IdWindow.Dispose(); // 释放资源
                    m_IdWindow = null; // 避免引用无效对象
                }
                // 如果已有Name子窗口存在，则关闭它
                if (m_NameWindow != null && !m_NameWindow.IsDisposed)
                {
                    m_NameWindow.Close();
                    m_NameWindow.Dispose(); // 释放资源
                    m_NameWindow = null; // 避免引用无效对象
                }
            }
        }
    }
}
