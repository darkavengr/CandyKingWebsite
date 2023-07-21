using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Week17.Models;

namespace Week17.Pages
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AdminPanelUpdateModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public readonly AppDataContext _db;

        public Product Products { get; set; }

        public AdminPanelUpdateModel(AppDataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = _db.Products.Find(Id);

        }

        public void OnPost()
        {
            _db.Products.Update(Products);
            _db.SaveChanges();
        }
    }
}