namespace School
{
    partial class FormSupplier
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
            labelName = new Label();
            labelInfo = new Label();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.Dock = DockStyle.Top;
            labelName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelName.Location = new Point(0, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(483, 65);
            labelName.TabIndex = 0;
            labelName.Text = "Поставщик: ";
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            labelInfo.Dock = DockStyle.Fill;
            labelInfo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelInfo.Location = new Point(0, 65);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(483, 193);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Инфа";
            // 
            // FormSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 258);
            Controls.Add(labelInfo);
            Controls.Add(labelName);
            Name = "FormSupplier";
            Text = "FormSupplier";
            ResumeLayout(false);
        }

        #endregion

        private Label labelName;
        private Label labelInfo;
    }
}