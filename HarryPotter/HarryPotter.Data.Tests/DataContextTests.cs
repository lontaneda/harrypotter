using NUnit.Framework;
using ImproveIT.Data;
using System.Configuration;
using NDbUnit.Core;

namespace HarryPotter.Data.Tests
{
    [TestFixture]
    public class DataContextTests
    {

        protected IDataContext _dataContext;
        protected INDbUnitTest _ndbUnitTest;

        [SetUp]
        public void Setup()
        {
            string cnn = ConfigurationManager.ConnectionStrings["storedb_development"].ConnectionString;
            this._ndbUnitTest = new NDbUnit.Core.SqlClient.SqlDbUnitTest(cnn);
            this._ndbUnitTest.ReadXmlSchema("StoreSchema.xsd");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.DeleteAll);

            NHibernate.ISession session = HarryPotter.Data.DataContextBuilder.BuildSession();
            this._dataContext = new ImproveIT.Data.Hibernate.HibernateDataContext(session);
        }
    }
}