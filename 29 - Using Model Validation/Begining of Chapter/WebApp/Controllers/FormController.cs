using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Controllers {

    [AutoValidateAntiforgeryToken]
    public class FormController : Controller {
        private DataContext context;

        public FormController(DataContext dbContext) {
            context = dbContext;
        }

        public async Task<IActionResult> Index(long? id) {
            return View("Form", await context.Products
                .FirstOrDefaultAsync(p => id == null || p.ProductId == id));
        }

        [HttpPost]
        public IActionResult SubmitForm(Product product) {

            if (string.IsNullOrEmpty(product.Name)) {
                ModelState.AddModelError(nameof(Product.Name), "Enter a name");
            }

            if (ModelState.GetValidationState(nameof(Product.Price))
                    == ModelValidationState.Valid && product.Price < 1) {
                ModelState.AddModelError(nameof(Product.Price),
                    "Enter a positive price");
            }

            if (!context.Categories.Any(c => c.CategoryId == product.CategoryId)) {
                ModelState.AddModelError(nameof(Product.CategoryId),
                    "Enter an existing category ID");
            }

            if (!context.Suppliers.Any(s => s.SupplierId == product.SupplierId)) {
                ModelState.AddModelError(nameof(Product.SupplierId),
                    "Enter an existing supplier ID");
            }

            if (ModelState.IsValid) {
                TempData["name"] = product.Name;
                TempData["price"] = product.Price.ToString();
                TempData["categoryId"] = product.CategoryId.ToString();
                TempData["supplierId"] = product.SupplierId.ToString();
                return RedirectToAction(nameof(Results));
            } else {
                return View("Form");
            }
        }

        public IActionResult Results() {
            return View(TempData);
        }
    }
}
