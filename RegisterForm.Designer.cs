using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTitle;
        private Guna2TextBox textBoxUsername;
        private Guna2TextBox textBoxEmail;
        private Guna2TextBox textBoxPassword;
        private Guna2Button buttonRegister;
        private Guna2CircleButton buttonBack;
        private Guna2Elipse elipse;
        private Guna2ShadowForm shadowForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            labelTitle = new Label();
            textBoxUsername = new Guna2TextBox();
            textBoxEmail = new Guna2TextBox();
            textBoxPassword = new Guna2TextBox();
            buttonRegister = new Guna2Button();
            buttonBack = new Guna2CircleButton();
            elipse = new Guna2Elipse(components);
            shadowForm = new Guna2ShadowForm(components);
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(45, 45, 48);
            labelTitle.Location = new Point(282, 50);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(222, 54);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Реєстрація";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderRadius = 12;
            textBoxUsername.CustomizableEdges = customizableEdges1;
            textBoxUsername.DefaultText = "";
            textBoxUsername.Font = new Font("Segoe UI", 10F);
            textBoxUsername.Location = new Point(282, 140);
            textBoxUsername.Margin = new Padding(3, 4, 3, 4);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Ім'я користувача";
            textBoxUsername.SelectedText = "";
            textBoxUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            textBoxUsername.Size = new Size(340, 50);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderRadius = 12;
            textBoxEmail.CustomizableEdges = customizableEdges3;
            textBoxEmail.DefaultText = "";
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(282, 210);
            textBoxEmail.Margin = new Padding(3, 4, 3, 4);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.SelectedText = "";
            textBoxEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            textBoxEmail.Size = new Size(340, 50);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderRadius = 12;
            textBoxPassword.CustomizableEdges = customizableEdges5;
            textBoxPassword.DefaultText = "";
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(282, 280);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.SelectedText = "";
            textBoxPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            textBoxPassword.Size = new Size(340, 50);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonRegister
            // 
            buttonRegister.BorderRadius = 12;
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.CustomizableEdges = customizableEdges7;
            buttonRegister.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.HoverState.FillColor = Color.FromArgb(74, 128, 235);
            buttonRegister.Location = new Point(282, 360);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.ShadowDecoration.CustomizableEdges = customizableEdges8;
            buttonRegister.Size = new Size(340, 55);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Зареєструватися";
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonBack
            // 
            buttonBack.Cursor = Cursors.Hand;
            buttonBack.FillColor = Color.White;
            buttonBack.Font = new Font("Segoe UI", 9F);
            buttonBack.ForeColor = Color.White;
            buttonBack.HoverState.FillColor = Color.FromArgb(240, 240, 240);
            buttonBack.Location = new Point(15, 15);
            buttonBack.Name = "buttonBack";
            buttonBack.ShadowDecoration.CustomizableEdges = customizableEdges9;
            buttonBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            buttonBack.Size = new Size(40, 40);
            buttonBack.TabIndex = 0;
            buttonBack.Click += buttonBack_Click;
            // 
            // elipse
            // 
            elipse.BorderRadius = 20;
            elipse.TargetControl = this;
            // 
            // shadowForm
            // 
            shadowForm.TargetForm = this;
            // 
            // RegisterForm
            // 
            BackColor = Color.FromArgb(250, 251, 253);
            ClientSize = new Size(861, 550);
            Controls.Add(buttonBack);
            Controls.Add(labelTitle);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Реєстрація";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
