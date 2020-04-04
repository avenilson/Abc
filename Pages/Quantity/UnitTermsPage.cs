using System;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public class UnitTermsPage : CommonPage<IUnitTermsRepository, UnitTerm, UnitTermView, UnitTermData>
    {
        protected internal UnitTermsPage(IUnitTermsRepository r) : base(r)
        {
            PageTitle = "Unit Terms";
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return String.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
        }

        protected internal override string GetPageUrl() => "/Quantity/UnitTerms";

        protected internal override UnitTerm ToObject(UnitTermView view)
        {
            return UnitTermViewFactory.Create(view);
        }

        protected internal override UnitTermView ToView(UnitTerm obj)
        {
            return UnitTermViewFactory.Create(obj);
        }
    }
}
