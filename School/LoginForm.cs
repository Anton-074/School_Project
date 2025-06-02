using Npgsql;
using School.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace School
{
    public partial class LoginForm : Form
    {
        private SchollContext? db;

        private Label titleLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button closeButton;

        public static string role = null;
        public static int user = -1;
        public LoginForm()
        {
            // Настройки формы
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Убираем возможность изменения размера
            this.MaximizeBox = false; // Убираем кнопку разворачивания
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.Text = "Авторизация";
            this.ClientSize = new Size(350, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(40, 45, 60);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            // Заголовок
            titleLabel = new Label();
            titleLabel.Text = "Вход в систему";
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 2, 20);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            /*closeButton = new Button();
            //closeButton.Text = "✖"; // Символ крестика
            closeButton.Text = "X";
            closeButton.Size = new Size(40, 40);
             // Расположение справа от заголовка
            closeButton.BackColor = Color.Transparent;
            closeButton.ForeColor = Color.White;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            closeButton.Click += CloseButton_Click; // Подписка на событие клика*/


            // Метка "Имя пользователя"
            usernameLabel = new Label();
            usernameLabel.Text = "Имя пользователя:";
            usernameLabel.ForeColor = Color.WhiteSmoke;
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(40, 70);
            // Текстбокс для имени пользователя
            usernameTextBox = new TextBox();
            usernameTextBox.Location = new Point(40, 95);
            usernameTextBox.Width = 270;
            usernameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            usernameTextBox.ForeColor = Color.FromArgb(30, 30, 30);

            // Метка "Пароль"
            passwordLabel = new Label();
            passwordLabel.Text = "Пароль:";
            passwordLabel.ForeColor = Color.WhiteSmoke;
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(40, 135);
            // Текстбокс для пароля
            passwordTextBox = new TextBox();
            passwordTextBox.Location = new Point(40, 160);
            passwordTextBox.Width = 270;
            passwordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            passwordTextBox.ForeColor = Color.FromArgb(30, 30, 30);
            passwordTextBox.PasswordChar = '●';
            // Кнопка "Войти"
            loginButton = new Button();
            loginButton.Text = "Войти";
            loginButton.Location = new Point(40, 200);
            loginButton.Size = new Size(270, 40);
            loginButton.BackColor = Color.FromArgb(0, 122, 204);
            loginButton.ForeColor = Color.White;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            loginButton.Cursor = Cursors.Hand;
            loginButton.Click += LoginButton_Click;

            // Добавление элементов на форму
            Controls.Add(titleLabel);
            Controls.Add(closeButton);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);

            // Центрирование заголовка после добавления на форму
            titleLabel.Left = (this.ClientSize.Width - titleLabel.Width) / 2;
            //closeButton.Location = new Point(titleLabel.Right + 30, 20);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Завершение работы приложения
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.db = new SchollContext();
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            user = Int32.Parse(AuthenticateUser(username, password));
            if (user != -1)
            {
                //MessageBox.Show("Авторизация успешна!");
                // Открытие соответствующей формы в зависимости от роли
                role = (db.Users.Where(w => w.UserId == user).Select(s => s.RoleId).FirstOrDefault()).ToString();
                if (role == "1")
                {
                    CreateAdmin();
                }
                else if (role == "3")
                {
                    CreateSupplier();
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
                string query = "SELECT user_id FROM users WHERE username = @username AND password = @password";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password); // В реальном приложении используйте хеширование паролей
                    // Получаем роль пользователя
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "-1"; // Возвращаем роль или null, если не найдено
                }
            }
        }

        public static void CreateAdmin()
        {
            FormDelivery adminForm = new FormDelivery();
            adminForm.contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuEdit = new ToolStripMenuItem("Редактировать заказ");
            ToolStripMenuItem menuShowSupplier = new ToolStripMenuItem("Подробнее о поставщике");
            ToolStripMenuItem menuShowAssembly = new ToolStripMenuItem("Подробнее о сборке");
            menuEdit.Click += adminForm.MenuEdit_Click; // Подписка на событие клика
            menuShowSupplier.Click += adminForm.MenuShowSupplier_Click;
            menuShowAssembly.Click += adminForm.MenuShowAssembly_Click;
            adminForm.contextMenuStrip.Items.Add(menuEdit);
            adminForm.contextMenuStrip.Items.Add(menuShowSupplier);
            adminForm.contextMenuStrip.Items.Add(menuShowAssembly);
            adminForm.Show();
        }
        public static void CreateSupplier()
        {
            FormDelivery supplierForm = new FormDelivery();

            supplierForm.contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuEditStatuse = new ToolStripMenuItem("Изменить статус");
            ToolStripMenuItem menuShowAssembly = new ToolStripMenuItem("Подробнее о сборке");
            menuEditStatuse.Click += supplierForm.MenuEditStatuse_Click;
            supplierForm.contextMenuStrip.Items.Add(menuEditStatuse);
            supplierForm.Show();//Доделать что бы форма возвращалась
        }
    }
}
