using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HarryPotter.Domain
{
    public class OrderItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        
        public OrderItem()
        { 
        }
        
        public OrderItem(int aQuantity, Book book)
        {
			this.Quantity = aQuantity;
            this.Book = book;
        }
    }
}
