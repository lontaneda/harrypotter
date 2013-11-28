using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HarryPotter.Services;
using HarryPotter.Domain;

namespace HarryPotter.StoreApp
{
    public partial class frmBooksStore : Form
    {

        private IBooksService _bookService;
        private Order _order;

        public frmBooksStore()
        {
            InitializeComponent();
            this._bookService = new BooksServiceMock();
        }

        private void frmBooksStore_Load(object sender, EventArgs e)
        {
            IList<Book> allBooks = this._bookService.GetAll();
            this._order = new Order(allBooks);
            foreach (OrderItem item in this._order.Items)
            {
                OrderItemControl crtl = new OrderItemControl(item);
                Label lbl = new Label() { Text = item.Book.Name };
                flowLayoutPanel1.Controls.Add(crtl);
            }
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            frmCart cart = new frmCart(this._order);
            cart.ShowDialog();
        }
    }
}
