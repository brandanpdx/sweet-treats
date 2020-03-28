using Microsoft.AspNetCore.Mvc;
using SweetTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly SweetTreatsContext _db;

    public TreatsController(SweetTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treats> model = _db.Treats.ToList();
      return View(model);
    }
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(Treats treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
          .Include(treat => treat.Flavors)
          .ThenInclude(join => join.Flavors)
          .FirstOrDefault(treat => treat.TreatsId == id);
      return View(thisTreat);
    }
    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatsId == id);
      return View(thisTreat);
    }
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Treats treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatsId == id);
      return View(thisTreat);
    }
    [Authorize]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatsId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}