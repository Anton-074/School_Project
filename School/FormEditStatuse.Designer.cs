namespace School
{
    partial class FormEditStatuse
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
            panel1 = new Panel();
            label3 = new Label();
            panelBut = new Panel();
            buttonSave = new Button();
            buttonCancel = new Button();
            label = new Label();
            comboBoxStatuse = new ComboBox();
            panel1.SuspendLayout();
            panelBut.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panelBut);
            panel1.Controls.Add(label);
            panel1.Controls.Add(comboBoxStatuse);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(539, 256);
            panel1.TabIndex = 15;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(539, 65);
            label3.TabIndex = 19;
            label3.Text = "labelTop";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBut
            // 
            panelBut.Controls.Add(buttonSave);
            panelBut.Controls.Add(buttonCancel);
            panelBut.Dock = DockStyle.Bottom;
            panelBut.Location = new Point(0, 181);
            panelBut.Name = "panelBut";
            panelBut.Size = new Size(539, 75);
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
            // label
            // 
            label.Font = new Font("Microsoft Sans Serif", 12F);
            label.Location = new Point(37, 77);
            label.Name = "label";
            label.Size = new Size(487, 28);
            label.TabIndex = 12;
            label.Text = "Статус";
            // 
            // comboBoxStatuse
            // 
            comboBoxStatuse.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatuse.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxStatuse.FormattingEnabled = true;
            comboBoxStatuse.Location = new Point(37, 107);
            comboBoxStatuse.Name = "comboBoxStatuse";
            comboBoxStatuse.Size = new Size(487, 28);
            comboBoxStatuse.TabIndex = 13;
            // 
            // FormEditStatuse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 256);
            Controls.Add(panel1);
            Name = "FormEditStatuse";
            Text = "FormEditStatuse";
            panel1.ResumeLayout(false);
            panelBut.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelBut;
        private Button buttonSave;
        private Button buttonCancel;
        public Label label2;
        public ComboBox comboBoxSchool;
        public Label label1;
        public ComboBox comboBoxAssembly;
        public Label label;
        public ComboBox comboBoxStatuse;
        private Label label3;
    }
}