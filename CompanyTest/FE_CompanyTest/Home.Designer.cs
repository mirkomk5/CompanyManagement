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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            orderDataGrid = new DataGridView();
            tabPage2 = new TabPage();
            dataGridProducts = new DataGridView();
            tabPage3 = new TabPage();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aggiornaRisultatiToolStripMenuItem = new ToolStripMenuItem();
            esciToolStripMenuItem = new ToolStripMenuItem();
            modificaToolStripMenuItem = new ToolStripMenuItem();
            aggiunToolStripMenuItem = new ToolStripMenuItem();
            aggiungiProdottoToolStripMenuItem = new ToolStripMenuItem();
            numericUpDown1 = new NumericUpDown();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1018, 394);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(orderDataGrid);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1010, 366);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ordini";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // orderDataGrid
            // 
            orderDataGrid.AllowUserToAddRows = false;
            orderDataGrid.AllowUserToDeleteRows = false;
            orderDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orderDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            orderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGrid.Location = new Point(3, 32);
            orderDataGrid.Name = "orderDataGrid";
            orderDataGrid.ReadOnly = true;
            orderDataGrid.Size = new Size(1004, 331);
            orderDataGrid.TabIndex = 0;
            orderDataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridProducts);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1010, 366);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Prodotti";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridProducts
            // 
            dataGridProducts.AllowUserToAddRows = false;
            dataGridProducts.AllowUserToDeleteRows = false;
            dataGridProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProducts.BackgroundColor = SystemColors.ControlLightLight;
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(3, 33);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.ReadOnly = true;
            dataGridProducts.Size = new Size(1004, 330);
            dataGridProducts.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1010, 366);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Reclami";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, modificaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1032, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aggiornaRisultatiToolStripMenuItem, esciToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // aggiornaRisultatiToolStripMenuItem
            // 
            aggiornaRisultatiToolStripMenuItem.Name = "aggiornaRisultatiToolStripMenuItem";
            aggiornaRisultatiToolStripMenuItem.Size = new Size(165, 22);
            aggiornaRisultatiToolStripMenuItem.Text = "Aggiorna risultati";
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new Size(165, 22);
            esciToolStripMenuItem.Text = "Esci";
            // 
            // modificaToolStripMenuItem
            // 
            modificaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aggiunToolStripMenuItem, aggiungiProdottoToolStripMenuItem });
            modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            modificaToolStripMenuItem.Size = new Size(66, 20);
            modificaToolStripMenuItem.Text = "Modifica";
            // 
            // aggiunToolStripMenuItem
            // 
            aggiunToolStripMenuItem.Name = "aggiunToolStripMenuItem";
            aggiunToolStripMenuItem.Size = new Size(173, 22);
            aggiunToolStripMenuItem.Text = "Aggiungi ordine";
            aggiunToolStripMenuItem.Click += aggiunToolStripMenuItem_Click;
            // 
            // aggiungiProdottoToolStripMenuItem
            // 
            aggiungiProdottoToolStripMenuItem.Name = "aggiungiProdottoToolStripMenuItem";
            aggiungiProdottoToolStripMenuItem.Size = new Size(173, 22);
            aggiungiProdottoToolStripMenuItem.Text = "Aggiungi prodotto";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.ImeMode = ImeMode.NoControl;
            numericUpDown1.Location = new Point(945, 6);
            numericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(59, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 458);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Customer Management";
            Load += Home_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aggiornaRisultatiToolStripMenuItem;
        private ToolStripMenuItem esciToolStripMenuItem;
        private ToolStripMenuItem modificaToolStripMenuItem;
        private ToolStripMenuItem aggiunToolStripMenuItem;
        private ToolStripMenuItem aggiungiProdottoToolStripMenuItem;
        private TabPage tabPage1;
        private DataGridView orderDataGrid;
        private TabPage tabPage3;
        private DataGridView dataGridProducts;
        private NumericUpDown numericUpDown1;
    }
}