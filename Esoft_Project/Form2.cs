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
    }
}
