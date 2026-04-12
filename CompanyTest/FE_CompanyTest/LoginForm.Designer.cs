
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
            mainIcon.Location = new Point(132, 66);
            mainIcon.Name = "mainIcon";
            mainIcon.Size = new Size(129, 122);
            mainIcon.TabIndex = 0;
            mainIcon.TabStop = false;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(76, 238);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Inserisci email...";
            textBoxEmail.Size = new Size(237, 27);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(76, 285);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.PlaceholderText = "Inserisci password...";
            textBoxPass.Size = new Size(237, 27);
            textBoxPass.TabIndex = 2;
            textBoxPass.UseSystemPasswordChar = true;
            // 
            // buttonTogglePass
            // 
            buttonTogglePass.Location = new Point(308, 283);
            buttonTogglePass.Name = "buttonTogglePass";
            buttonTogglePass.Size = new Size(29, 29);
            buttonTogglePass.TabIndex = 3;
            buttonTogglePass.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(76, 387);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(237, 29);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(76, 422);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(237, 29);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // labelLog
            // 
            labelLog.ForeColor = Color.IndianRed;
            labelLog.Location = new Point(76, 330);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(233, 39);
            labelLog.TabIndex = 6;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(402, 510);
            Controls.Add(labelLog);
            Controls.Add(buttonRegister);
            Controls.Add(buttonLogin);
            Controls.Add(buttonTogglePass);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxEmail);
            Controls.Add(mainIcon);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)mainIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            DTO_AuthRequest dto_Auth = new DTO_AuthRequest()
            {
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text
            };

            AuthService authService = new AuthService();
            var result = await authService.LoginAsync(dto_Auth);

            if(result == null)
            {
                labelLog.ForeColor = Color.IndianRed;
                labelLog.Text = "Login fallito. Controlla email e password.";
                return;
            }

            labelLog.ForeColor = Color.Blue;
            labelLog.Text = "Login riuscito!";
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
