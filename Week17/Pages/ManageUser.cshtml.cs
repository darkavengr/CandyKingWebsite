using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Week17.Models;

namespace Week17.Pages
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class ManageUserModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<IdentityRole> roles;

        public  UserManager<AppUser> _userManager;
        public List<AppUser> Users { get; set; }

        public ManageUserModel(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            roles = await _roleManager.Roles.ToListAsync();     // get list of roles
            Users=  await _userManager.Users.ToListAsync();     // get list of users
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async Task<IActionResult> OnGetDeleteAsync()
        {
            var role=await _roleManager.FindByIdAsync(Id);          // find role
            var result=await _roleManager.DeleteAsync(role);        // delete role

            return RedirectToPage("/ManagerUser");

        }
        public async Task<IActionResult> OnGetDeleteUserAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);          // find user
            var result = await _userManager.DeleteAsync(user);      // delete user

            return RedirectToPage("/ManagerUser");

        }


    }
}
