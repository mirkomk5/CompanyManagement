using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using FE_CompanyTest.Services;
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

        private int OrdersCurrentPage { get { return (int)UpDownPage.Value; } }
        private int OrdersPageSize { get { return (int)UpDownResultSize.Value; } }

        private int ProductsCurrentPage { get { return (int)UpDownProductPage.Value; } }    
        private int ProductsPageSize { get { return (int)UpDownProductPageSize.Value; } }

        public Home(IAuthService authService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _serviceProvider = serviceProvider;

            orderDataGrid.AutoGenerateColumns = true;

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
        }

        private async void RetrevieOrders()
        {
            var orderService = new OrderService();
            var orders = await orderService.GetOrdersAsync(_authService.AuthResponse.TokenId, OrdersCurrentPage, OrdersPageSize);
            if (orders != null)
                orderDataGrid.DataSource = orders;
            else
                MessageBox.Show("Failed to retrieve orders.");
        }

        private async void RetrevieProducts()
        {
            var productService = new ProductService();
            var products = await productService.GetProductsAsync(_authService.AuthResponse.TokenId, ProductsCurrentPage, ProductsPageSize);
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
    }
}
