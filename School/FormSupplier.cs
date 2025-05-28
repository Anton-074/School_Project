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



            labelName.Text = $"Поставщик: {supplier.SupplierName}";
            
            labelInfo.Text = $"Тип поставщика: {typeSupply.TypeSupplierName}\nКонтактная информация:\nТелефон: {supplier.Phone}\nEmail: {supplier.Email}\nАдрес: {supplier.LegalAddress}";
        }
    }
}
