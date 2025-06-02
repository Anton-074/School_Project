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
    public partial class FormEditStatuse : Form
    {
        public FormEditStatuse()
        {
            InitializeComponent();

            this.Text = "Редактирование статуса";
            panel1.BackColor = Color.FromArgb(40, 45, 60);
            panel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            label3.Text = "Редактирование статуса";
            label3.ForeColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            label.ForeColor = Color.WhiteSmoke;
            comboBoxStatuse.BackColor = Color.White;

            panelBut.BackColor = Color.FromArgb(40, 45, 60);

            buttonCancel.BackColor = Color.FromArgb(0, 122, 204);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;

            buttonSave.BackColor = Color.FromArgb(0, 122, 204);
            buttonSave.ForeColor = Color.White;
            buttonSave.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;
        }
    }
}
