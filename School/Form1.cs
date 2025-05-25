using School.Models;

namespace School
{
    public partial class FormDelivery : Form
    {
        private SchollContext? db;
        public FormDelivery()
        {
            InitializeComponent();
            GeneratePanel();
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


                Panel supplierPanel = new Panel
                {
                    Size = new System.Drawing.Size(780, 80),
                    Location = new System.Drawing.Point(15, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = $"{del.DeliveryId},{typeSupply.TypeSupplierId}"
                };
                //supplierPanel.MouseDown += panelLabel_MouseDown;
                Label supplierLabel = new Label
                {
                    AutoSize = true,
                    Dock = DockStyle.Right,
                    Text = $" Поставщик: {typeSupply.TypeSupplierName} {supplier.SupplierName}"
                };
                Label assemblyLabel = new Label
                {
                    AutoSize = true,
                    Dock = DockStyle.Left,
                    Text = $"Заказ: \nКомпьютер\nСерийный номер {del.AssemblyId}"
                };
                supplierPanel.Controls.Add(assemblyLabel);
                supplierPanel.Controls.Add(supplierLabel);
                
                this.Controls.Add(supplierPanel);
                yOffset += supplierLabel.Height + 90;
            }
        }
    }
}
