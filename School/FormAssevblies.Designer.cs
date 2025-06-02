namespace School
{
    partial class FormAsseblies
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
            labelName = new Label();
            labelInfo = new Label();
            buttonCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(labelInfo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 267);
            panel1.TabIndex = 21;
            // 
            // labelName
            // 
            labelName.Dock = DockStyle.Top;
            labelName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelName.Location = new Point(0, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(717, 65);
            labelName.TabIndex = 0;
            labelName.Text = "Сборка:";
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            labelInfo.Dock = DockStyle.Bottom;
            labelInfo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelInfo.Location = new Point(0, 65);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(717, 202);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Инфа";
            // 
            // buttonCancel
            // 
            buttonCancel.Dock = DockStyle.Bottom;
            buttonCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.Location = new Point(10, 275);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(717, 75);
            buttonCancel.TabIndex = 22;
            buttonCancel.Text = "Назад";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormAsseblies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 360);
            Controls.Add(buttonCancel);
            Controls.Add(panel1);
            Name = "FormAsseblies";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAssevblies";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelName;
        private Label labelInfo;
        private Button buttonCancel;
    }
}