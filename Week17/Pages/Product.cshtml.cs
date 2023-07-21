using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week17.Models;

public class ProductModel : PageModel
{

    public List<Product> Products { get; set; }
    public string DebugString { get; set; }

    public readonly AppDataContext _db;
    public ProductModel(AppDataContext db)
    {
        _db = db;
    }

    [BindProperty(SupportsGet = true)]
    public string NameOrType { get; set; }

    public void OnGet(string nameortype)
    {
        NameOrType = nameortype;

        Products = _db.Products.ToList();
    }

    public void OnGetDelete(string Id)
    {
        _db.Remove(_db.Products.Find(Id));
        _db.SaveChanges();
    }
    [BindProperty(SupportsGet = true)]
    public string ImageName { get; set; }

}

