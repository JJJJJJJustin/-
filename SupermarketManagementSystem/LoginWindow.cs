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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //登录按键触发事件
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
        }

        public void Login()
        {
            if(radioButtonUser.Checked == true)                                     //员工权限
            {
                string sql = $"select * from t_User where UserID = '{textBox1.Text}' and Password = '{textBox2.Text}';";
                DBHandle example = new DBHandle();
                IDataReader data = example.Read(sql);                               //根据sql语句从库中读取数据（读出符合条件的那一行：我们设置了主键，故只有一行完全匹配）
                if (data.Read())
                {
                    Data.UID = data["UserID"].ToString();                           //从data（DBConnect读出的IDataReader类）的数据给 Data类中的成员变量读入数据
                    Data.UName = data["UserName"].ToString();                       //这里的 data 好像是一种存储键值对的容器

                    MessageBox.Show("登录成功");
                    
                    User1Window user = new User1Window();
                    this.Hide();                                                    //隐藏 LoginWindow
                    user.ShowDialog();                                              //.Show() 成员函数是所有图层的界面界面操作。 而 .ShowDialog()对话框时对当前最顶层的图层进行操作。
                    this.Show();
                }else
                {
                    MessageBox.Show("登录失败");
                }
                data.Close();                                                       //关闭
            }
            if(radioButtonAdmin.Checked == true)                                    //管理员权限
            {
                string sql = $"select * from t_Admin where UserID = '{textBox1.Text}' and Password = '{textBox2.Text}';";
                DBHandle example = new DBHandle();
                IDataReader data = example.Read(sql);                               //根据条件从库中读取数据
                if (data.Read())
                {
                    Data.UID = data["UserID"].ToString();                           //从data（DBConnect读出的IDataReader类）的数据给 Data类中的成员变量读入数据
                    
                    MessageBox.Show("登录成功");
                    Admin1Window admin = new Admin1Window();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                data.Close();                                                       //关闭
            }
        }

        private void 设计流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginHelp1Window HelpWindow = new LoginHelp1Window();
            HelpWindow.ShowDialog();
        }

        private void 支持ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginHelp2Window HelpWindow2 = new LoginHelp2Window();
            HelpWindow2.ShowDialog();
        }

        private void 小游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LittleGame gameWindow = new LittleGame();
            gameWindow.ShowDialog();
        }

        private void c窗体资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginHelp3_1Window window = new LoginHelp3_1Window();
            window.ShowDialog();
        }

        private void c窗体简单用例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginHelp3_2Window window = new LoginHelp3_2Window();
            window.ShowDialog();
        }

        private void c控件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginHelp3_3Window window = new LoginHelp3_3Window();
            window.ShowDialog();
        }
    }
}
