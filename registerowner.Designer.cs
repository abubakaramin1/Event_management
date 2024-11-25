namespace Event_management
{
    partial class frm_registerowner
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
            label4 = new Label();
            label5 = new Label();
            txt_username = new TextBox();
            txt_password = new TextBox();
            txt_Name = new TextBox();
            txt_email = new TextBox();
            txt_phonenumber = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 101);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 157);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 226);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Full Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 291);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(113, 353);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 4;
            label5.Text = "Phone Number";
            // 
            // txt_username
            // 
            txt_username.Location = new Point(306, 98);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(193, 23);
            txt_username.TabIndex = 5;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(306, 154);
            txt_password.Multiline = true;
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(193, 23);
            txt_password.TabIndex = 6;
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(306, 218);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(193, 23);
            txt_Name.TabIndex = 7;
            // 
            // txt_email
            // 
            txt_email.Location = new Point(306, 283);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(193, 23);
            txt_email.TabIndex = 8;
            // 
            // txt_phonenumber
            // 
            txt_phonenumber.Location = new Point(306, 345);
            txt_phonenumber.Name = "txt_phonenumber";
            txt_phonenumber.Size = new Size(193, 23);
            txt_phonenumber.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(657, 394);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frm_registerowner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txt_phonenumber);
            Controls.Add(txt_email);
            Controls.Add(txt_Name);
            Controls.Add(txt_password);
            Controls.Add(txt_username);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frm_registerowner";
            Text = "frm_registerowner";
            Load += frm_registerowner_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_username;
        private TextBox txt_password;
        private TextBox txt_Name;
        private TextBox txt_email;
        private TextBox txt_phonenumber;
        private Button button1;
    }
}