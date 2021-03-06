﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeerCalculator
{
    /*Upcoming implementations:
    -Finish BeerDB.db implementation (nuget packages for functionality)
    -Search function
    -Create Class Library!
    -Find a way to abstract away the assigning of variables
    -Combobox (?) w/ database of grain types -- data binding
    -Visual representation for user of ComboBox / search selection  -- of all grains to be calculated
    -add/remove grains feature to compliment above point
    */

    public partial class MainForm : Form
    {
              
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            
            Grain g1 = new Grain();
            Grain g2 = new Grain();

            g1.pounds = Convert.ToDouble(PoundsTextBox1.Text);
            g1.gPoints = Convert.ToDouble(GravityTextBox1.Text);
            g1.srmPoints = Convert.ToDouble(SRMTextBox1.Text);
            g2.gPoints = Convert.ToDouble(GravityTextBox2.Text);
            g2.pounds = Convert.ToDouble(PoundsTextBox2.Text);
            g2.srmPoints = Convert.ToDouble(SRMTextBox2.Text);
            var gal = Convert.ToDouble(BatchSizeTextBox.Text);

            var srmResult = Calculations.GetColor(g1, g2, gal);
            var gravResult = Calculations.GetGrav(g1, g2, gal);


            gravResult = Calculations.ConvertFormat(gravResult);

            EstimatedOGTextBox.Text = Convert.ToString(gravResult);
            EstimatedColorTextBox.Text = Convert.ToString(srmResult);

        }

        private void TextBoxChange(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            double test;
            if (double.TryParse(box.Text, out test))
            {
                errorProvider.Clear();
            }
            else
            {
                box.Text = string.Empty;
                errorProvider.SetError(box, "Calculator only accepts numbers 0 through 9");

            }

        }
    }
}
