using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week17.Models;

namespace Week17.Pages
{
   // [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AdminPanelModel : PageModel
    {
        public readonly AppDataContext _db;

        [BindProperty(SupportsGet = true)]
        public Product Products { get; set; }

        public AdminPanelModel(AppDataContext db)
        {
            _db = db;
        }
 
        public IActionResult OnPost()
        {
            _db.Products.Add(Products);
            _db.SaveChanges();

            return RedirectToPage("/Product");
        }
    }

}

