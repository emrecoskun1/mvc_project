using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController()
    {
        _httpClient = new HttpClient();
    }
    public async Task<IActionResult> Index()
    {
        var apiUrl = "https://finans.truncgil.com/today.json";
        CurrencyModel currencyData = new CurrencyModel();

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            currencyData = JsonConvert.DeserializeObject<CurrencyModel>(jsonString);

            double usdRate = Convert.ToDouble(currencyData.USD.Satýþ);
            double eurRate = Convert.ToDouble(currencyData.EUR.Satýþ);
            double gbpRate = Convert.ToDouble(currencyData.GBP.Satýþ);
            double chfRate = Convert.ToDouble(currencyData.CHF.Satýþ);
            double qarRate = Convert.ToDouble(currencyData.QAR.Satýþ);

            ViewBag.UsdRate = usdRate;
            ViewBag.EurRate = eurRate;
            ViewBag.GbpRate = gbpRate;
            ViewBag.ChfRate = chfRate;
            ViewBag.QarRate = qarRate;


            if (currencyData.USD != null || currencyData.EUR != null || currencyData.GBP != null || currencyData.CHF != null || currencyData.QAR != null)
            {
                ViewBag.Error = 0;
            }
            else
            {
                ViewBag.Error = 1;
            }
        }

        return View(currencyData);
    }
    
}