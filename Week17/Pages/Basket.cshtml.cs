using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using Week17.Models;
using System.Security.Principal;
using System.Linq;
using System.Diagnostics;
using System;

namespace Week17.Pages
{
    [Authorize]
    public class BasketModel : PageModel
    {
        public List<Basket> BasketContents { get; set; }
        public List<Product> Products { get; set; }

        public decimal BasketTotal { get; set; }
        public readonly AppDataContext _db;

        public String DebugOutput { get; set; }

        public BasketModel(AppDataContext db)
        {
            _db = db;
        }

         public void OnGet()
        {
            BasketContents = _db.Basket.ToList();    
        }

        public void OnGetDelete(string Id)
        {
            _db.Remove(_db.Products.Find(Id));
            _db.SaveChanges();
        }


        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }
        public void OnGetAddToBasket(int productid)
        {
  
            Basket basketproduct=new Basket();
          
            basketproduct = _db.Basket.Find(productid);        // find the product in the basket

            if (basketproduct == null)
            {
               Product product = _db.Products.Find(productid);

                basketproduct = new Basket();

                basketproduct.Id = product.Id;
                basketproduct.Name = product.Name;
                basketproduct.Price = product.Price;
                basketproduct.ProductImage = product.ProductImage;
                basketproduct.NumberInBasket = 1;

                ViewData["BasketTotal"] = basketproduct.NumberInBasket;
                _db.Basket.Add(basketproduct);          // add it to the basket contents
                _db.SaveChanges();

            }
            else        // If there is already a product of this type in the basket
            {
           
                basketproduct = _db.Basket.Find(ProductId);        // find the product in the basket
                basketproduct.NumberInBasket++;   // Increment number of products
                basketproduct.Price += basketproduct.Price;
                ViewData["BasketTotal"] = basketproduct.NumberInBasket;

                _db.Basket.Update(basketproduct);          // update basket contents
                _db.SaveChanges();
            }

            BasketContents = _db.Basket.ToList();

       }
    }
}
    