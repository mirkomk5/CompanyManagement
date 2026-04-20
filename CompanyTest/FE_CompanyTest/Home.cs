using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using FE_CompanyTest.Services;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class Home : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOrdersService _orderService;
        private readonly IProductService _productService;
        private readonly IClaimsService _claimsService;

        private int OrdersCurrentPage { get { return (int)UpDownPage.Value; } }
        private int OrdersPageSize { get { return (int)UpDownResultSize.Value; } }

        private int ProductsCurrentPage { get { return (int)UpDownProductPage.Value; } }
        private int ProductsPageSize { get { return (int)UpDownProductPageSize.Value; } }

        public Home(IAuthService authService, IServiceProvider serviceProvider, IOrdersService ordersService, IProductService productService, IClaimsService claimsService)
        {
            InitializeComponent();
            _authService = authService;
            _serviceProvider = serviceProvider;

            _productService = productService;
            _claimsService = claimsService;
            _orderService = ordersService;

            orderDataGrid.AutoGenerateColumns = true;
            dataGridProducts.AutoGenerateColumns = true;
            ClaimsDataGrid.AutoGenerateColumns = true;

            RetrevieData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region Custom Methods

        private async void RetrevieData()
        {
            RetrevieOrders();
            RetrevieProducts();
            RetrevieClaims();
        }

        private async void RetrevieClaims()
        {
            var claims = await _claimsService.GetClaimsTable(_authService.AuthResponse.TokenId);
            if (claims == null) return;

            ClaimsDataGrid.DataSource = claims;
        }

        private async void RetrevieOrders()
        {
            var orders = await _orderService.GetOrdersAsync(_authService.AuthResponse.TokenId, OrdersCurrentPage, OrdersPageSize);
            if (orders != null)
                orderDataGrid.DataSource = orders;
            else
                MessageBox.Show("Failed to retrieve orders.");
        }

        private async void RetrevieProducts()
        {
            var products = await _productService.GetProductsAsync(_authService.AuthResponse.TokenId, ProductsCurrentPage, ProductsPageSize);
            if (products != null)
                dataGridProducts.DataSource = products;
            else
                MessageBox.Show("Failed to retrieve products.");
        }


        #endregion

        private void aggiunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void UpDownPage_ValueChanged(object sender, EventArgs e)
        {
            RetrevieOrders();
        }

        private void UpDownResultSize_ValueChanged(object sender, EventArgs e)
        {
            RetrevieOrders();
        }

        private void ButtonSaveOrderChanges_Click(object sender, EventArgs e)
        {

        }

        private void UpDownProductPage_ValueChanged(object sender, EventArgs e)
        {
            RetrevieProducts();
        }

        private void UpDownProductPageSize_ValueChanged(object sender, EventArgs e)
        {
            RetrevieProducts();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aggiungiProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<ProductForm>().ShowDialog();
        }
    }
}
