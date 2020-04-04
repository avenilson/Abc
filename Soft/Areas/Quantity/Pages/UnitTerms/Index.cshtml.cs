using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Abc.Soft.Areas.Quantity.Pages.UnitTerms
{
    public class IndexModel : UnitTermsPage
    {
        public IndexModel(IUnitTermsRepository r) : base(r){ }

        public async Task OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
