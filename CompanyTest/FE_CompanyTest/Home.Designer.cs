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
            ButtonSaveOrderChanges = new Button();
            label2 = new Label();
            label1 = new Label();
            UpDownResultSize = new NumericUpDown();
            UpDownPage = new NumericUpDown();
            orderDataGrid = new DataGridView();
            tabPage2 = new TabPage();
            label3 = new Label();
            label4 = new Label();
            UpDownProductPageSize = new NumericUpDown();
            UpDownProductPage = new NumericUpDown();
            dataGridProducts = new DataGridView();
            tabPage3 = new TabPage();
            ClaimsDataGrid = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aggiornaRisultatiToolStripMenuItem = new ToolStripMenuItem();
            esciToolStripMenuItem = new ToolStripMenuItem();
            modificaToolStripMenuItem = new ToolStripMenuItem();
            aggiunToolStripMenuItem = new ToolStripMenuItem();
            aggiungiProdottoToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownResultSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownProductPageSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownProductPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClaimsDataGrid).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(14, 36);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1163, 525);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ButtonSaveOrderChanges);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(UpDownResultSize);
            tabPage1.Controls.Add(UpDownPage);
            tabPage1.Controls.Add(orderDataGrid);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1155, 492);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ordini";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveOrderChanges
            // 
            ButtonSaveOrderChanges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSaveOrderChanges.Location = new Point(759, 8);
            ButtonSaveOrderChanges.Margin = new Padding(3, 4, 3, 4);
            ButtonSaveOrderChanges.Name = "ButtonSaveOrderChanges";
            ButtonSaveOrderChanges.Size = new Size(86, 31);
            ButtonSaveOrderChanges.TabIndex = 5;
            ButtonSaveOrderChanges.Text = "Salva";
            ButtonSaveOrderChanges.UseVisualStyleBackColor = true;
            ButtonSaveOrderChanges.Click += ButtonSaveOrderChanges_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1003, 11);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 4;
            label2.Text = "N. risultati";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(866, 11);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 3;
            label1.Text = "Pagina";
            // 
            // UpDownResultSize
            // 
            UpDownResultSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpDownResultSize.BorderStyle = BorderStyle.FixedSingle;
            UpDownResultSize.ImeMode = ImeMode.NoControl;
            UpDownResultSize.Location = new Point(1080, 8);
            UpDownResultSize.Margin = new Padding(3, 4, 3, 4);
            UpDownResultSize.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            UpDownResultSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownResultSize.Name = "UpDownResultSize";
            UpDownResultSize.Size = new Size(67, 27);
            UpDownResultSize.TabIndex = 2;
            UpDownResultSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownResultSize.ValueChanged += UpDownResultSize_ValueChanged;
            // 
            // UpDownPage
            // 
            UpDownPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpDownPage.BorderStyle = BorderStyle.FixedSingle;
            UpDownPage.ImeMode = ImeMode.NoControl;
            UpDownPage.Location = new Point(922, 8);
            UpDownPage.Margin = new Padding(3, 4, 3, 4);
            UpDownPage.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            UpDownPage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            UpDownPage.Name = "UpDownPage";
            UpDownPage.Size = new Size(67, 27);
            UpDownPage.TabIndex = 1;
            UpDownPage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            UpDownPage.ValueChanged += UpDownPage_ValueChanged;
            // 
            // orderDataGrid
            // 
            orderDataGrid.AllowUserToAddRows = false;
            orderDataGrid.AllowUserToDeleteRows = false;
            orderDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orderDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            orderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGrid.Location = new Point(3, 43);
            orderDataGrid.Margin = new Padding(3, 4, 3, 4);
            orderDataGrid.Name = "orderDataGrid";
            orderDataGrid.RowHeadersWidth = 51;
            orderDataGrid.Size = new Size(1147, 441);
            orderDataGrid.TabIndex = 0;
            orderDataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(UpDownProductPageSize);
            tabPage2.Controls.Add(UpDownProductPage);
            tabPage2.Controls.Add(dataGridProducts);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1155, 492);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Prodotti";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1003, 8);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 8;
            label3.Text = "N. risultati";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(866, 8);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 7;
            label4.Text = "Pagina";
            // 
            // UpDownProductPageSize
            // 
            UpDownProductPageSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpDownProductPageSize.BorderStyle = BorderStyle.FixedSingle;
            UpDownProductPageSize.ImeMode = ImeMode.NoControl;
            UpDownProductPageSize.Location = new Point(1080, 5);
            UpDownProductPageSize.Margin = new Padding(3, 4, 3, 4);
            UpDownProductPageSize.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            UpDownProductPageSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownProductPageSize.Name = "UpDownProductPageSize";
            UpDownProductPageSize.Size = new Size(67, 27);
            UpDownProductPageSize.TabIndex = 6;
            UpDownProductPageSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownProductPageSize.ValueChanged += UpDownProductPageSize_ValueChanged;
            // 
            // UpDownProductPage
            // 
            UpDownProductPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpDownProductPage.BorderStyle = BorderStyle.FixedSingle;
            UpDownProductPage.ImeMode = ImeMode.NoControl;
            UpDownProductPage.Location = new Point(922, 5);
            UpDownProductPage.Margin = new Padding(3, 4, 3, 4);
            UpDownProductPage.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            UpDownProductPage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            UpDownProductPage.Name = "UpDownProductPage";
            UpDownProductPage.Size = new Size(67, 27);
            UpDownProductPage.TabIndex = 5;
            UpDownProductPage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            UpDownProductPage.ValueChanged += UpDownProductPage_ValueChanged;
            // 
            // dataGridProducts
            // 
            dataGridProducts.AllowUserToAddRows = false;
            dataGridProducts.AllowUserToDeleteRows = false;
            dataGridProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProducts.BackgroundColor = SystemColors.ControlLightLight;
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(3, 44);
            dataGridProducts.Margin = new Padding(3, 4, 3, 4);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.ReadOnly = true;
            dataGridProducts.RowHeadersWidth = 51;
            dataGridProducts.Size = new Size(1147, 440);
            dataGridProducts.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(ClaimsDataGrid);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(1155, 492);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Reclami";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // ClaimsDataGrid
            // 
            ClaimsDataGrid.AllowUserToAddRows = false;
            ClaimsDataGrid.AllowUserToDeleteRows = false;
            ClaimsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ClaimsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClaimsDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            ClaimsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClaimsDataGrid.Location = new Point(7, 44);
            ClaimsDataGrid.Margin = new Padding(3, 4, 3, 4);
            ClaimsDataGrid.Name = "ClaimsDataGrid";
            ClaimsDataGrid.ReadOnly = true;
            ClaimsDataGrid.RowHeadersWidth = 51;
            ClaimsDataGrid.Size = new Size(1142, 440);
            ClaimsDataGrid.TabIndex = 2;
            ClaimsDataGrid.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, modificaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1179, 30);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aggiornaRisultatiToolStripMenuItem, esciToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // aggiornaRisultatiToolStripMenuItem
            // 
            aggiornaRisultatiToolStripMenuItem.Name = "aggiornaRisultatiToolStripMenuItem";
            aggiornaRisultatiToolStripMenuItem.Size = new Size(207, 26);
            aggiornaRisultatiToolStripMenuItem.Text = "Aggiorna risultati";
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new Size(207, 26);
            esciToolStripMenuItem.Text = "Esci";
            // 
            // modificaToolStripMenuItem
            // 
            modificaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aggiunToolStripMenuItem, aggiungiProdottoToolStripMenuItem });
            modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            modificaToolStripMenuItem.Size = new Size(82, 24);
            modificaToolStripMenuItem.Text = "Modifica";
            // 
            // aggiunToolStripMenuItem
            // 
            aggiunToolStripMenuItem.Name = "aggiunToolStripMenuItem";
            aggiunToolStripMenuItem.Size = new Size(217, 26);
            aggiunToolStripMenuItem.Text = "Aggiungi ordine";
            aggiunToolStripMenuItem.Click += aggiunToolStripMenuItem_Click;
            // 
            // aggiungiProdottoToolStripMenuItem
            // 
            aggiungiProdottoToolStripMenuItem.Name = "aggiungiProdottoToolStripMenuItem";
            aggiungiProdottoToolStripMenuItem.Size = new Size(217, 26);
            aggiungiProdottoToolStripMenuItem.Text = "Aggiungi prodotto";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 611);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Home";
            Text = "Customer Management";
            Load += Home_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownResultSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownProductPageSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownProductPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ClaimsDataGrid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private NumericUpDown UpDownPage;
        private NumericUpDown UpDownResultSize;
        private Label label2;
        private Label label1;
        private Button ButtonSaveOrderChanges;
        private Label label3;
        private Label label4;
        private NumericUpDown UpDownProductPageSize;
        private NumericUpDown UpDownProductPage;
        private DataGridView ClaimsDataGrid;
    }
}