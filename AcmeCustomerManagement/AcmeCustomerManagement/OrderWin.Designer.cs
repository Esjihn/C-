namespace AcmeCustomerManagement
{
    partial class OrderWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.placeOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // placeOrderButton
            // 
            this.placeOrderButton.FlatAppearance.BorderSize = 0;
            this.placeOrderButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.placeOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.placeOrderButton.Location = new System.Drawing.Point(635, 12);
            this.placeOrderButton.Name = "placeOrderButton";
            this.placeOrderButton.Size = new System.Drawing.Size(153, 96);
            this.placeOrderButton.TabIndex = 0;
            this.placeOrderButton.Text = "Place Order";
            this.placeOrderButton.UseVisualStyleBackColor = true;
            this.placeOrderButton.Click += new System.EventHandler(this.placeOrderButton_Click);
            this.placeOrderButton.Paint += new System.Windows.Forms.PaintEventHandler(this.placeOrderButton_Paint);
            // 
            // OrderWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.placeOrderButton);
            this.Name = "OrderWin";
            this.Text = "Review your Order";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button placeOrderButton;
    }
}

