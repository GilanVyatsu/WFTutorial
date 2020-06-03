using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormDealSet : System.Windows.Forms.Form
    {
        private object demandSet;

        public FormDealSet()
        {
            InitializeComponent();
        }
        void ShowSupply()
        {

            comboBoxSupply.Items.Clear();
            foreach (SupplySet supplySet in Program.wftDb.SupplySet)
            {
                string[] item = { supplySet.id.ToString() + ". ", "Риелтор: ", supplySet.AgentSet.LastName, "Клиент:  ", supplySet.ClientSet.LastName };
                comboBoxSupply.Items.Add(string.Join(" ", item));
            }
            void ShowDemand()
            {

                foreach (DemandSet demandSet in Program.wftDb.DemandSet)
                {

                    string[] item = { demandSet.id.ToString() + ". ", "Риелтор: " + demandSet.AgentSet.LastName, "Клиент: " + demandSet.ClientSet.LastName };
                    comboBoxDemand.Items.Add(string.Join(" ", item));

                }
                public FormDeal()
                {
                    InitializeComponent();
                    ShowSupply();
                    ShowDemand();
                }
            } }

        private void comboBoxSupply_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Deductions();
        }

        private void comboBoxDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }
        void Deductions()
        {
            if (comboBoxSupply.SelectedItem != null && comboBoxDemand.SelectedItem != null)
            {
                //находим в базе предложение и потребность с выбранными номероми
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                DemandSet demandSet = Program.wftDb.DemandSet.Find(Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]));
                //расчитываем отчисления компании для клиента-покупателя (3% от стоимости недвижимости), выводим в textCustomerCompanyOeductions 
                double customerCompanyDeductions = supplySet.Price * 0.03;
                textCustomerCompanyDeductions.Text = customerCompanyDeductions.ToString("0.00");
                //расчитываем отчисления риелтору для клиента-покупателя (комиссия указана в таблице AgentsSet), выводим в textBoxAgentCustoraerDeductions 
                if (demandSet.AgentSet.DealShare != null)
                {
                    double agentCustomerDeductions = customerCompanyDeductions * Convert.ToDouble(demandSet.AgentSet.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");
                }
                else
                {
                    //если комиссия не указана, то автоматически берется 45Х
                    double agentCustomerDeductions = customerCompanyDeductions * 0.45;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");
                }
            }
            else
            {
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
            }
            if (comboBoxSupply.SelectedItem != null)
            {
                //находим в базе предложение с выбранным номером
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                double sellerCompanyDeductions;
                if (supplySet.RealEstateSet.Type == 0)
                {
                    sellerCompanyDeductions = 36000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00"); }
                else if (supplySet.RealEstateSet.Type == 1)
                {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00"); }
                else {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.02;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");

                    if (supplySet.AgentSet.DealShare != null)
                    {
                        double agentSellerDeductions = sellerCompanyDeductions * Convert.ToDouble(supplySet.AgentSet.DealShare) / 100.00;
                        textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00"); }
                    else
                    {

                        double agentSellerDeductions = sellerCompanyDeductions * 0.45; textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00"); }
else
                    {
                        textBoxSellerCompanyDeductions.Text = "";
                        textBoxAgentSellerDeductions.Text = "";
                        textCustomerCompanyDeductions.Text = "";
                        textBoxAgentCustomerDeductions.Text = "";



                    }
                }

                void ShowDealSet()
                {
                    ListView listViewDealSet.Items.Clear();
                    foreach (DealSet deal in Program.wftDb.DealSet)
                    {
                        ListViewItem item = new ListViewItem(new string[]
                         {
                        deal.SupplySet.ClientSet.LastName,

                        deal.SupplySet.AgentSet.LastName,

                        deal.DemandSet.ClientSet.LastName,

                        deal.DemandSet.AgentSet.LastName,

                        "r. "+deal.SupplySet.RealEstateSet.Address_City+", ул. "+deal.SupplySet.RealEstateSet.Address_Street+", д. "+
                        deal.SupplySet.RealEstateSet.Address_House +", KB. "+deal.SupplySet.RealEstateSet.Address_Number,

                        deal.SupplySet.Price.ToString()
                          });
                        item.Tag = deal;

                        listViewDealSet.Items.Add(item);
                    }
                    public FromDeal()
                    {
                        InitializeComponent();
                        ShowSupply();
                        ShowDemand();
                        ShowDealSet();
                    }



                } }
#pragma warning disable CS8321 // Локальная функция объявлена, но не используется
            private void buttonEdit_Click(object sender, EventArgs e)
#pragma warning restore CS8321 // Локальная функция объявлена, но не используется
            {
                if (listViewDealSet.SelectedItems.Count == 1)
                {
                    DealSet deal = listViewDealSet.SelectedItems[0].Tag as DealSet;
                    deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                    deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                    Program.wftDb.SaveChanges();
                    ShowDealSet();
                }
                {


                } } }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDemand.SelectedItem != null && comboBoxSupply.SelectedItem != null)
            {
                //создаем новый экземпляр класса Сделка 
                DealSet deal =new DealSet();
                //из выбранной строки отделяем Id предложения (он отделен точкой) и делаем ссылку 
                deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                ////из выбранной строки отделяем Id потребности (он отделен точкой) и делаем ссылку
                deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.DealSet.Add(deal);

                Program.wftDb.SaveChanges();
                ShowDealSet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information)

        }
    } }