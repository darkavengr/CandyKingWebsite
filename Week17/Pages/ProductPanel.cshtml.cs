using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Week17.Models;

namespace Week17.Pages
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class ProductPanelModel : PageModel
    {
        
        public System.Collections.Generic.List<Product> Products { get; set; }
        public Product ModifyProducts { get; set; }

        public readonly AppDataContext _db;
        public ProductPanelModel(AppDataContext db)
        {
            _db = db;
        }

        public void OnGet()
        {            
            Products = _db.Products.ToList();
        }

        public void OnGetDelete(string Id)
        {
            _db.Remove(_db.Products.Find(Id));
            _db.SaveChanges();
        }

    }
}
