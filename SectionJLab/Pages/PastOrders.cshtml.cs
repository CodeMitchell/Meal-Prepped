using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionJLab.Data;
using SectionJLab.Models;
using System.Linq;

namespace SectionJLab.Pages
{
    public class PastOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PastOrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> PastOrders { get; set; }

        public void OnGet()
        {
            PastOrders = _context.Orders
                                 .OrderByDescending(o => o.OrderDate)
                                 .Take(10) // Limit to the latest 10 orders
                                 .ToList();
        }
    }
}
