
using DTO_CompanyTest;
using FE_CompanyTest.Services;

namespace FE_CompanyTest
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainIcon = new PictureBox();
            textBoxEmail = new TextBox();
            textBoxPass = new TextBox();
            buttonTogglePass = new Button();
            buttonLogin = new Button();
            buttonRegister = new Button();
            labelLog = new Label();
            ((System.ComponentModel.ISupportInitialize)mainIcon).BeginInit();
            SuspendLayout();
            // 
            // mainIcon
            // 
            mainIcon.BackgroundImage = Properties.Resources.company_icon;
            mainIcon.BackgroundImageLayout = ImageLayout.Stretch;
            mainIcon.Location = new Point(116, 50);
            mainIcon.Margin = new Padding(3, 2, 3, 2);
            mainIcon.Name = "mainIcon";
            mainIcon.Size = new Size(113, 92);
            mainIcon.TabIndex = 0;
            mainIcon.TabStop = false;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(66, 178);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Inserisci email...";
            textBoxEmail.Size = new Size(208, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(66, 214);
            textBoxPass.Margin = new Padding(3, 2, 3, 2);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.PlaceholderText = "Inserisci password...";
            textBoxPass.Size = new Size(208, 23);
            textBoxPass.TabIndex = 2;
            textBoxPass.UseSystemPasswordChar = true;
            // 
            // buttonTogglePass
            // 
            buttonTogglePass.BackgroundImage = Properties.Resources.toggle_password;
            buttonTogglePass.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTogglePass.Location = new Point(270, 212);
            buttonTogglePass.Margin = new Padding(3, 2, 3, 2);
            buttonTogglePass.Name = "buttonTogglePass";
            buttonTogglePass.Size = new Size(25, 25);
            buttonTogglePass.TabIndex = 3;
            buttonTogglePass.UseVisualStyleBackColor = true;
            buttonTogglePass.Click += buttonTogglePass_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(66, 290);
            buttonLogin.Margin = new Padding(3, 2, 3, 2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(207, 22);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(66, 316);
            buttonRegister.Margin = new Padding(3, 2, 3, 2);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(207, 22);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // labelLog
            // 
            labelLog.ForeColor = Color.IndianRed;
            labelLog.Location = new Point(66, 248);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(204, 29);
            labelLog.TabIndex = 6;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(352, 382);
            Controls.Add(labelLog);
            Controls.Add(buttonRegister);
            Controls.Add(buttonLogin);
            Controls.Add(buttonTogglePass);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxEmail);
            Controls.Add(mainIcon);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)mainIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        

        #endregion

        private PictureBox mainIcon;
        private TextBox textBoxEmail;
        private TextBox textBoxPass;
        private Button buttonTogglePass;
        private Button buttonLogin;
        private Button buttonRegister;
        private Label labelLog;
    }
}
