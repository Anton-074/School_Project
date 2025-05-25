using School.Models;
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

                Panel supplierPanel = new Panel
                {
                    Size = new System.Drawing.Size(770, 90),
                    Location = new System.Drawing.Point(15, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = $"{del.DeliveryId},{typeSupply.TypeSupplierId}"
                };
                supplierPanel.MouseDown += panelLabel_MouseDown;
                //supplierPanel.MouseDown += panelLabel_MouseDown;
                Label supplierLabel = new Label
                {
                    AutoSize = false,
                    Size = new System.Drawing.Size(200, 75),
                    Dock = DockStyle.Right,
                    Text = $" Поставщик: {typeSupply.TypeSupplierName} {supplier.SupplierName}",
                    TextAlign = ContentAlignment.BottomRight,
                    BorderStyle = BorderStyle.FixedSingle
                };
                Label assemblyLabel = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Left,
                    Size = new System.Drawing.Size(200, 75),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = $"Заказ: \nКомпьютер\nСерийный номер {del.AssemblyId}\n{schoolNumber.SchoolName}\n{del.DeliveryDate}"
                };
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

            int count = 1;

            foreach (Supplier u in supply)
            {
                form.comboBoxSupply.Items.Add(u.SupplierName);
            }
            foreach(Assembly u in assemb)
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
            foreach (Assembly u in assemb)
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
                SchoolId = indexSchool,
                //DeliveryDate = DateTime.Now.ToLongDateString(),
            };
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

        }
        private void MenuShowSupplier_Click(object sender, EventArgs e)
        {

        }
        private void MenuShowAssembly_Click(object sender, EventArgs e)
        {

        }

    }
}
