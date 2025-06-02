using School.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class FormSupplier : Form
    {
        private SchollContext? db;
        private int supplierId = -1;
        public FormSupplier(int supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            GenerateInfo();
        }
        private void GenerateInfo()
        {
            this.db = new SchollContext();

            var supplier = this.db.Suppliers.Where(w => w.SupplierId == supplierId).FirstOrDefault();
            var typeSupply = this.db.TypeSuppliers.Where(w => w.TypeSupplierId == supplier.TypeSupplierId).FirstOrDefault();

            this.BackColor = Color.FromArgb(40, 45, 60);
            panelBut.BackColor = Color.FromArgb(40, 45, 60);
            panel1.BackColor = Color.FromArgb(40, 45, 60);
            labelName.Text = $"Поставщик: {supplier.SupplierName}";
            labelName.ForeColor = Color.White;
            labelName.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);


            buttonCancel.BackColor = Color.FromArgb(0, 122, 204);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;

            labelInfo.ForeColor = Color.White;
            labelInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            labelInfo.Text = $"Тип поставщика: {typeSupply.TypeSupplierName}\nКонтактная информация:\nТелефон: {supplier.Phone}\nEmail: {supplier.Email}\nАдрес: {supplier.LegalAddress}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
