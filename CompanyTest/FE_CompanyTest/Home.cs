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
            // Ordini ***

            var orderService = new OrderService();
            var orders = await orderService.GetOrdersAsync(_authService.AuthResponse.TokenId, 0, 10);
            if (orders != null)
                orderDataGrid.DataSource = orders;           
            else          
                MessageBox.Show("Failed to retrieve orders.");
            

            // Prodotti ***

            var productService = new ProductService();
            var products = await productService.GetProductsAsync(_authService.AuthResponse.TokenId);
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
    }
}
