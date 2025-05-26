using School.Models;
using System.Reflection;
using System.Windows.Forms;

namespace School
{
    public partial class FormDelivery : Form
    {
        private SchollContext? db;
        public FormDelivery()
        {
            InitializeComponent();
            GeneratePanel();
            contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuEdit = new ToolStripMenuItem("Редактировать заказ");
            ToolStripMenuItem menuShowSupplier = new ToolStripMenuItem("Подробнее о поставщике");
            ToolStripMenuItem menuShowAssembly = new ToolStripMenuItem("Подробнее о сборке");
            menuEdit.Click += MenuEdit_Click; // Подписка на событие клика
            menuShowSupplier.Click += MenuShowSupplier_Click;
            menuShowAssembly.Click += MenuShowAssembly_Click;
            contextMenuStrip.Items.Add(menuEdit);
            contextMenuStrip.Items.Add(menuShowSupplier);
            contextMenuStrip.Items.Add(menuShowAssembly);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void FormDeliveries_Load(object sender, EventArgs e)
        {
            GeneratePanel();
        }
        public void GeneratePanel()
        {
            this.db = new SchollContext();

            var deliveries = db.Deliveries.OrderBy(o => o.DeliveryDate).ToList();

            int yOffset = 70;
            foreach (Delivery del in deliveries)
            {
                var supplier = this.db.Suppliers.Where(w=>w.SupplierId == del.SupplierId).FirstOrDefault();
                var typeSupply = this.db.TypeSuppliers.Where(w => w.TypeSupplierId == supplier.TypeSupplierId).FirstOrDefault();
                var schoolNumber = this.db.Schools.Where(w=>w.SchoolId == del.SchoolId).FirstOrDefault();
                var assemb = this.db.Assemblies.Where(w => w.AssemblyId == del.AssemblyId).FirstOrDefault();

                Panel supplierPanel = new Panel
                {
                    Size = new System.Drawing.Size(770, 100),
                    Location = new System.Drawing.Point(15, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = $"{del.DeliveryId},{supplier.SupplierId},{assemb.AssemblyId},{schoolNumber.SchoolId}"
                };

                supplierPanel.MouseDown += panelLabel_MouseDown;
                //supplierPanel.MouseDown += panelLabel_MouseDown;
                Label supplierLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(200, 80),
                    Dock = DockStyle.Right,
                    Text = $" Поставщик: {typeSupply.TypeSupplierName} {supplier.SupplierName}",
                    TextAlign = ContentAlignment.BottomRight,
                    BorderStyle = BorderStyle.FixedSingle
                };
                supplierLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                Label assemblyLabel = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Left,
                    Size = new System.Drawing.Size(200, 80),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = $"Заказ: \nКомпьютер\nСерийный номер {del.AssemblyId}\n{schoolNumber.SchoolName}\n{del.DeliveryDate}"
                };
                assemblyLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                supplierPanel.Controls.Add(assemblyLabel);
                supplierPanel.Controls.Add(supplierLabel);
                
                this.Controls.Add(supplierPanel);
                yOffset += supplierLabel.Height + 30;
            }
        }
        private void buttonNewDelivery_Click(object sender, EventArgs e)
        {
            FormEditDelivery form = new FormEditDelivery();

            int indexSupply = -1;
            int indexAssembly = -1;
            int indexSchool = -1;


            var supply = this.db.Suppliers.OrderBy(o=>o.SupplierName).ToList();
            var assemb = this.db.Assemblies.OrderBy(o=>o.AssemblyId).ToList();
            var school = this.db.Schools.OrderBy(o => o.SchoolName).ToList();

            

            foreach (Supplier u in supply)
            {
                form.comboBoxSupply.Items.Add(u.SupplierName);
            }
            foreach(Assemblys u in assemb)
            {
                form.comboBoxAssembly.Items.Add(u.AssemblyId);
            }

            foreach(Schools u in school)
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
                    indexSchool= u.SchoolId;
                }
            }

            Delivery delivery = new Delivery
            {

                SupplierId = indexSupply,
                AssemblyId = indexAssembly,
                SchoolId = indexSchool
            };
            db.Deliveries.Add(delivery);
            db.SaveChanges();

            this.Hide();
            FormDelivery formDel = new FormDelivery();
            formDel.Show();
        }

        private void panelLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel clickedPanel = sender as Panel;
                if (clickedPanel != null)
                {
                    contextMenuStrip.Tag = clickedPanel; // Сохраняем ссылку на панель
                    contextMenuStrip.Show(clickedPanel, e.Location);
                }
            }
        }
        private void MenuEdit_Click(object sender, EventArgs e)
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

                var del = this.db.Deliveries.OrderBy(o=>o.DeliveryDate).ToList();
                var supply = this.db.Suppliers.OrderBy(o => o.SupplierName).ToList();
                var assemb = this.db.Assemblies.OrderBy(o => o.AssemblyId).ToList();
                var school = this.db.Schools.OrderBy(o => o.SchoolName).ToList();



                string splits = (string)clickedPanel.Tag;
                string[] Ids = splits.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int delivaryId = Int32.Parse(Ids[0]);
                int supplierId  = Int32.Parse(Ids[1]);
                int assemblyId = Int32.Parse(Ids[2]);
                int schoolId = Int32.Parse(Ids[3]);


                Delivery delivary = db.Deliveries.Find(delivaryId);
                Supplier supplier = db.Suppliers.Find(supplierId);
                Assemblys assembly = db.Assemblies.Find(assemblyId);
                Schools schools =   db.Schools.Find(schoolId);




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
                FormDelivery formDel = new FormDelivery();
                formDel.Show();
            }
        }
        private void MenuShowSupplier_Click(object sender, EventArgs e)
        {

        }
        private void MenuShowAssembly_Click(object sender, EventArgs e)
        {

        }

    }
}
