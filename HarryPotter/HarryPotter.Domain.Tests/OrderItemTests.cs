using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HarryPotter.Domain.Tests
{

    [TestFixture]
    public class OrderItemTests
    {
        private OrderItem _orderItem;

        [Test]
        public void New_CreateInstanceWith1Book_Create1Item()
        {
            Book book = new Book() { Id = 2 };
            this._orderItem = new OrderItem(1, book);
            Assert.AreEqual(book, this._orderItem.Book);
        }
    }
}
