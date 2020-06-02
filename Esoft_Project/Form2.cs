using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Esoft_Project
{
    public partial class SupplySet : Form
    {
        public SupplySet()
        {
            InitializeComponent();
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (AgentSet agentSet in Program.wftDb.AgentSet)
            {
                string[] item = { agentSet.id.ToString() + ".", agentSet.FirstName, agentSet.MiddleName, agentSet.LastName };
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }
        private void comboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void ShowClient()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientSet clientSet in Program.wftDb.ClientSet)
            {
                string[] item = { clientSet.id.ToString() + ".", clientSet.FirstName, clientSet.MiddleName, clientSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }
        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void ShowRealEstate()
        {
            comboBoxRealEstate.Items.Clear();
            foreach (RealEstateSet realEstateSet in Program.wftDb.RealEstateSet)
            {
                string[] item = { realEstateSet.id.ToString() + ".", realEstateSet.Address_City + ".", realEstateSet.Address_Street + ".",
                realEstateSet.Address_House + ".", realEstateSet.Address_Number + "."};
                comboBoxRealEstate.Items.Add(string.Join(" ", item));
            }
        }
        public partial class FormSupply : Form
        {
            public FormSupply()
            {
                InitializeComponent();
                ShowAgents();
                ShowClient();
                ShowRealEstate();
            }
        }
        private void SupplySet_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxRealEstate != null && textBoxPrice.Text != "")
                SupplySet supply = new SupplySet();
            supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
            supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
            supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
            supply.Price = Convert.ToInt64(textBoxPrice.Text);
            Program.wftDb.SupplySet.Add(supply);
            Program.wftDb.SaveChanges();
        }
        else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        void ShowSluppySet()
            listViewSupplySet.Item.Clear();
            foreach (SupplySet supply in Program.wftDb.SupplySet)
            {
            ListViewItem item = new ListViewItem(new string[]
            {
                supply.idAgent.ToString(), supply.idClient.ToString(), supply.idRealEstate.To.String(), supply.Price.ToString()
            });
        Item.Tag = supply;
            listViewSupplySet.Item.Add(item);
private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (ListViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = ListViewSupplySet.SelectedItems[0].Tag as SupplySet;
                supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                supply.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.wftDb.SaveChanges();
                ShowSupplySet();

            }
        }

        private void ShowSupplySet()
        {
            throw new NotImplementedException();
        }

        private void ListViewSupplySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = ListViewSupplySet.SelectedItems[0].Tag as SupplySet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(supply.idAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(supply.idClient.ToString());
                comboBoxRealEstate.SelectedIndex = comboBoxRealEstate.FindString(supply.idRealEstate.ToString());
                textBoxPrice.Text = supply.Price.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        
        try
        {
        if (ListViewSupplySet.SelectedItems.Count == 1)
            {
            SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
        Program.wftDb.SupplySet.Remove(supply);
            Program.wftDb.SaveChanges()
            ShowSupplySet();

        comboBoxAgents.SelectedItem = null;
            comboBoxClients.SelectedItem = null;
            comboBoxRealEstate.Selecte0dItem = null;
            textBoxPrice.Text = "";
            }
    catch 
    {
    MessageBox.Show("невозможно удалить, эта запись испольхуется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

                 
}
  

