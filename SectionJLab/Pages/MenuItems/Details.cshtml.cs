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
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly SectionJLab.Data.ApplicationDbContext _context;

        public DetailsModel(SectionJLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItem.FirstOrDefaultAsync(m => m.ID == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            else
            {
                MenuItem = menuitem;
            }
            return Page();
        }
    }
}
