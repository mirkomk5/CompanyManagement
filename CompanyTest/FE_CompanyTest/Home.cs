using DTO_CompanyTest;
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
        public Home()
        {
            InitializeComponent();
            orderDataGrid.AutoGenerateColumns = true;
            orderDataGrid.DataSource = new List<DTO_OrderTable>
            {
                new DTO_OrderTable{ OrderId = "1", ProductName = "Prodotto 1", Price = 10.5m },
                new DTO_OrderTable { OrderId = "2", ProductName = "Prodotto 2",  Price = 20.0m },
                new DTO_OrderTable { OrderId = "3", ProductName = "Prodotto 3",  Price = 5.0m }
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
