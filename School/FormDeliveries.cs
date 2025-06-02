using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Reflection;
using System.Windows.Forms;

namespace School
{
    public partial class FormDelivery : Form
    {
        private SchollContext? db;

        private FlowLayoutPanel flowLayoutPanelTop;
        public Button buttonOrder;
        private Button buttonLogout;
        private ComboBox comboBoxSort;

        public FormDelivery()
        {
            InitializeComponent();
            InitializeCustomControls(); // Инициализация верхней панели
            InitializeSortingControls(); // Инициализация элементов управления для сортировки
            GeneratePanel();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void FormDeliveries_Load(object sender, EventArgs e)
        {
            GeneratePanel();
        }
        private void InitializeCustomControls()
        {
            this.BackColor = Color.FromArgb(40, 45, 60);

            // Создаем flowLayoutPanelTop
            flowLayoutPanelTop = new FlowLayoutPanel();
            flowLayoutPanelTop.Dock = DockStyle.Top;
            flowLayoutPanelTop.Size = new Size(750, 300);
            flowLayoutPanelTop.Location = new Point(15, 20);
            flowLayoutPanelTop.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelTop.WrapContents = false;
            flowLayoutPanelTop.AutoSize = true;
            flowLayoutPanelTop.BorderStyle = BorderStyle.FixedSingle ;
            flowLayoutPanelTop.BackColor = Color.LightGray;
            // Создаем кнопку "Оформить заказ"
            buttonOrder = new Button();
            buttonOrder.Text = "Оформить заказ";
            buttonOrder.Size = new Size(350, 80);
            buttonOrder.Margin = new Padding(5, 5, 5, 5);
            buttonOrder.BackColor = Color.FromArgb(0, 122, 204);
            buttonOrder.ForeColor = Color.White;
            buttonOrder.FlatStyle = FlatStyle.Flat;
            buttonOrder.Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold);
            buttonOrder.FlatAppearance.BorderSize = 0; // Remove border
            buttonOrder.Click += buttonNewDelivery_Click; // Используем уже существующий обработчик
            // Создаем кнопку "Выход с аккаута"
            buttonLogout = new Button();
            buttonLogout.Text = "Выход с аккаута";
            buttonLogout.Size = new Size(150, 80);
            buttonLogout.Margin = new Padding(5, 5, 5, 5);
            buttonLogout.BackColor = Color.FromArgb(0, 122, 204);
            buttonLogout.ForeColor = Color.White; // Button color
            buttonLogout.FlatStyle = FlatStyle.Flat; // Flat style for modern look
            buttonLogout.Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold);
            buttonLogout.FlatAppearance.BorderSize = 0; // Remove border
            buttonLogout.Click += buttonExit_Click; // Используем уже существующий обработчик
            if(LoginForm.role != "3")
            {
                flowLayoutPanelTop.Controls.Add(buttonOrder);
            }
            
            
            flowLayoutPanelTop.Controls.Add(buttonLogout);
            
            

            // Добавляем flowLayoutPanelTop на форму
            this.Controls.Add(flowLayoutPanelTop);

            
        }

        private void InitializeSortingControls()
        {
            // Создаем ComboBox для выбора критерия сортировки
            comboBoxSort = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 300
                
            };
            
            comboBoxSort.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            comboBoxSort.Items.Add("Сортировать по дате заказа");
            comboBoxSort.Items.Add("Сортировать по имени поставщика");
            comboBoxSort.Items.Add("Сортировать по названию организации");
            comboBoxSort.Items.Add("Сортировать по статусу");
            comboBoxSort.SelectedIndexChanged += (s, e) => SortPanels(comboBoxSort.SelectedIndex);
            flowLayoutPanelTop.Controls.Add(comboBoxSort);


        }
        public void GeneratePanel()
        {
            this.db = new SchollContext();
            List<Delivery> deliveries;
            if (LoginForm.role == "3")
            {
                 deliveries = db.Deliveries.Include(i => i.Supplier).Where(w => w.Supplier.UserId == LoginForm.user).ToList();
            }
            else
            {
                 deliveries = db.Deliveries.ToList();
            }
            
             
            


            int yOffset = 120;
            foreach (Delivery del in deliveries)
            {
                var supplier = this.db.Suppliers.Where(w => w.SupplierId == del.SupplierId).FirstOrDefault();
                var typeSupply = this.db.TypeSuppliers.Where(w => w.TypeSupplierId == supplier.TypeSupplierId).FirstOrDefault();
                var schoolNumber = this.db.Schools.Where(w => w.SchoolId == del.SchoolId).FirstOrDefault();
                var assemb = this.db.Assemblies.Where(w => w.AssemblyId == del.AssemblyId).FirstOrDefault();
                var statuse = this.db.Statuses.Where(w => w.StatusId == del.StatusId).FirstOrDefault();

                Panel supplierPanel = new Panel
                {
                    Size = new System.Drawing.Size(770, 140),
                    Location = new System.Drawing.Point(15, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White, // Background color for the delivery panel
                    Tag = $"{del.DeliveryId},{supplier.SupplierId},{assemb.AssemblyId},{schoolNumber.SchoolId},{statuse.StatusId}"
                };
                Panel rightPanel = new Panel
                {
                    Size = new System.Drawing.Size(250, 140),
                    Dock = DockStyle.Right,
                    //BorderStyle = BorderStyle.FixedSingle
                };
                supplierPanel.MouseDown += panelLabel_MouseDown;
                //supplierPanel.MouseDown += panelLabel_MouseDown;
                Label supplierLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(250, 30),
                    Dock = DockStyle.Bottom,
                    Text = $" Поставщик: {typeSupply.TypeSupplierName} {supplier.SupplierName}",
                    TextAlign = ContentAlignment.BottomRight
                };
                supplierLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                Label statuseLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(250, 30),
                    Dock = DockStyle.Top,
                    Text = $" Статус:{statuse.StatusName}",
                    TextAlign = ContentAlignment.BottomRight
                };
                statuseLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                Label assemblyLabel = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Left,
                    Size = new System.Drawing.Size(250, 140),
                    TextAlign = ContentAlignment.MiddleLeft,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Text = $"Заказ: \nКомпьютер\nСерийный номер {del.AssemblyId}\n{schoolNumber.SchoolName}\n{del.DeliveryDate}"
                };

                //----------------
                Button threeDotsButton = new Button
                {
                    Text = "...",
                    Size = new System.Drawing.Size(30, 30),
                    Dock = DockStyle.Right,
                    Location = new System.Drawing.Point(supplierPanel.Width - 40, 5) // Позиция в правом верхнем углу
                };
                threeDotsButton.Click += (s, e) => ShowContextMenu(threeDotsButton, del);
                threeDotsButton.Click += panelLabel_MouseDown;
                threeDotsButton.Tag = supplierPanel;
                //-----------------
                assemblyLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                supplierPanel.Controls.Add(assemblyLabel);
                rightPanel.Controls.Add(supplierLabel);
                rightPanel.Controls.Add(statuseLabel);
                //rightPanel.Controls.Add(threeDotsButton);
                supplierPanel.Controls.Add(rightPanel);
                //----
                
                supplierPanel.Controls.Add(threeDotsButton); // Добавляем кнопку на панель
                //----
                this.Controls.Add(supplierPanel);
                yOffset += supplierPanel.Height + 30;
            }
        }
        private void GeneratePanel(List<Delivery> deliveries)
        {
            int yOffset = 120;
            foreach (Delivery del in deliveries)
            {
                // Создание панелей и добавление их на форму (как в предыдущем примере)
                // ...
                var supplier = this.db.Suppliers.Where(w => w.SupplierId == del.SupplierId).FirstOrDefault();
                var typeSupply = this.db.TypeSuppliers.Where(w => w.TypeSupplierId == supplier.TypeSupplierId).FirstOrDefault();
                var schoolNumber = this.db.Schools.Where(w => w.SchoolId == del.SchoolId).FirstOrDefault();
                var assemb = this.db.Assemblies.Where(w => w.AssemblyId == del.AssemblyId).FirstOrDefault();
                var statuse = this.db.Statuses.Where(w => w.StatusId == del.StatusId).FirstOrDefault();

                Panel supplierPanel = new Panel
                {
                    Size = new System.Drawing.Size(770, 140),
                    Location = new System.Drawing.Point(15, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Tag = $"{del.DeliveryId},{supplier.SupplierId},{assemb.AssemblyId},{schoolNumber.SchoolId},{statuse.StatusId}"
                };
                Panel rightPanel = new Panel
                {
                    Size = new System.Drawing.Size(250, 140),
                    Dock = DockStyle.Right,
                    //BorderStyle = BorderStyle.FixedSingle
                };
                supplierPanel.MouseDown += panelLabel_MouseDown;
                //supplierPanel.MouseDown += panelLabel_MouseDown;
                Label supplierLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(250, 30),
                    Dock = DockStyle.Bottom,
                    Text = $" Поставщик: {typeSupply.TypeSupplierName} {supplier.SupplierName}",
                    TextAlign = ContentAlignment.BottomRight
                };
                supplierLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                Label statuseLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(250, 30),
                    Dock = DockStyle.Top,
                    Text = $" Статус:{statuse.StatusName}",
                    TextAlign = ContentAlignment.BottomRight
                };
                statuseLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                Label assemblyLabel = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Left,
                    Size = new System.Drawing.Size(250, 140),
                    TextAlign = ContentAlignment.MiddleLeft,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Text = $"Заказ: \nКомпьютер\nСерийный номер {del.AssemblyId}\n{schoolNumber.SchoolName}\n{del.DeliveryDate}"
                };

                //----------------
                Button threeDotsButton = new Button
                {
                    Text = "...",
                    Size = new System.Drawing.Size(30, 30),
                    Dock = DockStyle.Right,
                    Location = new System.Drawing.Point(supplierPanel.Width - 40, 5) // Позиция в правом верхнем углу
                };
                threeDotsButton.Click += (s, e) => ShowContextMenu(threeDotsButton, del);
                threeDotsButton.Click += panelLabel_MouseDown;
                threeDotsButton.Tag = supplierPanel;
                //-----------------
                assemblyLabel.Font = new Font("Arial", 12, FontStyle.Regular);

                supplierPanel.Controls.Add(assemblyLabel);
                rightPanel.Controls.Add(supplierLabel);
                rightPanel.Controls.Add(statuseLabel);
                //rightPanel.Controls.Add(threeDotsButton);
                supplierPanel.Controls.Add(rightPanel);
                //----

                supplierPanel.Controls.Add(threeDotsButton); // Добавляем кнопку на панель
                //----
                this.Controls.Add(supplierPanel);
                yOffset += supplierPanel.Height + 30;
            }
        }

        private void SortPanels(int sortOption)
        {
            // Удаляем все панели перед сортировкой
            this.Controls.Clear();
            InitializeSortingControls(); // Снова добавляем элементы управления для сортировки
            var deliveries = db.Deliveries.ToList();
            // Сортировка по выбранному критерию
            if (sortOption == 0) // Сортировка по дате доставки
            {
                deliveries = deliveries.OrderBy(o => o.DeliveryDate).ToList();
            }
            else if (sortOption == 1) // Сортировка по имени поставщика
            {
                deliveries = deliveries.OrderBy(o => this.db.Suppliers.FirstOrDefault(s => s.SupplierId == o.SupplierId).SupplierName).ToList();
            }
            else if (sortOption == 2)
            {
                deliveries = deliveries.OrderBy(o => this.db.Schools.FirstOrDefault(s => s.SchoolId == o.SchoolId).SchoolName).ToList();
            }
            else if (sortOption == 3)
            {
                deliveries = deliveries.OrderBy(o => this.db.Statuses.FirstOrDefault(s => s.StatusId == o.StatusId).StatusName).ToList();
            }
            // Генерируем панели после сортировки
            InitializeCustomControls();
            InitializeSortingControls();
            GeneratePanel(deliveries);
        }
        
        private void ShowContextMenu(Control control, Delivery del)
        {

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            if(LoginForm.role=="1")
            {
                contextMenu.Items.Add("Редактировать заказ", null, MenuEdit_Click);
                contextMenu.Items.Add("Удалить заказ", null, MenuDelete_Click);
                contextMenu.Items.Add("Подробнее о поставщике", null, MenuShowSupplier_Click);
            }
            else if (LoginForm.role == "3")
            {
                contextMenu.Items.Add("Изменить статус заказа", null, MenuEditStatuse_Click);
            }
            contextMenu.Items.Add("Подробнее о сборке", null, MenuShowAssembly_Click);
            contextMenu.Show(control, new Point(0, control.Height));
        }
        private void buttonNewDelivery_Click(object sender, EventArgs e)
        {
            FormEditDelivery form = new FormEditDelivery();

            int indexSupply = -1;
            int indexAssembly = -1;
            int indexSchool = -1;


            var supply = this.db.Suppliers.OrderBy(o => o.SupplierName).ToList();
            var assemb = this.db.Assemblies.OrderBy(o => o.AssemblyId).ToList();
            var school = this.db.Schools.OrderBy(o => o.SchoolName).ToList();



            foreach (Supplier u in supply)
            {
                form.comboBoxSupply.Items.Add(u.SupplierName);
            }
            foreach (Assemblys u in assemb)
            {
                form.comboBoxAssembly.Items.Add(u.AssemblyId);
            }

            foreach (Schools u in school)
            {
                form.comboBoxSchool.Items.Add(u.SchoolName);
            }

            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            foreach (Supplier u in supply)
            {
                if (u.SupplierName == form.comboBoxSupply.Text)
                {
                    indexSupply = u.SupplierId;
                }
            }
            foreach (Assemblys u in assemb)
            {
                if (u.AssemblyId == Int32.Parse(form.comboBoxAssembly.Text))
                {
                    indexAssembly = u.AssemblyId;
                }
            }
            foreach (Schools u in school)
            {
                if (u.SchoolName == form.comboBoxSchool.Text)
                {
                    indexSchool = u.SchoolId;
                }
            }

            Delivery delivery = new Delivery
            {

                SupplierId = indexSupply,
                AssemblyId = indexAssembly,
                SchoolId = indexSchool,
                StatusId = 1
            };
            db.Deliveries.Add(delivery);
            db.SaveChanges();

            this.Hide();
            LoginForm.CreateAdmin();
        }

        public void panelLabel_MouseDown(object sender, EventArgs e)
        {

            /*Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                contextMenuStrip.Tag = clickedPanel; // Сохраняем ссылку на панель
                contextMenuStrip.Show(clickedPanel, e.Location);
            }*/

            Button clickedPanel = sender as Button;
            if (clickedPanel != null)
            {
                contextMenuStrip.Tag = clickedPanel.Tag; // Сохраняем ссылку на панель
                ;
            }

        }

        public void MenuEdit_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = contextMenuStrip.Tag as Panel; // Получаем панель из Tag
            if (clickedPanel != null)
            {
                int index = -1;

                int countSupply = 0;
                int countAssembly = 0;
                int countSchool = 0;

                int indexSupply = -1;
                int indexAssembly = -1;
                int indexSchool = -1;

                var del = this.db.Deliveries.OrderBy(o => o.DeliveryDate).ToList();
                var supply = this.db.Suppliers.OrderBy(o => o.SupplierName).ToList();
                var assemb = this.db.Assemblies.OrderBy(o => o.AssemblyId).ToList();
                var school = this.db.Schools.OrderBy(o => o.SchoolName).ToList();



                string splits = (string)clickedPanel.Tag;
                string[] Ids = splits.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int delivaryId = Int32.Parse(Ids[0]);
                int supplierId = Int32.Parse(Ids[1]);
                int assemblyId = Int32.Parse(Ids[2]);
                int schoolId = Int32.Parse(Ids[3]);


                Delivery delivary = db.Deliveries.Find(delivaryId);
                Supplier supplier = db.Suppliers.Find(supplierId);
                Assemblys assembly = db.Assemblies.Find(assemblyId);
                Schools schools = db.Schools.Find(schoolId);




                FormEditDelivery form = new();

                //Поставщик 
                foreach (Supplier u in supply)
                {
                    form.comboBoxSupply.Items.Add(u.SupplierName);

                    if (u.SupplierName == supplier.SupplierName)
                    {
                        index = countSupply;
                        indexSupply = u.SupplierId;
                    }
                    countSupply++;
                }
                form.comboBoxSupply.SelectedIndex = index;

                //Сборка
                foreach (Assemblys u in assemb)
                {
                    form.comboBoxAssembly.Items.Add(u.AssemblyId);

                    if (u.AssemblyId == assembly.AssemblyId)
                    {
                        index = countAssembly;
                        indexAssembly = u.AssemblyId;
                    }
                    countAssembly++;
                }
                form.comboBoxAssembly.SelectedIndex = index;

                //Школа
                foreach (Schools u in school)
                {
                    form.comboBoxSchool.Items.Add(u.SchoolName);

                    if (u.SchoolName == schools.SchoolName)
                    {
                        index = countSchool;
                        indexSchool = u.SchoolId;
                    }
                    countSchool++;
                }
                form.comboBoxSchool.SelectedIndex = index;
                //================================================

                DialogResult result = form.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                foreach (Supplier u in supply)
                {
                    if (u.SupplierName == form.comboBoxSupply.Text)
                    {
                        indexSupply = u.SupplierId;
                    }
                }
                foreach (Assemblys u in assemb)
                {
                    if (u.AssemblyId == Int32.Parse(form.comboBoxAssembly.Text))
                    {
                        indexAssembly = u.AssemblyId;
                    }
                }
                foreach (Schools u in school)
                {
                    if (u.SchoolName == form.comboBoxSchool.Text)
                    {
                        indexSchool = u.SchoolId;
                    }
                }

                delivary.SupplierId = indexSupply;
                delivary.AssemblyId = indexAssembly;
                delivary.SchoolId = indexSchool;

                db.SaveChanges();

                this.Hide();
                LoginForm.CreateAdmin();
            }
        }
        public void MenuShowSupplier_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = contextMenuStrip.Tag as Panel; // Получаем панель из Tag
            if (clickedPanel != null)
            {
                string splits = (string)clickedPanel.Tag;
                string[] Ids = splits.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int supplierId = Int32.Parse(Ids[1]);

                FormSupplier supplier = new FormSupplier(supplierId);
                supplier.Show();
            }
        }
        public void MenuDelete_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = contextMenuStrip.Tag as Panel; // Получаем панель из Tag
            if (clickedPanel != null)
            {
                DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить объект?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                string splits = (string)clickedPanel.Tag;
                string[] Ids = splits.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int delivaryId = Int32.Parse(Ids[0]);

                Delivery delivery = db.Deliveries.Find(delivaryId);

                db.Deliveries.Remove(delivery);
                db.SaveChanges();
                this.Hide();
                LoginForm.CreateAdmin();
            }
        }
        public void MenuShowAssembly_Click(object sender, EventArgs e)
        {

        }

        public void MenuEditStatuse_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = contextMenuStrip.Tag as Panel; // Получаем панель из Tag
            if (clickedPanel != null)
            {
                int index = -1;


                int count = 0;

                int indexStatuse = -1;

                var del = this.db.Deliveries.OrderBy(o => o.DeliveryDate).ToList();
                var stat = db.Statuses.OrderBy(o => o.StatusId).ToList();

                string splits = (string)clickedPanel.Tag;
                string[] Ids = splits.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int delivaryId = Int32.Parse(Ids[0]);
                int statusId = Int32.Parse(Ids[4]);

                Delivery delivary = db.Deliveries.Find(delivaryId);
                Status status = db.Statuses.Find(statusId);

                FormEditStatuse form = new();

                //Статус 
                foreach (Status u in stat)
                {
                    form.comboBoxStatuse.Items.Add(u.StatusName);

                    if (u.StatusName == status.StatusName)
                    {
                        index = count;
                        indexStatuse = u.StatusId;
                    }
                    count++;
                }
                form.comboBoxStatuse.SelectedIndex = index;


                DialogResult result = form.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                foreach (Status u in stat)
                {
                    if (u.StatusName == form.comboBoxStatuse.Text)
                    {
                        index = u.StatusId;
                    }
                }

                delivary.StatusId = index;

                db.SaveChanges();

                this.Hide();
                LoginForm.CreateSupplier();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
