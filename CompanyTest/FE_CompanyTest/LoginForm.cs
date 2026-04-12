using DTO_CompanyTest;
using FE_CompanyTest.Services;

namespace FE_CompanyTest
{
    public partial class LoginForm : Form
    {
        private bool _passIsVisible = false;

        public LoginForm()
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
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!IsFieldFilled()) return;

            DTO_AuthRequest dto_Auth = new DTO_AuthRequest()
            {
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text
            };

            AuthService authService = new AuthService();
            var result = await authService.LoginAsync(dto_Auth);

            labelLog.ForeColor = result.Success == true ? Color.Blue : Color.IndianRed;
            labelLog.Text = result.Message;

            if (result.Success == false) return;

            // Show Home dialog
            this.Hide();
            Home homeDialog = new Home();
            homeDialog.ShowDialog();
        }

        #region Internal Methods

        /// <summary>
        /// Controlla se tutti i campi richiesti sono stati compilati
        /// </summary>
        /// <returns></returns>
        public bool IsFieldFilled()
        {
            if(string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPass.Text))
            {
                labelLog.ForeColor = Color.IndianRed;
                labelLog.Text = "Email o password non inserita.";
                return false;
            }
            return true;
        }

        #endregion
    }
}
