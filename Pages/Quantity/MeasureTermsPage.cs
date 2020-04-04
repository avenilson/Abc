using System;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public class MeasureTermsPage : CommonPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {
        protected internal MeasureTermsPage(IMeasureTermsRepository r) : base(r)
        {
            PageTitle = "Measure Terms";
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return String.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
            
        } 

        protected internal override string GetPageUrl() => "/Quantity/MeasureTerms";

        protected internal override MeasureTerm ToObject(MeasureTermView view)
        {
            return MeasureTermViewFactory.Create(view);
        }

        protected internal override MeasureTermView ToView(MeasureTerm obj)
        {
            return MeasureTermViewFactory.Create(obj);
        }
    }
}
