#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FptBook.Data;
using FptBook.Models;
using FptBook.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace FptBook.Controllers
{
    public class CartsController : Controller
    {
        private readonly FptBookContext _context;
        private readonly UserManager<FptBookUser> _userManager;

        public CartsController(FptBookContext context, UserManager<FptBookUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);


            return View(_context.Cart.Where(c => c.UId == thisUserId));


        }


    //    GET: Carts
    //public async Task<IActionResult> Index()
    //    {
    //        var fptBookContext = _context.Cart.Include(c => c.Book).Include(c => c.User);
    //        return View(await fptBookContext.ToListAsync());
    //    }
        private bool CartExists(string id)
        {
            return _context.Cart.Any(e => e.UId == id);
        }
    }
    //public class CartsController : Controller
    //{

    //    private readonly FptBookContext _context;
    //    private readonly UserManager<FptBookUser> _userManager;

    //    public object Session { get; private set; }

    //    public CartsController(FptBookContext context, UserManager<FptBookUser> userManager)
    //    {
    //        _context = context;
    //        _userManager = userManager;
    //    }

    //    #region Cart
    //    public List<Cart> GetCart()
    //    {
    //        List<Cart> lstCart = Session as List<Cart>;
    //        if (lstCart == null)
    //        {
    //            lstCart = new List<Cart>();
    //            Session = lstCart;
    //        }
    //        return lstCart;
    //    }

    //    public ActionResult AddCart(string isbn, string strURL)
    //    {
    //        Book book = _context.Book.SingleOrDefault(b => b.Isbn == isbn);
    //        if (book == null)
    //        {
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<Cart> lstCart = GetCart();
    //        Cart Cart = lstCart.Find(n => n.BookIsbn == isbn);
    //        if (Cart == null)
    //        {
    //            //Cart = new Cart.isbn;
    //            lstCart.Add(Cart);
    //            return Redirect(strURL);
    //        }
    //        else
    //        {

    //            return Redirect(strURL);
    //        }
    //    }

    //    public ActionResult UpdateCart(string isbn, FormCollection fc)
    //    {
    //        Book book = _context.Book.SingleOrDefault(n => n.Isbn == isbn);
    //        if (book == null)
    //        {
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<Cart> lstCart = GetCart();
    //        Cart cart = lstCart.SingleOrDefault(n => n.BookIsbn == isbn);
    //        if (cart != null)
    //        {
    //            int Quantity = Convert.ToInt32(fc["txtQuantity"].ToString());
    //            if (Quantity > 0)
    //            {
    //                if (Quantity >= cart.Quantity)
    //                {
    //                    cart.Quantity = Convert.ToInt32(cart.Quantity);
    //                }
    //                else
    //                {
    //                    cart.Quantity = Quantity;
    //                }
    //            }
    //            else
    //            {
    //                lstCart.RemoveAll(n => n.BookIsbn == isbn);
    //            }
    //            if (lstCart.Count == 0)
    //            {
    //                //Session["Cart"] = null;
    //                return RedirectToAction("Index", "Home");
    //            }
    //            else
    //            {
    //                return RedirectToAction("Cart");
    //            }
    //        }
    //        return RedirectToAction("Cart");
    //    }

    //    public ActionResult DeleteCart(string isbn)
    //    {
    //        Book book = _context.Book.SingleOrDefault(n => n.Isbn == isbn);
    //        if (book == null)
    //        {
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<Cart> lstCart = GetCart();
    //        Cart cart = lstCart.SingleOrDefault(n => n.BookIsbn == isbn);
    //        if (cart != null)
    //        {
    //            lstCart.RemoveAll(n => n.BookIsbn == isbn);
    //        }
    //        if (lstCart.Count == 0)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }
    //        return RedirectToAction("Cart");
    //    }

    //    public ActionResult Cart()
    //    {
    //        if (Session == null)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }
    //        List<Cart> lstCart = GetCart();
    //        return View(lstCart);
    //    }

    //    private int TotalQuantity()
    //    {
    //        int _TotalQuantity = 0;
    //        List<Cart> lstCart = Session as List<Cart>;
    //        if (lstCart != null)
    //        {
    //            _TotalQuantity = lstCart.Sum(n => n.Quantity);
    //        }
    //        return _TotalQuantity;
    //    }

    //    private double Total()
    //    {
    //        double _Total = 0;
    //        List<Cart> lstCart = Session as List<Cart>;
    //        if (lstCart != null)
    //        {
    //            _Total = lstCart.Sum(n => n.Total);
    //        }
    //        return _Total;
    //    }

    //    public ActionResult CartPartial()
    //    {
    //        ViewBag.TotalQuantity = TotalQuantity();
    //        return PartialView();
    //    }

    //    public ActionResult TotalCart()
    //    {
    //        if (Total() <= 0)
    //        {
    //            return PartialView();
    //        }
    //        ViewBag.Total = Total();
    //        return PartialView();
    //    }

    //    public ActionResult EditCart()
    //    {
    //        if (Session == null)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }
    //        List<Cart> lstCart = GetCart();
    //        return View(lstCart);
    //    }
    //}
}
