using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HarryPotter.Domain;

namespace HarryPotter.StoreApp
{
    public partial class OrderItemControl : UserControl
    {

        public OrderItem Item { get; set; }

        public OrderItemControl()
        {
            InitializeComponent();
        }

        public OrderItemControl(OrderItem item)
        {
            InitializeComponent();
            this.Item = item;
            this.label1.Text = item.Book.Name;
        }

        private void quantityTextBox_ValueChanged(object sender, EventArgs e)
        {
            this.Item.Quantity = (int)quantityTextBox.Value;
        }
    }
}
