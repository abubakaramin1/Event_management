namespace Event_management
{
    partial class AddResources
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            resourceNameTextBox = new TextBox();
            quantityTextBox = new TextBox();
            costTextBox = new TextBox();
            confirmButton = new Button();
            resourcecombobox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 68);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "Resource Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(184, 129);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(184, 210);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            label3.Text = "Cost";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(184, 284);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 4;
            label5.Text = "Resource Type";
            // 
            // resourceNameTextBox
            // 
            resourceNameTextBox.Location = new Point(405, 65);
            resourceNameTextBox.Name = "resourceNameTextBox";
            resourceNameTextBox.Size = new Size(153, 23);
            resourceNameTextBox.TabIndex = 5;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(405, 126);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(153, 23);
            quantityTextBox.TabIndex = 6;
            // 
            // costTextBox
            // 
            costTextBox.Location = new Point(405, 207);
            costTextBox.Name = "costTextBox";
            costTextBox.Size = new Size(153, 23);
            costTextBox.TabIndex = 7;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(630, 375);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 10;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // resourcecombobox
            // 
            resourcecombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            resourcecombobox.ForeColor = Color.Black;
            resourcecombobox.FormattingEnabled = true;
            resourcecombobox.Location = new Point(405, 284);
            resourcecombobox.Name = "resourcecombobox";
            resourcecombobox.Size = new Size(153, 23);
            resourcecombobox.TabIndex = 11;
            // 
            // AddResources
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resourcecombobox);
            Controls.Add(confirmButton);
            Controls.Add(costTextBox);
            Controls.Add(quantityTextBox);
            Controls.Add(resourceNameTextBox);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddResources";
            Text = "AddResources";
            FormClosed += AddResources_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox resourceNameTextBox;
        private TextBox quantityTextBox;
        private TextBox costTextBox;
        private ComboBox comboBox2;
        private Button confirmButton;
        private ComboBox resourcecombobox;
    }
}