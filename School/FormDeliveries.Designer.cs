namespace School
{
    partial class FormDelivery
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonNewDelivery = new Button();
            contextMenuStrip = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // buttonNewDelivery
            // 
            buttonNewDelivery.Dock = DockStyle.Top;
            buttonNewDelivery.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonNewDelivery.Location = new Point(0, 0);
            buttonNewDelivery.Name = "buttonNewDelivery";
            buttonNewDelivery.Size = new Size(800, 54);
            buttonNewDelivery.TabIndex = 0;
            buttonNewDelivery.Text = "Оформить заказ";
            buttonNewDelivery.UseVisualStyleBackColor = true;
            buttonNewDelivery.Click += buttonNewDelivery_Click;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(181, 26);
            // 
            // FormDelivery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonNewDelivery);
            Name = "FormDelivery";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonNewDelivery;
        private ContextMenuStrip contextMenuStrip;
    }
}
