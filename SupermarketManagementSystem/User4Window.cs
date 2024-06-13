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
            
        }
    }
}
