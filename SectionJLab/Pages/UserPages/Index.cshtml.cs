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

namespace SectionJLab.Pages.UserPages
{
    [Authorize(Roles = "User,Admin")]
    public class IndexModel : PageModel
    {
        private readonly SectionJLab.Data.ApplicationDbContext _context;

        public IndexModel(SectionJLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
