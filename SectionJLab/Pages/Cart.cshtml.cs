using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionJLab.Models;
using System;

namespace SectionJLab.Pages
{
    
    public class CartModel : PageModel
    {
        public decimal GrandTotal { get; set; }
        private readonly SectionJLab.Data.ApplicationDbContext _context;
        public List<MenuItem> myCart { get; set; }

        public CartModel(SectionJLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id, string action)
        {
            myCart = Models.SessionExtensions.GetObjectFromJson<List<MenuItem>>(HttpContext.Session, "itemCart");
            if (myCart == null)
                myCart = new List<MenuItem>();

            if (id != 0)
            {
                var item = _context.MenuItem.FirstOrDefault(i => i.ID == id);
                if (item != null)
                {
                    var cartItem = myCart.FirstOrDefault(i => i.ID == item.ID);
                    if (cartItem != null)
                    {
                        if (action == "add")
                        {
                            cartItem.Quantity++;
                        }
                        else if (action == "remove")
                        {
                            cartItem.Quantity--;
                            if (cartItem.Quantity <= 0)
                            {
                                myCart.Remove(cartItem);
                            }
                        }
                    }
                    else if (action == "add")
                    {
                        item.Quantity = 1;
                        myCart.Add(item);
                    }

                    Models.SessionExtensions.SetObjectAsJson(HttpContext.Session, "itemCart", myCart);
                }
                
            }
                GrandTotal = myCart.Sum(item => item.Price * item.Quantity);
        }
    }
}
