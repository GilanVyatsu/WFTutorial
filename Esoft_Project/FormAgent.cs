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
    public partial class FormAgent : System.Windows.Forms.Form
    {
        public FormAgent()
        {
            InitializeComponent();
            ShowAgent();
        }

        private void ShowAgent()
        {
            throw new NotImplementedException();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаем новый экземпляр класса Агента
            AgentSet agentSet = new AgentSet();
            //делаем ссылку на объект, который хранится в textBox-ax
            agentSet.FirstName = textBoxFirstName.Text;
            agentSet.MiddleName = textBoxMiddleName.Text;
            agentSet.LastName = textBoxLastName.Text;
            //добавляем в таблицу AgentSet нового клиента agentSet
            Program.wftDb.AgentSet.Add(agentSet);
            //сохраняем изменения в модели wftDb (экземпляр которой был создан ранее)
            Program.wftDb.SaveChanges();
            
        }
    

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewAgent.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тэгу
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                //указываем, что может быть изменно
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.LastName = textBoxLastName.Text;
                
                //сохраняем изображение в wftDB (экземпляр который был создан ранее)
                Program.wftDb.SaveChanges();
                //отображение в listView
                ShowAgent();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран один элемент из listView
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    //ищем этот элемент, сверяем его
                    AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                    //удаляем из модели и забы данных
                    Program.wftDb.AgentSet.Remove(agentSet);
                    //сохраняем изменения
                    Program.wftDb.SaveChanges();
                    //отображаем обновленные списки
                }
                //очищаем textBox-ы
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
            //если возникнет какая то из ошибок, к примеру, запись использования, выводим вспылвающее сообщение
            catch
            {
                //вызываем метод для всплывающего окна, в котором указывается текст, заголовок, кнопку и иконку
                MessageBox.Show("невозможно удалить, эта запись используется!", "ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //условие, если выбран 1 элемент 
            if (listViewAgent.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тэгу
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                //указываем, что может быть изменено
                textBoxFirstName.Text = agentSet.FirstName;
                textBoxMiddleName.Text = agentSet.MiddleName;
                textBoxLastName.Text = agentSet.LastName;
                
            }

            else
            {
                //условие, иначе, если не выбран ни один элемент, то задаем пустое поле
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";

            }

            void ShowAgent()
            {
                //предварительное оповещение listView
                listViewAgent.Items.Clear();
                //проходимся по коллекции клиентов, которые находятся в базе с помощью foreach
                foreach (AgentSet agentSet in Program.wftDb.AgentSet)
                {
                    //создаем новый элемент в listView
                    //для этого создаем новый массив строк
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        //указываем необходимые поля
                        agentSet.id.ToString(),
                        agentSet.FirstName,
                        agentSet.MiddleName,
                        agentSet.LastName,
                        
                    });
                    //указываем по какому тегу будем брать элемент
                    item.Tag = agentSet;
                    //добавляем элемент в listView для отображения
                    listViewAgent.Items.Add(item);
                }
                //выравниваем колонки в listView
                listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
