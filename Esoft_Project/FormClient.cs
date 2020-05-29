using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаем новый экземпляр класса Клиент
            ClientSet clientSet = new ClientSet();
            //делаем ссылку на объект, который хранится в textBox-ax
            clientSet.FirstName = textBoxFirstName.Text;
            clientSet.MiddleName = textBoxMiddleName.Text;
            clientSet.LastName = textBoxLastName.Text;
            clientSet.Phone = textBoxPhone.Text;
            clientSet.Email = textBoxEmail.Text;
            //добавляем в таблицу ClientSet нового клиента clientSet
            Program.wftDb.ClientSet.Add(clientSet);
            //сохраняем изменения в модели wftDb (экземпляр которой был создан ранее)
            Program.wftDb.SaveChanges();
        }
        void ShowClient()
        {
            //предварительное оповещение listView
            listViewClient.Items.Clear();
            //проходимся по коллекции клиентов, которые находятся в базе с помощью foreach
            foreach (ClientSet clientSet in Program.wftDb.ClientSet)
            {
                //создаем новый элемент в listView
                //для этого создаем новый массив строк
                ListViewItem item = new ListViewItem(new string[]
                {
                    //указываем необходимые поля
                    clientSet.id.ToString(), clientSet.FirstName, clientSet.MiddleName,
                    clientSet.LastName, clientSet.Phone, clientSet.Email
                });
                //указываем по какому тегу будем брать элемент
                item.Tag = clientSet;
                //добавляем элемент в listView для отображения
                listViewClient.Items.Add(item);
            }
            //выравниваем колонки в listView
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //условие, если выбран 1 элемент 
            if (listViewClient.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тэгу
                ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                //указываем, что может быть изменено
                textBoxFirstName.Text = clientSet.FirstName;
                textBoxMiddleName.Text = clientSet.MiddleName;
                textBoxLastName.Text = clientSet.LastName;
                textBoxPhone.Text = clientSet.Phone;
                textBoxEmail.Text = clientSet.Email;
            }

            else
            {
                //условие, иначе, если не выбран ни один элемент, то задаем пустое поле
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewClient.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тэгу
                ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                //указываем, что может быть изменно
                clientSet.FirstName = textBoxFirstName.Text;
                clientSet.MiddleName = textBoxMiddleName.Text;
                clientSet.LastName = textBoxLastName.Text;
                clientSet.Phone = textBoxPhone.Text;
                clientSet.Email = textBoxEmail.Text;
                //сохраняем изображение в wftDB (экземпляр который был создан ранее)
                Program.wftDb.SaveChanges();
                //отображение в listView
                ShowClient();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран один элемент из listView
                if (listViewClient.SelectedItems.Count == 1)
                {
                    //ищем этот элемент, сверяем его
                    ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                    //удаляем из модели и забы данных
                    Program.wftDb.ClientSet.Remove(clientSet);
                    //сохраняем изменения
                    Program.wftDb.SaveChanges();
                    //отображаем обновленные списки
                }
                //очищаем textBox-ы
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
            //если возникнет какая то из ошибок, к примеру, запись использования, выводим вспылвающее сообщение
            catch
            {
                //вызываем метод для всплывающего окна, в котором указывается текст, заголовок, кнопку и иконку
                MessageBox.Show("невозможно удалить, эта запись используется!", "ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
    } }








