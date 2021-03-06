﻿using System;
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
    public partial class Menu : Form
    {
        private object buttonOpenAgents;

        public Menu()
        {
            InitializeComponent();
            if (FormAuthoriaztion.users.type == "agent") buttonOpenAgents.Enabled = false;
            labelHello.Text = "Приветствую тебя, " + FormAuthoriaztion.users.login;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            //Задаем новую форму из класса Клиент и открываем ее
            Form formClient = new FormClient();
            formClient.Show();
        }

        private void buttonAgent_Click(object sender, EventArgs e)
        {
            //Задаем новую формулу из класса Агент и открываем ее
            Form formAgent = new FormAgent();
            formAgent.Show();
        }

        private void buttonOpenRealEstates_Click(object sender, EventArgs e)
        {
            //Задаем новую форму из класса объекты недвижимости и открываем ее
            Form formRealEstate = new FormRealEstate();
            formRealEstate.Show();
        }

        private void buttonSupplySet_Click(object sender, EventArgs e)
        {
            Form formSupply = new FormSupply();
            formSupply.Show()
        }

        private void labelHello_Click(object sender, EventArgs e)
        {

        }

        private void buttonDemandSet_Click(object sender, EventArgs e)
        {

        }

        private void buttonDealSet_Click(object sender, EventArgs e)
        {

        }
    }

    internal class FormSupply : Form
    {
    }
}
