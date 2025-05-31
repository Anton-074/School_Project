namespace School
{
    partial class FormEditDelivery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxSupply = new ComboBox();
            label = new Label();
            panel1 = new Panel();
            panelBut = new Panel();
            buttonSave = new Button();
            buttonCancel = new Button();
            label2 = new Label();
            comboBoxSchool = new ComboBox();
            label1 = new Label();
            comboBoxAssembly = new ComboBox();
            errorProvider = new ErrorProvider(components);
            panel1.SuspendLayout();
            panelBut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // comboBoxSupply
            // 
            comboBoxSupply.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupply.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxSupply.FormattingEnabled = true;
            comboBoxSupply.Location = new Point(37, 48);
            comboBoxSupply.Name = "comboBoxSupply";
            comboBoxSupply.Size = new Size(487, 28);
            comboBoxSupply.TabIndex = 13;
            comboBoxSupply.TextChanged += comboBoxType_TextChanged;
            comboBoxSupply.Validating += comboBoxSupply_Validating;
            // 
            // label
            // 
            label.Font = new Font("Microsoft Sans Serif", 12F);
            label.Location = new Point(37, 18);
            label.Name = "label";
            label.Size = new Size(487, 28);
            label.TabIndex = 12;
            label.Text = "Поставщик";
            // 
            // panel1
            // 
            panel1.Controls.Add(panelBut);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxSchool);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBoxAssembly);
            panel1.Controls.Add(label);
            panel1.Controls.Add(comboBoxSupply);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(561, 386);
            panel1.TabIndex = 14;
            // 
            // panelBut
            // 
            panelBut.Controls.Add(buttonSave);
            panelBut.Controls.Add(buttonCancel);
            panelBut.Dock = DockStyle.Bottom;
            panelBut.Location = new Point(0, 311);
            panelBut.Name = "panelBut";
            panelBut.Size = new Size(561, 75);
            panelBut.TabIndex = 18;
            // 
            // buttonSave
            // 
            buttonSave.DialogResult = DialogResult.OK;
            buttonSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSave.Location = new Point(342, 18);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(119, 36);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.Location = new Point(83, 18);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(117, 36);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.Location = new Point(37, 204);
            label2.Name = "label2";
            label2.Size = new Size(487, 28);
            label2.TabIndex = 16;
            label2.Text = "Образовательная организация";
            // 
            // comboBoxSchool
            // 
            comboBoxSchool.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSchool.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxSchool.FormattingEnabled = true;
            comboBoxSchool.Location = new Point(37, 234);
            comboBoxSchool.Name = "comboBoxSchool";
            comboBoxSchool.Size = new Size(487, 28);
            comboBoxSchool.TabIndex = 17;
            comboBoxSchool.TextChanged += comboBoxSchool_TextChanged;
            comboBoxSchool.Validating += comboBoxSchool_Validating;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.Location = new Point(37, 109);
            label1.Name = "label1";
            label1.Size = new Size(487, 28);
            label1.TabIndex = 14;
            label1.Text = "Серийный номер";
            // 
            // comboBoxAssembly
            // 
            comboBoxAssembly.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAssembly.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxAssembly.FormattingEnabled = true;
            comboBoxAssembly.Location = new Point(37, 139);
            comboBoxAssembly.Name = "comboBoxAssembly";
            comboBoxAssembly.Size = new Size(487, 28);
            comboBoxAssembly.TabIndex = 15;
            comboBoxAssembly.TextChanged += comboBoxAssembly_TextChanged;
            comboBoxAssembly.Validating += comboBoxAssembly_Validating;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormEditDelivery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 386);
            Controls.Add(panel1);
            Name = "FormEditDelivery";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEditDelivery";
            Load += FormEditDelivery_Load;
            panel1.ResumeLayout(false);
            panelBut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public ComboBox comboBoxSupply;
        public Label label;
        private Panel panel1;
        public Label label2;
        public ComboBox comboBoxSchool;
        public Label label1;
        public ComboBox comboBoxAssembly;
        private ErrorProvider errorProvider;
        private Panel panelBut;
        private Button buttonSave;
        private Button buttonCancel;
    }
}