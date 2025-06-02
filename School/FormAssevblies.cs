using Microsoft.EntityFrameworkCore;
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
    public partial class FormAsseblies : Form
    {
        private SchollContext? db;
        private int assemblyId = -1;
        public FormAsseblies(int assseblyId)
        {
            InitializeComponent();
            this.assemblyId = assseblyId;
            GenerateInfo();
        }

        public void GenerateInfo()
        {
            this.db = new SchollContext();

            this.BackColor = Color.FromArgb(40, 45, 60);
            panel1.BackColor = Color.FromArgb(40, 45, 60);
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
            using (var context = new SchollContext())
            {
                var query = from ac in context.AssemblyComponents
                            join c in context.Components on ac.WarehouseStockId equals c.ComponentId
                            join cc in context.CompanyComponents on c.CompanyComponentId equals cc.CompanyId // Adjust this line to match your foreign key
                            join ccc in context.TypeComponents on c.TypeComponentId equals ccc.TypeComponentId
                            where ac.AssemblyId == assemblyId
                            select new
                            {
                                c.ComponentName,
                                cc.CompanyName, // Include company name
                                ccc.TypeComponentName
                            };

                var result = query.ToList();

                // Optionally, display the results in your application
                labelInfo.Text = $"Серийный номер: {assemblyId}\n";
                foreach (var item in result)
                {
                    labelInfo.Text += ($"{item.TypeComponentName}: {item.CompanyName} {item.ComponentName}\n");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
