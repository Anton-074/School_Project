using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace School
{
    public partial class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        public LoginForm()
        {
            // Инициализация элементов управления
            usernameTextBox = new TextBox { Location = new System.Drawing.Point(15, 15), Width = 200 };
            passwordTextBox = new TextBox { Location = new System.Drawing.Point(15, 50), Width = 200, PasswordChar = '*' };
            loginButton = new Button { Text = "Войти", Location = new System.Drawing.Point(15, 85) };
            // Обработчик события нажатия кнопки
            loginButton.Click += LoginButton_Click;
            // Добавление элементов на форму
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = AuthenticateUser(username, password);
            if (role != null)
            {
                MessageBox.Show("Авторизация успешна!");
                // Открытие соответствующей формы в зависимости от роли
                if (role == "1")
                {
                    FormDelivery adminForm = new FormDelivery();
                    adminForm.Show();
                }
                else if (role == "3")
                {
                    FormDelivery supplierForm = new FormDelivery();
                    supplierForm.buttonNewDelivery.Visible = false;
                    supplierForm.Show();
                }
                this.Hide(); // Скрыть форму авторизации
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }
        private string AuthenticateUser(string username, string password)
        {
            // Строка подключения к базе данных PostgreSQL
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=scholl";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                // SQL-запрос для проверки учетных данных и получения роли
                string query = "SELECT role_id FROM users WHERE username = @username AND password = @password";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password); // В реальном приложении используйте хеширование паролей
                    // Получаем роль пользователя
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null; // Возвращаем роль или null, если не найдено
                }
            }
        }
    }
}
