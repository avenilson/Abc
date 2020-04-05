﻿using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
    public class MeasureTermsPage : CommonPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {
        protected internal MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Measure Terms";
            Measures = createSelectList<Measure, MeasureData>(m);
        }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();

        protected internal override string GetPageUrl() => "/Quantity/MeasureTerms";

        protected internal override MeasureTerm ToObject(MeasureTermView view) => MeasureTermViewFactory.Create(view);

        protected internal override MeasureTermView ToView(MeasureTerm obj) => MeasureTermViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Measures { get; }
        public string GetMeasureName(string measureId)
        {
            foreach(var m in Measures)
                if (m.Value == measureId)
                    return m.Text;
            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null
                ? base.GetPageSubTitle()
                : $"For {GetMeasureName(FixedValue)}";
        }
    }
}
