using System;
using System.Windows.Forms;

namespace Readini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //选择文件路径
        string path = Application.StartupPath + "\\DBServer.ini";
        
        private void btnWrite_Click(object sender, EventArgs e)
        {     
            //bool b1 = ReadWriteini.WriteIniData("Server", "Name", txtServer.Text, path);
            //bool b2 = ReadWriteini.WriteIniData("DB", "Name", txtDatabase.Text, path);
            //bool b3 = ReadWriteini.WriteIniData("User", "Name", txtName.Text, path);
            
            ReadWriteini rwini = new ReadWriteini(path);
            bool b1 = rwini.WriteIniData("Server", "Name", txtServer.Text);
            bool b2 = rwini.WriteIniData("DB", "Name", txtDatabase.Text);
            bool b3 = rwini.WriteIniData("User", "Name", txtName.Text);

            if (b1 == true && b2 == true && b3 == true) MessageBox.Show("ini文件更新成功！");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
        //    txtServer.Text = ReadWriteini.ReadIniData("Server", "Name", "NoText", path);
        //    txtDatabase.Text = ReadWriteini.ReadIniData("DB", "Name", "NoText", path);
        //    txtName.Text = ReadWriteini.ReadIniData("User", "Name", "NoText", path); 

            ReadWriteini rwini = new ReadWriteini(path);
            txtServer.Text = rwini.ReadIniData("Server", "Name");
            txtDatabase.Text =rwini.ReadIniData("DB", "Name");
            txtName.Text = rwini.ReadIniData("User", "Name");


        }
    }
}
