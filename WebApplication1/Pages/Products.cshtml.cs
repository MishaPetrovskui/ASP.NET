using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductsService _products;

        public List<Product> Products => _products.GetAll();

        [BindProperty]
        public Product CurrentProduct { get; set; } = new Product();

        public ProductsModel(ProductsService products)
        {
            _products = products;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _products.Add(CurrentProduct);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false });
            }

            _products.Update(id, CurrentProduct);
            return new JsonResult(new { success = true });
        }

        public IActionResult OnPostDelete(int id)
        {
            _products.Delete(id);
            return new JsonResult(new { success = true });
        }
    }
}