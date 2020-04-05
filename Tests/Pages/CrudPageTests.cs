using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    [TestClass]
    public class CrudPageTests : AbstractPageTests<CrudPage<IMeasuresRepository, Measure, MeasureView, MeasureData>,
        BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>> {

        private string fixedFilter;
        private string fixedValue;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            Assert.AreEqual(null, obj.FixedValue);
            Assert.AreEqual(null, obj.FixedFilter);
        }

        [TestMethod] public void ItemTest() {
            isProperty(() => obj.Item, x => obj.Item = x);
        }

        [TestMethod] public void AddObjectTest() {
            var idx = db.list.Count;
            obj.Item = GetRandom.Object<MeasureView>();
            obj.AddObject(fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            TestArePropertyValuesEqual(obj.Item, db.list[idx].Data);
        }

        [TestMethod] public void UpdateObjectTest() {
            GetObjectTest();
            var idx = GetRandom.Int32(0, db.list.Count);
            var itemId = db.list[idx].Data.Id;
            obj.Item = GetRandom.Object<MeasureView>();
            obj.Item.Id = itemId;
            obj.UpdateObject(fixedFilter, fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(db.list[^1].Data, obj.Item);
        }

        [TestMethod] public void GetObjectTest() {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);
            for (var i = 0; i < count; i++) AddObjectTest();
            var item = db.list[idx];
            obj.GetObject(item.Data.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(count, db.list.Count);
            TestArePropertyValuesEqual(item.Data, obj.Item);
        }

        [TestMethod] public void DeleteObjectTest() {
            AddObjectTest();
            obj.DeleteObject(obj.Item.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(0, db.list.Count);
        }

        [TestMethod] public void ToViewTest() {
            var d = GetRandom.Object<MeasureData>();
            var v = obj.ToView(new Measure(d));
            TestArePropertyValuesEqual(d, v);
        }

        [TestMethod] public void ToObjectTest() {
            var v = GetRandom.Object<MeasureView>();
            var o = obj.ToObject(v);
            TestArePropertyValuesEqual(v, o.Data);
        }

    }

}
