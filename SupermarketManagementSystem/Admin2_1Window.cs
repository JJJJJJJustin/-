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
    public partial class Admin2_1Window : Form
    {
        public Admin2_1Window()
        {
            InitializeComponent();
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("请先选择一个商品。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bool itemExists = false;
            string id       = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();             //从商品表中选择
            string name     = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int stock       = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            string price    = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            foreach (DataGridViewRow row in dataGridView2.Rows){                                    //检测表格2中的id是否在表格1中存在过（即重复添加） 
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == id) {
                    itemExists = true;
                    break;
                }
            }

            if (itemExists)
            {
                MessageBox.Show("一种商品只能被上架一次哦", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (stock > 0) { dataGridView2.Rows.Add(id.ToString(), name.ToString(), price.ToString()); } 
            else { MessageBox.Show("该商品已无库存！等待增加库存中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void button2_Click(object sender, EventArgs e)                                  //“上架”
        {
            int rowCount = dataGridView2.RowCount;
            DBHandle example = new DBHandle();

            for (int i = 0; i <= rowCount - 1; i++)                                             //将购物车中每一行部分数据添加进订单表，并更新商品表中库存 stock
            {
                string id   = dataGridView2.Rows[i].Cells[0].Value.ToString();
                string name = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                float price = float.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
                int stock   = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                string sql = $"insert into t_Goods (ID, Name, Price, Stock) values ('{id}', '{name}', {price}, {stock});" ;
                             // + $"update t_Stock set Stock=Stock-1 where ID = '{id}' and Name = '{name}';";
                if (example.Execute(sql) < 1)
                {
                    MessageBox.Show("sql语句执行有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Debugger.Break();                                        //触发断点（终端程序）
                }
            }

            example.Close();
            MessageBox.Show($"您已经成功为商店上架商品！\n 商品：{dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}");
            dataGridView2.Rows.Clear();                                                         //下单后刷新（清空）购物车界面
            Table();                                                                            //也刷新商品表
        }
        private void button3_Click(object sender, EventArgs e)                                  //“购物车中取消选择”
        {
            // 检查是否有选中的行
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();           // 从商品上架表中选择
                string name = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();         // WARNING:要提前拿到该数据，因为如果不存放却先删除了一行数据之后，再去查找时，整个表格中的索引会发生变化，影响结果
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

        public void Table()                                                                 //此处的 table 是库存表减去商品表剩下的为上架的商品
        {
            #region 查询表格数据语句实现
            dataGridView1.Rows.Clear(); 

            string sql = "SELECT t_Stock.* FROM t_Stock " +
                         "LEFT JOIN t_Goods ON t_Stock.ID = t_Goods.ID " +
                         "WHERE t_Goods.ID IS NULL; ";
            //使用 LEFT JOIN 将库存表中的每一行与商品表 (goods) 中的行进行连接，连接条件是两个表的 ID 列相同。
            //同时，筛选出商品表 (goods) 中没有对应记录的库存表 (stock) 的行，即那些在库存表中有但在商品表中没有的商品。
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
                // ------------------------ ID--------------- Name ------------------ Stock ----------- Supplier------------ Price ------
            }
            data.Close();
            example.Close();
            #endregion
        }
    }

}
