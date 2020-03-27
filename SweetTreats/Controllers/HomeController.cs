using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipeBook.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}