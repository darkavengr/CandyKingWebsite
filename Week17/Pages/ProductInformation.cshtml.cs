using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Week17.Models;

namespace Week17.Pages
{
    public class ProductInformationModel : PageModel
    {
        public Product product { get; set; }
        public readonly AppDataContext _db;
     
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ProductInformationModel(AppDataContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Id = id;
            product=new Product();
            product = _db.Products.Find(Id);         
        }
    }
}
