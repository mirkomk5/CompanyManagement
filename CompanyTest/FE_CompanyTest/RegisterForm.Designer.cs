namespace FE_CompanyTest
{
    partial class RegisterForm
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
            buttonTogglePass = new Button();
            textBoxPass = new TextBox();
            textBoxEmail = new TextBox();
            mainIcon = new PictureBox();
            buttonRegister = new Button();
            labelLog = new Label();
            textBoxName = new TextBox();
            textBoxSurname = new TextBox();
            ((System.ComponentModel.ISupportInitialize)mainIcon).BeginInit();
            SuspendLayout();
            // 
            // buttonTogglePass
            // 
            buttonTogglePass.BackgroundImage = Properties.Resources.toggle_password;
            buttonTogglePass.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTogglePass.Location = new Point(327, 268);
            buttonTogglePass.Margin = new Padding(3, 2, 3, 2);
            buttonTogglePass.Name = "buttonTogglePass";
            buttonTogglePass.Size = new Size(25, 25);
            buttonTogglePass.TabIndex = 7;
            buttonTogglePass.UseVisualStyleBackColor = true;
            buttonTogglePass.Click += buttonTogglePass_Click;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(40, 268);
            textBoxPass.Margin = new Padding(3, 2, 3, 2);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.PlaceholderText = "Inserisci password...";
            textBoxPass.Size = new Size(246, 23);
            textBoxPass.TabIndex = 6;
            textBoxPass.UseSystemPasswordChar = true;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(40, 232);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Inserisci email...";
            textBoxEmail.Size = new Size(312, 23);
            textBoxEmail.TabIndex = 5;
            // 
            // mainIcon
            // 
            mainIcon.BackgroundImage = Properties.Resources.company_icon;
            mainIcon.BackgroundImageLayout = ImageLayout.Stretch;
            mainIcon.Location = new Point(127, 62);
            mainIcon.Margin = new Padding(3, 2, 3, 2);
            mainIcon.Name = "mainIcon";
            mainIcon.Size = new Size(113, 92);
            mainIcon.TabIndex = 4;
            mainIcon.TabStop = false;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(40, 373);
            buttonRegister.Margin = new Padding(3, 2, 3, 2);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(312, 22);
            buttonRegister.TabIndex = 8;
            buttonRegister.Text = "Registrati";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // labelLog
            // 
            labelLog.ForeColor = Color.IndianRed;
            labelLog.Location = new Point(40, 303);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(312, 44);
            labelLog.TabIndex = 9;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(40, 195);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Nome...";
            textBoxName.Size = new Size(127, 23);
            textBoxName.TabIndex = 10;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(173, 195);
            textBoxSurname.Margin = new Padding(3, 2, 3, 2);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.PlaceholderText = "Cognome...";
            textBoxSurname.Size = new Size(179, 23);
            textBoxSurname.TabIndex = 11;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 449);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            Controls.Add(labelLog);
            Controls.Add(buttonRegister);
            Controls.Add(buttonTogglePass);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxEmail);
            Controls.Add(mainIcon);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)mainIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonTogglePass;
        private TextBox textBoxPass;
        private TextBox textBoxEmail;
        private PictureBox mainIcon;
        private Button buttonRegister;
        private Label labelLog;
        private TextBox textBoxName;
        private TextBox textBoxSurname;
    }
}