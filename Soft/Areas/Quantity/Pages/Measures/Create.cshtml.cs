using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
        public CreateModel(IMeasuresRepository r) : base(r){ }
        public IActionResult OnGet()=> Page();
        public async Task<IActionResult> OnPostAsync()
        {
            if(!await AddObject()) return Page();
            return RedirectToPage("./Index"); //naitab listi
        }
    }
}
