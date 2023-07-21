using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Week17.Pages
{
    public class FormModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public string name{ get; set; }

        [BindProperty(SupportsGet = true)]

        [Required]
        public string email { get; set; }

        [BindProperty(SupportsGet = true)]

        public string Submitted { get; set; }


        public void OnGet()
        {

         Message = "You have submitted a GET request";
        }


        public void OnPost(string username,string password)
        {
            Message = "You have submitted a POST request";

            ViewData["Submitted"] = $"Hello, {name}, You have been registered as {email}";
        }
    }


}

