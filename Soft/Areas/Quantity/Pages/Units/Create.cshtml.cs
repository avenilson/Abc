using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Soft.Areas.Quantity.Pages.Units
{
    public class CreateModel : UnitsPage
    {
        public CreateModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m){ }

        public IActionResult OnGet()=> Page();
        public async Task<IActionResult> OnPostAsync()
        {
            if(!await AddObject()) return Page();
            return RedirectToPage("./Index"); 
        }
    }
}
