using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string city = comboBox1.SelectedItem.ToString();
            string adress = textBox2.Text;
            string login = textBox3.Text;
            string password = textBox4.Text;

            string sex;
            if (radioButton2.Checked) sex = "m";
            else if (radioButton3.Checked) sex = "w";
            else sex = "non";

            string sport = "";
            if (checkBox1.Checked) sport += "Бег";
            if (checkBox2.Checked) sport += "Плавание";
            if (checkBox3.Checked) sport += "Шахматы";
            User user = new User(fio, city, adress, sex, login, password, sport);
            users.Add(user);
            Form2 form2 = new Form2(user.Fio, user.City, user.Adress, user.Sex, user.Login, user.Sport, users);
            form2.ShowDialog();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filename = ofd.FileName;
            Excel.Application myExc = new Excel.Application();

            if(myExc == null)
            {
                MessageBox.Show("Excel not install");
                return;
            }

            Excel.Workbook exWb = myExc.Workbooks.Open(filename, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Worksheet exWsh = exWb.Sheets[1];
            exWsh.Cells[1, 1] = "A";
            exWsh.Cells[1, 2] = "B";
            exWsh.Cells[1, 3] = "C";
            exWb.Save();
            myExc.Quit();
            MessageBox.Show("OK");
            
        }
    }
}

public class User
{
    string fio, city, adress, sex, login, pass, sport;

    public User(string fio, string city, string adress, string sex, string login, string pass, string sport)
    {
        this.fio = fio;
        this.city = city;
        this.adress = adress;
        this.sex = sex;
        this.login = login;
        this.pass = pass;
        this.sport = sport;
    }

    public string Fio { get => fio; set => fio = value; }
    public string City { get => city; set => city = value; }
    public string Adress { get => adress; set => adress = value; }
    public string Sex { get => sex; set => sex = value; }
    public string Login { get => login; set => login = value; }
    public string Pass { get => pass; set => pass = value; }
    public string Sport { get => sport; set => sport = value; }


}
