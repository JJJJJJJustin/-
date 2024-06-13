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
    public partial class User2Window : Form
    {
        private int m_OrderNum = 0;
        public string m_OrderID = $"{ DateTime.Now.ToString("yyyyMMddHHmm") }";           //将日期和时分数字字符串作为订单编号


        public User2Window()
        {
            InitializeComponent();
            Table();
            textBox1.Text = "0";
        }

        private void User2Window_Load(object sender, EventArgs e)
        { }
        private void button1_Click(object sender, EventArgs e)                                  //“添加进购物车”
        {
            string id    = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();             //从商品表中选择
            string name  = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string price = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            int stock    = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            if (stock > 0)
            {
                for(int i = 0;i < int.Parse(textBox1.Text);i++)
                {
                    dataGridView2.Rows.Add(id.ToString(), name.ToString(), price.ToString());
                }
            }
            else
            {
                MessageBox.Show("该商品已经售罄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)                                  //添加数字（商品选购数）
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                m_OrderNum += 1;
                textBox1.Text = $"{m_OrderNum}";
            }
            else
            {
                MessageBox.Show("请先选中要添加的商品！");
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            m_OrderNum = 0;
            textBox1.Text = $"{m_OrderNum}";
        }
        private void button2_Click(object sender, EventArgs e)                                  //“下单”
        {
            float PriceSum = 0;                                                                 // 记录总金额
            int rowCount = dataGridView2.RowCount;
            DBHandle example = new DBHandle();

            for (int i = 0; i <= rowCount - 1; i++)                                             //将购物车中每一行部分数据添加进订单表，并更新商品表中库存 stock
            {
                string id = dataGridView2.Rows[i].Cells[0].Value.ToString();
                float price = float.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());     //记录当前商品价格，也存入 t_Order
                string sql = $"insert into t_Order (OrderID, UserID, GoodID, Date, Price) values ('{m_OrderID}', '{Data.UID}', '{id}', getdate(), {price});" +
                             $"update t_Goods set Stock=Stock-1 where ID = {id};" +
                             $"update t_Stock set Stock=Stock-1 where ID = {id};";
                if (example.Execute(sql) > 1) { 
                    PriceSum += float.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString()); }
                else {
                    MessageBox.Show("sql语句执行有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Debugger.Break();                                        //触发断点（终端程序）
                }
            }

            example.Close();
            MessageBox.Show($"员工已成功为客户成交订单！\n 共计：{PriceSum}元");
            dataGridView2.Rows.Clear();                                                         //下单后刷新（清空）购物车界面
            Table();                                                                            //也刷新商品表
        }
        private void button3_Click(object sender, EventArgs e)                                  //“购物车中取消选择”
        {
            // 检查是否有选中的行
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string id    = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();         // 从购物车中选择
                string name  = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();         // WARNING:要提前拿到该数据，因为如果不存放却先删除了一行数据之后，再去查找时，整个表格中的索引会发生变化，影响结果
                string price = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;                     // 获取第一个选中行的索引

                dataGridView2.Rows.RemoveAt(selectedRowIndex);                                  // 删除操作
                MessageBox.Show($"已删除行：编号 - {id}， 名称 - {name}, 价格 - {price}");      // 输出选中行的数据：
            }
            else
            {
                MessageBox.Show("请先选中要删除的行");
            }
        }
        public void Table()
        {
            #region 查询表格数据语句实现
            dataGridView1.Rows.Clear();                                                     //用于窗口循环中刷新更改后的数据

            string sql = "select * from t_Goods;";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
                // ------------------------ ID--------------- Name ------------------ Price ----------- Stock -----------
            }
            data.Close();
            example.Close();
            #endregion
        }

    }
}
