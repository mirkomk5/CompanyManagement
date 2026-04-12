using DTO_CompanyTest;
using FE_CompanyTest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_CompanyTest
{
    public partial class RegisterForm : Form
    {
        private bool _passIsVisible = false;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonTogglePass_Click(object sender, EventArgs e)
        {
            _passIsVisible = !_passIsVisible;
            textBoxPass.UseSystemPasswordChar = !_passIsVisible;
            buttonTogglePass.Image = _passIsVisible ? Properties.Resources.pass_hide : Properties.Resources.toggle_password;
            buttonTogglePass.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            if (!IsFieldFilled()) return;

            DTO_RegisterRequest dto_Register = new DTO_RegisterRequest()
            {
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text,
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text
            };

            AuthService authService = new AuthService();
            var result = await authService.RegisterAsync(dto_Register);

            labelLog.ForeColor = result.Success == true ? Color.Blue : Color.IndianRed;
            labelLog.Text = result.Message;

            if (result.Success == false) return;

            // Show Home dialog
            this.Hide();
            Home homeDialog = new Home();
            homeDialog.ShowDialog();
        }


        public bool IsFieldFilled()
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPass.Text))
            {
                labelLog.ForeColor = Color.IndianRed;
                labelLog.Text = "Email o password non inserita.";
                return false;
            }
            return true;
        }
    }
}
