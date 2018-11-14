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
    public partial class OrderWin : Form
    {
        public OrderWin()
        {
            InitializeComponent();
        }

        private void placeOrderButton_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, placeOrderButton.ClientRectangle,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        private void placeOrderButton_Click(object sender, EventArgs e)
        {
            PlaceOrder();
        }

        private void PlaceOrder()
        {
            var customer = new Customer();
            // Populate the customer instance (text box perhaps)

            var order = new Order();
            // Populate the order instance (list box perhaps)

            var allowSplitOrders = true;
            var emailReciept = true;

            var payment = new Payment();
            // Populate the payment info from the UI


            var orderController = new OrderController();
            orderController.PlaceOrder(customer, order, payment,
                                        allowSplitOrders:false, 
                                        emailReceipt:true);
        }
    }
}
