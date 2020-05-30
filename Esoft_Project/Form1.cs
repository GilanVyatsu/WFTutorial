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
    public partial class RealEstateSet : Form
    {
        public RealEstateSet()
        {
            InitializeComponent();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewRealEstateSet.Visible = true;
                labelFloor.Visible = true;
                textBoxFloor.Visible = true;
                labelRooms.Visible = true;
                textBoxRooms.Visible = true;

                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Land.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;

                textBoxCity.Text = "";
                textBoxHouse.Text = "";
                textBoxStreet.Text = "";
                textBoxNumber.Text = "";
                textBoxLatitude.Text = "";
                textBoxLongtitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewRealEstateSet_House.Visible = true;
                labelFloor.Visible = true;
                textBoxFloor.Visible = true;

                listViewRealEstateSet_Apartment.Visible = false;
                listViewRealEstateSet_Land.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;

                textBoxCity.Text = "";
                textBoxHouse.Text = "";
                textBoxStreet.Text = "";
                textBoxHouse.Text = "";
                textBoxLatitude.Text = "";
                textBoxLongtitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxFloor.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewRealEstateSet_Land.Visible = true;

                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Apartment.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;

                textBoxCity.Text = "";
                textBoxHouse.Text = "";
                textBoxStreet.Text = "";
                textBoxNumber.Text = "";
                textBoxLatitude.Text = "";
                textBoxLongtitude.Text = "";
                textBoxTotalArea.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RealEstateSet realEstate = new RealEstateSet();
            realEstate.City = textBoxCity.Text;
            realEstate.Street = textBoxStreet.Text;
            realEstate.House = textBoxHouse.Text;
            realEstate.Number = textBoxNumber.Text;
            realEstate.Latitude = Convert.ToDouble(textBoxLatitude.Text);
            realEstate.Longtitiude = Convert.ToDouble(textBoxLongtitude.Text);
            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);

            if (comboBoxType.SelectedIndex == 0)
            {
                realEstate.Type = 0;
                realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                realEstate.Type = 1;
                realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloor);
            }
            else
            {
                realEstate.Type = 2;
            }
            Program.eSoftDB.RealEstateSet.Add(realEstate);
            Program.eSoftDB.SaveChanges();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;
                    realEstate.City = textBoxCity.Text;
                    realEstate.Street = textBoxStreet.Text;
                    realEstate.House = textBoxHouse.Text;
                    realEstate.Number = textBoxNumber.Text;
                    realEstate.Latitude = Convert.ToDouble(textBoxLatitude.Text);
                    realEstate.Longtitiude = Convert.ToDouble(textBoxLongtitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
                    Program.eSoftDB.SaveChanges();
                    ShowRealEstateSet();
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;
                        realEstate.City = textBoxCity.Text;
                        realEstate.Street = textBoxStreet.Text;
                        realEstate.House = textBoxHouse.Text;
                        realEstate.Number = textBoxNumber.Text;
                        realEstate.Latitude = Convert.ToDouble(textBoxLatitude.Text);
                        realEstate.Longtitiude = Convert.ToDouble(textBoxLongtitude.Text);
                        realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloor);
                        Program.eSoftDB.SaveChanges();
                        ShowRealEstateSet();
                    }
                }
                else
                {
                    if (listViewRealEstateSet_Land.SelectedItems.Count == 2)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;
                        realEstate.City = textBoxCity.Text;
                        realEstate.Street = textBoxStreet.Text;
                        realEstate.House = textBoxHouse.Text;
                        realEstate.Number = textBoxNumber.Text;
                        realEstate.Coordinate_latitude = Convert.ToDouble(textBoxLatitude.Text);
                        realEstate.Longtitiude = Convert.ToDouble(textBoxLongtitude.Text);
                        realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        Program.eSoftDB.SaveChanges();
                        ShowRealEstateSet();

                    }
                }
            }
        }
    }
}