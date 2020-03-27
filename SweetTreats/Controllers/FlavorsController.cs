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
  // [Authorize] 
  public class FlavorsController : Controller
  {
    private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    
    public FlavorsController(UserManager<ApplicationUser> userManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    
    public ActionResult Index()
    {
      List<Flavors> model = _db.Flavors.ToList();
      return View(model);

      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userFlavors = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id);
      // return View(userFlavors);
    }

    public ActionResult Create()
    {
      ViewBag.TreatsId = new SelectList(_db.Treats, "TreatsId", "Name");
      return View();
    }

    
    [HttpPost]
    public async Task<ActionResult> Create(Flavors flavor, int TreatsId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      if (TreatsId != 0)
      {
        _db.TreatsFlavors.Add(new TreatsFlavors() { TreatsId = TreatsId, FlavorsId = flavor.FlavorsId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
          .Include(flavor => flavor.Treats)
          .ThenInclude(join => join.Treats)
          .FirstOrDefault(flavor => flavor.FlavorsId == id);
      return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorsId == id);
      ViewBag.TreatsId = new SelectList(_db.Treats, "TreatsId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavors flavor, int TreatsId)
    {
      if (TreatsId != 0)
      {
        _db.TreatsFlavors.Add(new TreatsFlavors() { TreatsId = TreatsId, FlavorsId = flavor.FlavorsId });
      }
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorsId == id);
      ViewBag.TreatsId = new SelectList(_db.Treats, "TreatsId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavors flavor, int TreatsId)
    {
      if (TreatsId != 0)
      {
        _db.TreatsFlavors.Add(new TreatsFlavors() { TreatsId = TreatsId, FlavorsId = flavor.FlavorsId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorsId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorsId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId)
    {
      var joinEntry = _db.TreatsFlavors.FirstOrDefault(entry => entry.TreatsFlavorsId == joinId);
      _db.TreatsFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}