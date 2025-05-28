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
            flowLayoutPanelTop = new FlowLayoutPanel();
            buttonExit = new Button();
            flowLayoutPanelTop.SuspendLayout();
            SuspendLayout();
            // 
            // buttonNewDelivery
            // 
            buttonNewDelivery.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonNewDelivery.Location = new Point(13, 13);
            buttonNewDelivery.Name = "buttonNewDelivery";
            buttonNewDelivery.Size = new Size(585, 75);
            buttonNewDelivery.TabIndex = 0;
            buttonNewDelivery.Text = "Оформить заказ";
            buttonNewDelivery.UseVisualStyleBackColor = true;
            buttonNewDelivery.Click += buttonNewDelivery_Click;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(61, 4);
            // 
            // flowLayoutPanelTop
            // 
            flowLayoutPanelTop.Controls.Add(buttonNewDelivery);
            flowLayoutPanelTop.Controls.Add(buttonExit);
            flowLayoutPanelTop.Dock = DockStyle.Top;
            flowLayoutPanelTop.Location = new Point(0, 0);
            flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            flowLayoutPanelTop.Padding = new Padding(10);
            flowLayoutPanelTop.Size = new Size(800, 100);
            flowLayoutPanelTop.TabIndex = 2;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExit.Location = new Point(604, 13);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(167, 75);
            buttonExit.TabIndex = 3;
            buttonExit.Text = "Выход из аккаунта";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // FormDelivery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelTop);
            Name = "FormDelivery";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            flowLayoutPanelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Button buttonNewDelivery;
        public ContextMenuStrip contextMenuStrip;
        private Panel panelTop;
        private FlowLayoutPanel flowLayoutPanelTop;
        private Button buttonExit;
    }
}
