using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PasswordGenerator.Models;

namespace PasswordGenerator.Controllers
{
  public class HomeController : Controller
  {
    private static Random random = new Random();
    public static string RandomString(int length)
    {
      const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(characters, length).Select(s => s[random.Next(s.Length)]).ToArray()); 
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      int? counter = HttpContext.Session.GetInt32("counter");
      counter = (counter==null) ? 1: counter; 
      counter++;

      ViewBag.Count = counter; 
      ViewBag.passcode = RandomString(14);
      HttpContext.Session.SetInt32("counter", (int)counter);
      // return View();

      TempData["RandomString"] = RandomString(14);
      ViewBag.String = TempData["RandomString"];
      return View();
      
    }

  }
}
