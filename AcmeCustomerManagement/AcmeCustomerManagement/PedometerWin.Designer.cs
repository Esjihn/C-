namespace AcmeCustomerManagement
{
    partial class PedometerWin
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
            this.stepGoalLabel = new System.Windows.Forms.Label();
            this.numberOfStepsLabel = new System.Windows.Forms.Label();
            this.goalTextBox = new System.Windows.Forms.TextBox();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stepGoalLabel
            // 
            this.stepGoalLabel.AutoSize = true;
            this.stepGoalLabel.Location = new System.Drawing.Point(30, 29);
            this.stepGoalLabel.Name = "stepGoalLabel";
            this.stepGoalLabel.Size = new System.Drawing.Size(105, 13);
            this.stepGoalLabel.TabIndex = 0;
            this.stepGoalLabel.Text = "Step Goal for Today:";
            // 
            // numberOfStepsLabel
            // 
            this.numberOfStepsLabel.AutoSize = true;
            this.numberOfStepsLabel.Location = new System.Drawing.Point(13, 53);
            this.numberOfStepsLabel.Name = "numberOfStepsLabel";
            this.numberOfStepsLabel.Size = new System.Drawing.Size(122, 13);
            this.numberOfStepsLabel.TabIndex = 1;
            this.numberOfStepsLabel.Text = "Number of Steps Today:";
            // 
            // goalTextBox
            // 
            this.goalTextBox.Location = new System.Drawing.Point(141, 26);
            this.goalTextBox.Name = "goalTextBox";
            this.goalTextBox.Size = new System.Drawing.Size(100, 20);
            this.goalTextBox.TabIndex = 2;
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.Location = new System.Drawing.Point(141, 50);
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepsTextBox.TabIndex = 3;
            // 
            // calculateButton
            // 
            this.calculateButton.FlatAppearance.BorderSize = 0;
            this.calculateButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateButton.Location = new System.Drawing.Point(247, 26);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(95, 44);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            this.calculateButton.Paint += new System.Windows.Forms.PaintEventHandler(this.calculateButton_Paint);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(160, 108);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 5;
            // 
            // PedometerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 171);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.stepsTextBox);
            this.Controls.Add(this.goalTextBox);
            this.Controls.Add(this.numberOfStepsLabel);
            this.Controls.Add(this.stepGoalLabel);
            this.Name = "PedometerWin";
            this.Text = "Pedometer Metrics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stepGoalLabel;
        private System.Windows.Forms.Label numberOfStepsLabel;
        private System.Windows.Forms.TextBox goalTextBox;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
    }
}