using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_CompanyTest
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly IAuthService _authService;

        public ProductForm(IAuthService authService, IProductService productService)
        {
            InitializeComponent();
            _authService = authService;
            _productService = productService;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private async void buttonSaveProduct_Click(object sender, EventArgs e)
        {
            var productDto = new DTO_Product
            {
                ProductName = textBoxProductName.Text,
                Description = textBoxProductDescription.Text,
                Price = numericProductPrice.Value,
                Discount = numericProductDiscount.Value / 100
            };

            var result = await _productService.CreateProductAsync(productDto, _authService.AuthResponse.TokenId);
            
            if (!result.status)
            {
                MessageBox.Show($"Errore durante la creazione del prodotto:\n{result.message}");
                return;
            }

            this.Close();
        }
    }
}
