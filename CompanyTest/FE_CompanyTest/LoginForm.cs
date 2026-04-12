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
            if (!IsFieldFilled()) return;

            DTO_RegisterRequest dto_Register = new DTO_RegisterRequest()
            {
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text,
                Name = "Testoh",
                Surname = "Testone"
            };

            AuthService authService = new AuthService();
            var result = await authService.RegisterAsync(dto_Register);

            labelLog.ForeColor = result.Success == true ? Color.Blue : Color.IndianRed;
            labelLog.Text = result.Message;
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
