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
    public partial class Admin3Window : Form
    {
        public Admin3Window()
        {
            InitializeComponent();
        }

        private void Admin3Window_Load(object sender, EventArgs e)
        {
            string sql = $"select * from t_Admin where UserID = '{Data.UID}';";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            if (data.Read())
            {
                string id = data["UserID"].ToString();
                string name = data["UserName"].ToString();
                string password = data["Password"].ToString();

                label4.Text = $"{id}";
                label5.Text = $"{name}";
                label6.Text = $"{password}";
            }
            else{ MessageBox.Show("哈哈"); }
            
        }

    }
}
