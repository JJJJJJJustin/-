
namespace SupermarketManagementSystem
{
    partial class LoginWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radioButtonUser = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助SeeMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设计流程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.支持ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.小游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c学习文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c窗体资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c窗体简单用例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c控件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(281, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "超市销售管理系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(288, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(288, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(362, 208);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 29);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(362, 280);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(271, 29);
            this.textBox2.TabIndex = 4;
            // 
            // radioButtonUser
            // 
            this.radioButtonUser.AutoSize = true;
            this.radioButtonUser.Checked = true;
            this.radioButtonUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonUser.Location = new System.Drawing.Point(362, 350);
            this.radioButtonUser.Name = "radioButtonUser";
            this.radioButtonUser.Size = new System.Drawing.Size(60, 25);
            this.radioButtonUser.TabIndex = 5;
            this.radioButtonUser.TabStop = true;
            this.radioButtonUser.Text = "员工";
            this.radioButtonUser.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonAdmin.Location = new System.Drawing.Point(498, 350);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(76, 25);
            this.radioButtonAdmin.TabIndex = 6;
            this.radioButtonAdmin.Text = "管理员";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(345, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Location = new System.Drawing.Point(784, 4);
            this.dateTimePicker1.MaxDate = new System.DateTime(2029, 6, 7, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1949, 10, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 21);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助SeeMoreToolStripMenuItem,
            this.小游戏ToolStripMenuItem,
            this.c学习文档ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(921, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 帮助SeeMoreToolStripMenuItem
            // 
            this.帮助SeeMoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设计流程ToolStripMenuItem,
            this.支持ToolStripMenuItem});
            this.帮助SeeMoreToolStripMenuItem.Name = "帮助SeeMoreToolStripMenuItem";
            this.帮助SeeMoreToolStripMenuItem.Size = new System.Drawing.Size(124, 21);
            this.帮助SeeMoreToolStripMenuItem.Text = "帮助（See more）";
            // 
            // 设计流程ToolStripMenuItem
            // 
            this.设计流程ToolStripMenuItem.Name = "设计流程ToolStripMenuItem";
            this.设计流程ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设计流程ToolStripMenuItem.Text = "设计流程";
            this.设计流程ToolStripMenuItem.Click += new System.EventHandler(this.设计流程ToolStripMenuItem_Click);
            // 
            // 支持ToolStripMenuItem
            // 
            this.支持ToolStripMenuItem.Name = "支持ToolStripMenuItem";
            this.支持ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.支持ToolStripMenuItem.Text = "支持";
            this.支持ToolStripMenuItem.Click += new System.EventHandler(this.支持ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // 小游戏ToolStripMenuItem
            // 
            this.小游戏ToolStripMenuItem.Name = "小游戏ToolStripMenuItem";
            this.小游戏ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.小游戏ToolStripMenuItem.Text = "摸鱼小游戏";
            this.小游戏ToolStripMenuItem.Click += new System.EventHandler(this.小游戏ToolStripMenuItem_Click);
            // 
            // c学习文档ToolStripMenuItem
            // 
            this.c学习文档ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c窗体资料ToolStripMenuItem,
            this.c窗体简单用例ToolStripMenuItem,
            this.c控件ToolStripMenuItem});
            this.c学习文档ToolStripMenuItem.Name = "c学习文档ToolStripMenuItem";
            this.c学习文档ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.c学习文档ToolStripMenuItem.Text = "C#学习文档";
            // 
            // c窗体资料ToolStripMenuItem
            // 
            this.c窗体资料ToolStripMenuItem.Name = "c窗体资料ToolStripMenuItem";
            this.c窗体资料ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.c窗体资料ToolStripMenuItem.Text = "C#窗体资料";
            this.c窗体资料ToolStripMenuItem.Click += new System.EventHandler(this.c窗体资料ToolStripMenuItem_Click);
            // 
            // c窗体简单用例ToolStripMenuItem
            // 
            this.c窗体简单用例ToolStripMenuItem.Name = "c窗体简单用例ToolStripMenuItem";
            this.c窗体简单用例ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.c窗体简单用例ToolStripMenuItem.Text = "C#窗体简单用例";
            this.c窗体简单用例ToolStripMenuItem.Click += new System.EventHandler(this.c窗体简单用例ToolStripMenuItem_Click);
            // 
            // c控件ToolStripMenuItem
            // 
            this.c控件ToolStripMenuItem.Name = "c控件ToolStripMenuItem";
            this.c控件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.c控件ToolStripMenuItem.Text = "C#控件";
            this.c控件ToolStripMenuItem.Click += new System.EventHandler(this.c控件ToolStripMenuItem_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 531);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButtonAdmin);
            this.Controls.Add(this.radioButtonUser);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理系统登录";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButtonUser;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助SeeMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设计流程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 支持ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 小游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c学习文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c窗体资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c窗体简单用例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c控件ToolStripMenuItem;
    }
}

