using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class BaseTest<TClass, TBaseClass> where TClass : new()
    {
        [TestMethod]
        public void CanCreateTest() //saab luua 
        {
            Assert.IsNotNull(new TClass());
        }
        [TestMethod]
        public void IsInheritedTest() //on MeasureDatast parit
        {
            Assert.AreEqual(typeof(TBaseClass), new TClass().GetType().BaseType);
        }
    }
}