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
    public partial class LittleGame : Form
    {
        public LittleGame()
        {
            InitializeComponent();

            AssignIconsToSquares();                                         //分配图标到每个框体中（图标为label:使用webdings字体实现)
        }
        // "firstClicked" points to the first Label control that the player clicks,
        // but it will be null if the player hasn't clicked a label yet
        Label firstClicked = null;
        // "secondClicked" points to the second Label control that the player clicks
        Label secondClicked = null;

        // Use this Random object to choose random icons for the squares
        Random random = new Random();                                       //随机种子
        // Each of these letters is an interesting icon in the Webdings font,and each icon appears twice in this list
        List<string> icons = new List<string>()                             //存储所有图标
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares()                                 //将图标随机分配给 Label 控件
        {
            // The TableLayoutPanel has 16 labels, and the icon list has 16 icons,
            // so an icon is pulled at random from the list and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)         //循环访问 TableLayoutPanel 中的每个标签控件。 它对每个控件运行相同的语句。 语句从列表中提取随机图标。
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;              //是否隐藏图标
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)               //每个标签的点击触发事件都由这个函数控制（点击方格显示一个图标）
        {
            // 计时器仅在两个图片不匹配之后启用，故计时器运行时会忽略玩家之后进行的任何操作。
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // 如果点击的标签是黑色的，则玩家点击了已经显示的图标 - 忽略点击
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                //如果 firstClicked 为 null，则这是玩家单击的对中的第一个图标，所以设置first点击玩家点击的标签，将其颜色改为黑色，然后返回
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                // 如果玩家走到这一步，计时器依旧未启用，则 firstClicked 不为空。所以这一定是玩家点击的第二个图标,将其颜色设置为黑色
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // 检查是否全部图标已经被揭示（玩家胜利）
                CheckForWinner();

                // 如果玩家点击了两个相匹配的图标, 保持其常亮并重置firstClicked 和 secondClicked ，这样玩家就可以点击下两个图标继续游玩
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // 如果玩家走到这一步，却点击了两个不同的图标，则开始计时（等待3/4秒，然后隐藏图标）
                timer1.Start();
            }
        }

        //当玩家点击时两个不匹配的图标，此计时器启动(四分之三秒后关闭并隐藏两个图标)
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked ,so the next time a label is clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()                                           //是否胜利？
        {
            // 遍历面板中的所有图标, 检查是否已经全部匹配。（若不匹配则退出）
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // 若循环遍历完成且未被中断,则表明玩家胜利。 Show a message and close the form
            MessageBox.Show("你获得了摸鱼小游戏的胜利！", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
