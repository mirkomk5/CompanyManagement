namespace FE_CompanyTest
{
    partial class ProductForm
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
            textBoxProductName = new TextBox();
            textBoxProductDescription = new TextBox();
            numericProductPrice = new NumericUpDown();
            numericProductDiscount = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonSaveProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericProductDiscount).BeginInit();
            SuspendLayout();
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(22, 44);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.PlaceholderText = "Nome prodotto...";
            textBoxProductName.Size = new Size(301, 23);
            textBoxProductName.TabIndex = 0;
            // 
            // textBoxProductDescription
            // 
            textBoxProductDescription.Location = new Point(22, 73);
            textBoxProductDescription.Multiline = true;
            textBoxProductDescription.Name = "textBoxProductDescription";
            textBoxProductDescription.PlaceholderText = "Descrizione articolo (max 500 char)";
            textBoxProductDescription.Size = new Size(301, 106);
            textBoxProductDescription.TabIndex = 1;
            // 
            // numericProductPrice
            // 
            numericProductPrice.DecimalPlaces = 2;
            numericProductPrice.Location = new Point(73, 185);
            numericProductPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericProductPrice.Name = "numericProductPrice";
            numericProductPrice.Size = new Size(105, 23);
            numericProductPrice.TabIndex = 2;
            // 
            // numericProductDiscount
            // 
            numericProductDiscount.Location = new Point(263, 185);
            numericProductDiscount.Name = "numericProductDiscount";
            numericProductDiscount.Size = new Size(60, 23);
            numericProductDiscount.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 187);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Prezzo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 187);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Sconto %";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 26);
            label3.Name = "label3";
            label3.Size = new Size(182, 15);
            label3.TabIndex = 6;
            label3.Text = "Inserire le specifiche del prodotto";
            // 
            // buttonSaveProduct
            // 
            buttonSaveProduct.Location = new Point(22, 237);
            buttonSaveProduct.Name = "buttonSaveProduct";
            buttonSaveProduct.Size = new Size(301, 23);
            buttonSaveProduct.TabIndex = 7;
            buttonSaveProduct.Text = "Salva";
            buttonSaveProduct.UseVisualStyleBackColor = true;
            buttonSaveProduct.Click += buttonSaveProduct_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 290);
            Controls.Add(buttonSaveProduct);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericProductDiscount);
            Controls.Add(numericProductPrice);
            Controls.Add(textBoxProductDescription);
            Controls.Add(textBoxProductName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductForm";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericProductDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxProductName;
        private TextBox textBoxProductDescription;
        private NumericUpDown numericProductPrice;
        private NumericUpDown numericProductDiscount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonSaveProduct;
    }
}