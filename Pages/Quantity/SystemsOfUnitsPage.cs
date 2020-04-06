using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public class SystemsOfUnitsPage : CommonPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>
    {
        protected internal SystemsOfUnitsPage(ISystemsOfUnitsRepository r) : base(r)
        {
            PageTitle = "Systems Of Units";
        }
        public override string ItemId => Item.Id;
        protected internal override string GetPageUrl() => "/Quantity/SystemsOfUnits";
        protected internal override SystemOfUnits ToObject(SystemOfUnitsView view) => SystemOfUnitsViewFactory.Create(view);
        protected internal override SystemOfUnitsView ToView(SystemOfUnits obj) => SystemOfUnitsViewFactory.Create(obj);
    }
}

