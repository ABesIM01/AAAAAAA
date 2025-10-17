using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth;
using Google.Apis.Util.Store;
using Google.Apis.Util;

namespace WinFormsApp2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Database.Init();
        }

        // === Вхід через email/password ===
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Database.UserExists(email))
            {
                MessageBox.Show("Користувача з таким email не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedInput = Database.HashPassword(password);
            if (!Database.ValidatePassword(email, hashedInput))
            {
                MessageBox.Show("Невірний пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Вхід виконано успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var adminForm = new AdminForm();
            adminForm.FormClosed += (s, args) => this.Close();
            adminForm.Show();
            this.Hide();
        }

        // === Перехід на форму реєстрації ===
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
        }

        // === Google Login через LocalServerCodeReceiver ===

        private async void buttonGoogleLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "74696745247-v3m332f58sdmf1jgohcj0a7v186vh9ja.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var scopes = new[] { "email", "profile", "openid" };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = scopes,
                    DataStore = new FileDataStore("GoogleOAuthToken")
                });

                // ✅ Використовуємо PromptCodeReceiver замість LocalServerCodeReceiver
                var codeReceiver = new PromptCodeReceiver();
                var app = new AuthorizationCodeInstalledApp(flow, codeReceiver);

                var credential = await app.AuthorizeAsync("user", CancellationToken.None);

                if (credential.Token.IsExpired(SystemClock.Default))
                {
                    await credential.RefreshTokenAsync(CancellationToken.None);
                }

                string idToken = credential.Token.IdToken;
                if (string.IsNullOrEmpty(idToken))
                {
                    credential = await app.AuthorizeAsync("user", CancellationToken.None);
                    idToken = credential.Token.IdToken;
                }

                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
                string email = payload.Email;
                string name = payload.Name;

                if (!Database.UserExists(email))
                    Database.AddUser(name ?? email, email, "google_auth");

                MessageBox.Show($"Вітаємо, {name ?? email}!\nВхід через Google успішний.",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var adminForm = new AdminForm();
                adminForm.FormClosed += (s, args) => this.Close();
                adminForm.Show();
                this.Hide();
            }
            catch (TokenResponseException tex)
            {
                MessageBox.Show("Google авторизація відхилена: " + tex.Error.ErrorDescription,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час входу через Google: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    
