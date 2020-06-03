using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public struct User
    {
        public string login;
        public string password;
        public string type;
    }
    public partial class FormAuthoriaztion : Form
    {
        public static User users = new User();
        public FormAuthoriaztion()
        {
            InitializeComponent();
        }

        private void FormAuthoriaztion_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool key = false;
                //ищем в базе данных пользователя с такими логином и паролем и запоминаем их foreach (Users user in Program.wftDb.Users)
                {
                    if (textBoxLogin.Text == users.Login && textBoxPassword.Text == users.Password)
                    {
                        key = true;
                        users.login = users.Login;
                        users.password = users.Password;
                        users.type = users.Type;
                    }
                    if (!key)
                    {
                        MessageBox.Show("Проверьте данные", "Пользователь не найдем", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxLogin.Text = " ";
                        textBoxPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Данные введены верно", "Пользователь найдем", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu menu = new Menu();
                        menu.Show();
                        this.Hide();
                    }

                }
            }
        }
    }
}
