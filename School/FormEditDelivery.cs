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
