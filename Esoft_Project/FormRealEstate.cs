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
    public partial class RealEstateSet : System.Windows.Forms.Form
    {
        public RealEstateSet()
        {
            InitializeComponent();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_House.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;
                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Number;
                textBoxCoordinate_Latitude.Text = realEstate.Coordinate_latitude.ToString();
                textBoxCoordinate_Longitude.Text = realEstate.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxTotalFloor.Text = realEstate.TotalFloors.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_Latitude.Text = "";
                textBoxCoordinate_Longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxTotalFloor.Text = "";
            }

            private void listView2_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;
                    textBoxAddress_City.Text = realEstate.Address_City;
                    textBoxAddress_Street.Text = realEstate.Address_Street;
                    textBoxAddress_House.Text = realEstate.Address_House;
                    textBoxAddress_Number.Text = realEstate.Address_Number;
                    textBoxCoordinate_Latitude.Text = realEstate.Coordinate_latitude.ToString();
                    textBoxCoordinate_Longitude.Text = realEstate.Coordinate_longitude.ToString();
                    textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                    textBoxRooms.Text = realEstate.Rooms.ToString();
                    textBoxTotalFloor.Text = realEstate.TotalFloors.ToString();
                }
                else
                {
                    textBoxAddress_City.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Latitude.Text = "";
                    textBoxCoordinate_Longitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxRooms.Text = "";
                    textBoxTotalFloor.Text = "";
                }
            }

            private void comboBoxType_SelectedIndexChanged1(object sender, EventArgs e)
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    listViewRealEstateSet_Apartment.Visible = true;
                    labelFloor.Visible = true;
                    textBoxFloor.Visible = true;
                    labelRooms.Visible = true;
                    textBoxRooms.Visible = true;

                    listViewRealEstateSet_Apartment.Visible = false;
                    listViewRealEstateSet_Land.Visible = false;
                    labelFloor.Visible = false;
                    textBoxFloor.Visible = false;

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Latitude.Text = "";
                    textBoxCoordinate_Longitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxRooms.Text = "";
                    textBoxFloor.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    listViewRealEstateSet_Apartment.Visible = true;
                    labelFloor.Visible = true;
                    textBoxFloor.Visible = true;

                    listViewRealEstateSet_Apartment.Visible = false;
                    listViewRealEstateSet_Land.Visible = false;
                    labelFloor.Visible = false;
                    textBoxFloor.Visible = false;
                    labelRooms.Visible = false;
                    textBoxRooms.Visible = false;

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxCoordinate_Latitude.Text = "";
                    textBoxCoordinate_Longitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxFloor.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 2)
                {
                    listViewRealEstateSet_Land.Visible = true;

                    listViewRealEstateSet_Apartment.Visible = false;
                    listViewRealEstateSet_Apartment.Visible = false;
                    labelFloor.Visible = false;
                    textBoxFloor.Visible = false;
                    labelRooms.Visible = false;
                    textBoxRooms.Visible = false;
                    labelFloor.Visible = false;
                    textBoxFloor.Visible = false;

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Latitude.Text = "";
                    textBoxCoordinate_Longitude.Text = "";
                    textBoxTotalArea.Text = "";
                }
            }

            private static void ShowRealEstateSet()
            {
                throw new NotImplementedException();
            }
        }

        private void buttonAdd_Click1(object sender, EventArgs e)
        {
            RealEstateSet realEstate = new RealEstateSet();
            realEstate.Address_City = textBoxAddress_City.Text;
            realEstate.Address_Street = textBoxAddress_Street.Text;
            realEstate.Address_House = textBoxAddress_House.Text;
            realEstate.Address_Number = textBoxAddress_Number.Text;
            realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_Latitude.Text);
            realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_Longitude.Text);
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
            Program.wftDb.RealEstateSet.Add(realEstate);
            Program.wftDb.SaveChanges();

        }

        private void buttonEdit_Click1(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;
                    realEstate.Address_City = textBoxAddress_City.Text;
                    realEstate.Address_Street = textBoxAddress_Street.Text;
                    realEstate.Address_House = textBoxAddress_House.Text;
                    realEstate.Address_Number = textBoxAddress_Number.Text;
                    realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_Latitude.Text);
                    realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_Longitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
                    Program.wftDb.SaveChanges();
                    ShowRealEstateSet();
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;
                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_Latitude.Text);
                        realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_Longitude.Text);
                        realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloor);
                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }
                }
                else
                {
                    if (listViewRealEstateSet_Land.SelectedItems.Count == 2)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;
                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_Latitude.Text);
                        realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_Longitude.Text);
                        realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        Program.wftDb.SaveChanges();
                        ShowRealEstate();

                        void ShowRealEstate()
                        {
                            listViewRealEstateSet_Apartment.Items.Clear();
                            listViewRealEstateSet_Land.Items.Clear();
                            listViewRealEstateSet_House.Items.Clear();

                            foreach (RealEstateSet realEstateSet in Program.wftDb.RealEstateSet)
                            {
                                if (realEstate.Type == 0)
                                {
                                    ListViewItem item = new ListViewItem(new string[]
                                    {
                             realEstate.Address_City, realEstate.Address_Street,realEstate.Address_House,realEstate.Address_Number,
                             realEstate.Coordinate_latitude.ToString(),realEstate.Coordinate_longitude.ToString(),realEstate.TotalArea.ToString(),
                             realEstate.Rooms.ToString(),realEstate.Floor.ToString()
                                    });
                                    item.Tag = realEstate;
                                    listViewRealEstateSet_Apartment.Items.Add(item);
                                }
                                else if (realEstate.Type == 1)
                                {
                                    ListViewItem item = new ListViewItem(new string[]
                                      {
                                      realEstate.Address_City, realEstate.Address_Street,realEstate.Address_House,realEstate.Address_Number,
                                      realEstate.Coordinate_latitude.ToString(),realEstate.Coordinate_longitude.ToString(),realEstate.TotalArea.ToString(),
                                      realEstate.TotalFloors.ToString()
                                      });
                                    item.Tag = realEstate;
                                    listViewRealEstateSet_House.Items.Add(item);
                                }
                                else
                                {
                                    ListViewItem item = new ListViewItem(new string[]
                                    {
                                      realEstate.Address_City, realEstate.Address_Street,realEstate.Address_House,realEstate.Address_Number,
                                      realEstate.Coordinate_latitude.ToString(),realEstate.Coordinate_longitude.ToString(),realEstate.TotalArea.ToString()
                                    });
                                    {
                                        item.Tag = realEstate;
                                        listViewRealEstateSet_Land.Items.Add(item);
                                    }
                                }
                                listViewRealEstateSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                                listViewRealEstateSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                                listViewRealEstateSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);



                            }
                        }
                    }
                }
            }
        }

        private void ShowRealEstateSet()
        {
            throw new NotImplementedException();
        }

        private void listViewRealEstateSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;
                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Number;
                textBoxCoordinate_Latitude.Text = realEstate.Coordinate_latitude.ToString();
                textBoxCoordinate_Longitude.Text = realEstate.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_Latitude.Text = "";
                textBoxCoordinate_Longitude.Text = "";
                textBoxTotalArea.Text = "";
            }
        } } }