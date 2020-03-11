using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abc.Pages.Quantity
{
    public abstract class MeasuresPage : PageModel
    {
        protected internal readonly IMeasuresRepository db;

        protected internal MeasuresPage(IMeasuresRepository r)
        {
            db = r;
            PageTitle = "Measures";
        } 

        [BindProperty]
        public MeasureView Item { get; set; }
        public IList<MeasureView> Items { get; set; }

        public string ItemId => Item.Id;
        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string CurrentSort { get; set; } = "Current Sort";
        public string CurrentFilter { get; set; } = "Current Filter";
        public int PageIndex { get; set; } = 3;
        public int TotalPages { get; set; } = 10;

        protected internal async Task<bool> AddObject()
        {
            //TODO see viga tuleb lahendada
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.

            try
            {
                if (!ModelState.IsValid) return false;
                await db.Add(MeasureViewFactory.Create(Item));
            }
            catch
            {
                return false;
            }
            return true;
        }

        protected internal async Task UpdateObject()
        {
            //TODO see viga tuleb lahendada
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.

            await db.Update(MeasureViewFactory.Create(Item));
        }

        protected internal async Task GetObject(string id)
        {
            var o = await db.Get(id);
            Item = MeasureViewFactory.Create(o);
        }

        protected internal async Task DeleteObject(string id)
        {
            await db.Delete(id);
        }
    }
}
