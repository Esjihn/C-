using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACM.BL;

namespace AcmeCustomerManagement
{
    public partial class PedometerWin : Form
    {
        public PedometerWin()
        {
            InitializeComponent();
        }

        private void calculateButton_Paint(object sender, PaintEventArgs e)
        {
                ControlPaint.DrawBorder(e.Graphics, calculateButton.ClientRectangle,
                    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            var result = customer.CalculatePercentOfGoalSteps(goalTextBox.Text,
                stepsTextBox.Text);

            resultLabel.Text = $@"You reached {result} % of your goal!";

        }
    }
}
