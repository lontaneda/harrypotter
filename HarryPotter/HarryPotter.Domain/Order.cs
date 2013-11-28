using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HarryPotter.Domain
{
    public class Order
    {
        public string ClientEmail { get; set; }
        public IList<OrderItem> Items { get; set; }

        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        public Order(IList<Book> books)
        {
            this.Items = new List<OrderItem>();
            foreach (Book book in books)
                this.Items.Add(new OrderItem(0, book));
        }

        public void addBook(int aQuantity, Book aBook)
        {
			this.Items.Add(new OrderItem(aQuantity, aBook));
        }

        public double GetTotal()
        {
            return this.Items.Sum(item => item.Quantity * item.Book.Price);
        }

		public bool hasSameBooks()
		{
			if (Items.Count > 0) {
				int id = Items[0].Book.Id;

				foreach (OrderItem item in Items)
					if (id != item.Book.Id)
						return false;
			}

			return true;
		}

		public double GetDiscount2()
		{
			if (Items.Count == 2) {
				if (!hasSameBooks())
				 return GetTotal() * 0.05;
			}

			return 0;
		}
	}
}
