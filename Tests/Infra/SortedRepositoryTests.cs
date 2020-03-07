using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests: AbstractClassTest<SortedRepository<Measure, MeasureData>, BaseRepository<Measure, MeasureData>>
    {
        private class TestClass : SortedRepository<Measure, MeasureData>
        {
            public TestClass(DbContext c, DbSet<MeasureData> s) : base(c, s) { }

            protected override Task<MeasureData> getData(string id)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var c = new QuantityDbContext(new DbContextOptions<QuantityDbContext>());
            obj = new TestClass(c, c.Measures);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            isNullableProperty(()=>obj.SortOrder, x=>obj.SortOrder=x);
        }
        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            isReadOnlyProperty(obj, propertyName, "_desc");
        }
        [TestMethod]
        public void SetSortingTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void CreateExpressionTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = obj.lambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }
        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void Test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.findProperty());
            }
            Test(null, GetRandom.String());
            Test(null, null);
            Test(null, string.Empty);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s+obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s + obj.DescendingString);
        }
        [TestMethod]
        public void GetNameTest()
        {
            string s;
            void Test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.getName());
            }
            Test(s = GetRandom.String(), s);
            Test(s = GetRandom.String(), s + obj.DescendingString);
            Test(string.Empty, string.Empty);
            Test(string.Empty, null);
        }
        [TestMethod]
        public void SetOrderByTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected,obj.isDescending());
            }
            Test(GetRandom.String(), false);
            Test(GetRandom.String()+obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }
    }
}
