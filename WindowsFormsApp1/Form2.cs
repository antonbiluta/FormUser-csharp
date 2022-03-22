using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(string fio, string city, string adress, string sex, string login, string sport, List<User> users)
        {
            InitializeComponent();

            string temp_text = "Здравствуйте, ";
            temp_text += login;
            label1.Text = temp_text;

            temp_text = "Город: ";
            temp_text += city;
            label2.Text = temp_text;

            temp_text = "Адресс: ";
            temp_text += adress;
            label3.Text = temp_text;

            temp_text = "ФИО: ";
            temp_text += fio;
            label4.Text = temp_text;

            temp_text = "Пол: ";
            temp_text += sex;
            label5.Text = temp_text;

            temp_text = "Спорт: ";
            temp_text += sport;
            label6.Text = temp_text;


        }

    }
}
