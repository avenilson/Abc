using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public class UnitsPage : BasePage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        protected internal UnitsPage(IUnitsRepository r) : base(r)
        {
            PageTitle = "Units";
        }

        public override string ItemId => Item.Id;
        protected internal override Unit ToObject(UnitView view)
        {
            return UnitViewFactory.Create(view);
        }

        protected internal override UnitView ToView(Unit obj)
        {
            return UnitViewFactory.Create(obj);
        }
    }
}
