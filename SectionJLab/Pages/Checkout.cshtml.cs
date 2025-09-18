using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionJLab.Data;
using SectionJLab.Models;
using System.ComponentModel.DataAnnotations;

namespace SectionJLab.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> CartItems { get; set; } = new();

        [BindProperty]
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{2,}$", ErrorMessage = "First name must contain only letters.")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{2,}$", ErrorMessage = "Last name must contain only letters.")]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^[\w\s\.,#\-]{5,100}$", ErrorMessage = "Invalid address.")]
        public string Address { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{2,}$", ErrorMessage = "City must contain only letters.")]
        public string City { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Use 2-letter province abbreviation.")]
        public string Province { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code.")]
        public string PostalCode { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [BindProperty]
        [Required]
        //[CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCardNumber { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Invalid expiry date (MM/YY).")]
        public string ExpiryDate { get; set; }

        [BindProperty]
        [Required]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Invalid security code.")]
        public string SecurityCode { get; set; }

        public decimal GrandTotal { get; set; }
        public void OnGet()
        {
            CartItems = Models.SessionExtensions.GetObjectFromJson<List<MenuItem>>(HttpContext.Session, "itemCart");
            if (CartItems == null)
                CartItems = new List<MenuItem>();

            GrandTotal = CartItems.Sum(item => item.Price * item.Quantity);
        }

        public IActionResult OnPost()
        {
                CartItems = Models.SessionExtensions.GetObjectFromJson<List<MenuItem>>(HttpContext.Session, "itemCart");
                GrandTotal = CartItems.Sum(item => item.Price * item.Quantity);
           
            if (!ModelState.IsValid)
            {
                if (CartItems == null || !CartItems.Any())
                {
                    ModelState.AddModelError(string.Empty, "Your cart is empty.");
                    return Page();
                }
                return Page();
            }

            // save the order to the database
            var order = new Order
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                City = City,
                Province = Province,
                PostalCode = PostalCode,
                Email = Email,
                Phone = Phone,
                CreditCardNumber = CreditCardNumber,
                ExpiryDate = ExpiryDate,
                SecurityCode = SecurityCode,
                TotalAmount = GrandTotal
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            // Save the order items to the database
            foreach (var item in CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    MenuItemID = item.ID,
                    Quantity = item.Quantity
                };

                _context.OrderItems.Add(orderItem);
            }

            _context.SaveChanges();

            HttpContext.Session.Remove("itemCart");

            return RedirectToPage("./ThankYou");
        }
    }
}
