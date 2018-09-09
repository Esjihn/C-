using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace TestingNuget
{
    
    public partial class loginForm : Form
    {
        const string Username = "Esjihn";
        const string Password = "P@ssword";
        public loginForm()
        {
            InitializeComponent();
        }



        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginUserName.Text == Username && loginPassword.Text == Password)
            {
                MessageBox.Show("Logging in");
                Form2 f2 = new Form2();
                f2.Show();
                
            }
            else
            {
                MessageBox.Show("Login information incorrect");
            }
            
        }
    }
}
