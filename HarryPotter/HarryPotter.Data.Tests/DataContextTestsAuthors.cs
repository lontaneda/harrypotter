using System.Collections.Generic;
using NUnit.Framework;
using System.Data;
using HarryPotter.Domain;

namespace HarryPotter.Data.Tests
{

    [TestFixture]
    public class DataContextTestsAuthors
		: DataContextTests
    {
        [Test]
        public void Add_EmptyDatabase_OneRowInserted()
        {
            // Arrange
            Author author = new Author() { Name = "J. K. Rowling" };

            //Act
            this._dataContext.Add<Author>(author);

            //Assert
            DataSet dataSet = this._ndbUnitTest.GetDataSetFromDb();
            Assert.AreEqual(1, dataSet.Tables["authors"].Rows.Count);
        }

        [Test]
        public void GetAll_DatabaseWith3Rows_Get3Rows()
        {
            // Arrange
            this._ndbUnitTest.ReadXml("data/authors.xml");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.Insert);

            //Act
            IList<Author> authors = _dataContext.GetAll<Author>();

            //Assert
            Assert.AreEqual(3, authors.Count);
        }
    }
}