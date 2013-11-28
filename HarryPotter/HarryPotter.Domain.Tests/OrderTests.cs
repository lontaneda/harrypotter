using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HarryPotter.Domain.Tests
{

    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        { 
			this._order = new Order();
		}

        [Test]
        public void New_Add2Books_Create2Items()
        { 
			Author	author	= new Author()	{Id = 1, Name = "J. K. Rowling"};
            Book	book1	= new Book()	{Id = 1, Name = "B1", Price = 8, Author = author};
            Book	book2	= new Book()	{Id = 2, Name = "B2", Price = 8, Author = author};

            this._order.addBook(1, book1);
            this._order.addBook(1, book2);

            Assert.AreEqual(2, this._order.Items.Count);
            Assert.AreEqual(book1, this._order.Items[0].Book);
            Assert.AreEqual(book2, this._order.Items[1].Book);
        }

        [Test]
		[TestCase(1, 8)]
		[TestCase(2, 16)]
		[TestCase(5, 40)]
        public void GetTotal_AddNBooks_8xNPesos(int aQuantity, double aResult)
        { 
			Author	author	= new Author()	{Id = 1, Name = "J. K. Rowling"};
            Book	book1	= new Book()	{Id = 1, Name = "B1", Price = 8, Author = author};

            this._order.addBook(aQuantity, book1);

            Assert.AreEqual(aResult, this._order.GetTotal());
        }

        [Test]
        public void OrderHasSameBooks_AddSameBook2Times_MustBeTrue()
        { 
			Author	author	= new Author()	{Id = 1, Name = "J. K. Rowling"};
            Book	book1	= new Book()	{Id = 1, Name = "B1", Price = 8, Author = author};

            this._order.addBook(1, book1);
            this._order.addBook(1, book1);

            Assert.AreEqual(true, this._order.hasSameBooks());
        }
 
        [Test]
        public void OrderHasSameBooks_AddDifferentBooks_MustBeFalse()
        { 
			Author	author	= new Author()	{Id = 1, Name = "J. K. Rowling"};
            Book	book1	= new Book()	{Id = 1, Name = "B1", Price = 8, Author = author};
            Book	book2	= new Book()	{Id = 2, Name = "B2", Price = 8, Author = author};

            this._order.addBook(1, book1);
            this._order.addBook(1, book2);

            Assert.AreEqual(false, this._order.hasSameBooks());
        }

        [Test]
        public void GetDiscount2_Add2DifferentBooks_5PC()
        { 
			Author	author	= new Author()	{Id = 1, Name = "J. K. Rowling"};
            Book	book1	= new Book()	{Id = 1, Name = "B1", Price = 8, Author = author};
            Book	book2	= new Book()	{Id = 2, Name = "B2", Price = 8, Author = author};

            this._order.addBook(1, book1);
            this._order.addBook(1, book2);

            Assert.AreEqual(_order.GetTotal() * 0.05, this._order.GetDiscount2());
        }
   }
}