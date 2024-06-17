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
    public partial class Admin4_1_2Window : Form
    {
        public Admin4_1_2Window()
        {
            InitializeComponent();
        }
        public Admin4_1_2Window(string name)
        {
            InitializeComponent();
            Table(name);
        }
        private void Table(string name)
        {
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Stock where name like '%{name}%';";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
            }
            data.Close();
            example.Close();
        }
    }
}
