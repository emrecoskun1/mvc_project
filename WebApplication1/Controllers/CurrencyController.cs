using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CurrencyController : Controller
    {
     
        [HttpGet]
        public IActionResult CurrencyConvert(string currency, double rate)
        {
            ViewBag.Currency = currency;
            ViewBag.Rate = rate;
            return View();
        }


        [HttpPost]
        public IActionResult CurrencyConvert(string currency, double rate, int amount)
        {
            double result = amount * rate;

            ViewBag.Currency = currency;
            ViewBag.Rate = rate;
            ViewBag.Amount = amount;
            ViewBag.Result = result;

            return View();
        }
    }
}
