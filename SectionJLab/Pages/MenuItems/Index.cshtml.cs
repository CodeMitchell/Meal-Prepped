using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SectionJLab.Data;
using SectionJLab.Models;

namespace SectionJLab.Pages.MenuItems
{
    [Authorize(Roles = "User,Admin")]
    public class IndexModel : PageModel
    {
        private readonly SectionJLab.Data.ApplicationDbContext _context;

        public IndexModel(SectionJLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MenuItem = await _context.MenuItem.ToListAsync();
        }

        [BindProperty]
        public int ItemId { get; set; }

        public IActionResult OnPostAddToCart()
        {
            var cart = Models.SessionExtensions.GetObjectFromJson<List<MenuItem>>(HttpContext.Session, "itemCart");
            if (cart == null)
                cart = new List<MenuItem>();

            var itemToAdd = _context.MenuItem.FirstOrDefault(i => i.ID == ItemId);

            if (itemToAdd != null)
            {
                var existingItem = cart.FirstOrDefault(i => i.ID == itemToAdd.ID);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    itemToAdd.Quantity = 1;
                    cart.Add(itemToAdd);
                }

                Models.SessionExtensions.SetObjectAsJson(HttpContext.Session, "itemCart", cart);
            }

            return RedirectToPage(); 
        }
    }
}
