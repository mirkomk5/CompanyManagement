namespace FE_CompanyTest
{
    partial class Home
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
            orderDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).BeginInit();
            SuspendLayout();
            // 
            // orderDataGrid
            // 
            orderDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            orderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGrid.Location = new Point(12, 30);
            orderDataGrid.Name = "orderDataGrid";
            orderDataGrid.Size = new Size(645, 403);
            orderDataGrid.TabIndex = 0;
            orderDataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 527);
            Controls.Add(orderDataGrid);
            Name = "Home";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView orderDataGrid;
    }
}