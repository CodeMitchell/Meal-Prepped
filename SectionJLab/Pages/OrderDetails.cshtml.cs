using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionJLab.Data;
using SectionJLab.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SectionJLab.Pages
{
    public class OrderDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public void OnGet(int id)
        {
            Order = _context.Orders.FirstOrDefault(o => o.ID == id);
            OrderItems = _context.OrderItems.Where(oi => oi.OrderID == id)
                                            .Include(oi => oi.MenuItem)
                                            .ToList();
        }
    }
}
