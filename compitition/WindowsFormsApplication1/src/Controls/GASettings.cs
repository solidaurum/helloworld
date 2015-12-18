using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Controls
{
    public partial class GASettings : Form
    {
        public GASettings()
        {
            InitializeComponent();
        }
        public int getChromosomes()
        {
            return int.Parse(GACapital.Text);
        }

        public int getThreshold()
        {
            return int.Parse(this.GAEquityPerContract.Text);
        }
        public string getUnit()
        {
            return (string)timeRange.SelectedItem;
        }

        private void GAFinancialUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
