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
    public partial class FormEditDelivery : Form
    {
        string msgError = "Поле не может быть пустым";
        public FormEditDelivery()
        {
            InitializeComponent();
            this.Text = "Редактирование заказа";
            panel1.BackColor = Color.FromArgb(40, 45, 60);
            panel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            label3.Text = "Редактирование заказа";
            label3.ForeColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            label.ForeColor = Color.WhiteSmoke;
            label1.ForeColor = Color.WhiteSmoke;
            label2.ForeColor = Color.WhiteSmoke;

            comboBoxAssembly.BackColor = Color.White;
            comboBoxSchool.BackColor = Color.White;
            comboBoxSupply.BackColor = Color.White;

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

        private void FormEditDelivery_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxType_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxSupply.Text))
            {
                errorProvider.SetError(comboBoxSupply, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }

        private void comboBoxSupply_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxSupply.Text))
            {
                errorProvider.SetError(comboBoxSupply, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }


        private void comboBoxAssembly_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxAssembly.Text))
            {
                errorProvider.SetError(comboBoxAssembly, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }

        private void comboBoxAssembly_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxAssembly.Text))
            {
                errorProvider.SetError(comboBoxAssembly, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }

        private void comboBoxSchool_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxSchool.Text))
            {
                errorProvider.SetError(comboBoxSchool, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }

        private void comboBoxSchool_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxSchool.Text))
            {
                errorProvider.SetError(comboBoxSchool, msgError);
                buttonSave.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonSave.Enabled = true;
            }
        }
    }
}
