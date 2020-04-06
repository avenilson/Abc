using System;
using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
    public class UnitFactorsPage : CommonPage<IUnitFactorsRepository, UnitFactor, UnitFactorView, UnitFactorData>
    {
        protected internal UnitFactorsPage(IUnitFactorsRepository r) : base(r)
        {
            PageTitle = "Unit Factors";
        }
        public override string ItemId
        {
            get
            {
                if (Item is null) return String.Empty;
                return $"{Item.SystemOfUnitsId}.{Item.UnitId}";
            }

        }
        protected internal override string GetPageUrl() => "/Quantity/UnitFactors";

        protected internal override UnitFactor ToObject(UnitFactorView view) => UnitFactorViewFactory.Create(view);

        protected internal override UnitFactorView ToView(UnitFactor obj) => UnitFactorViewFactory.Create(obj);
    }
}

