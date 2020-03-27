using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Flavors
  {
    public Flavors()
    {
      this.Categories = new HashSet<TreatsFlavors>();
    }

    public int FlavorsId { get; set; }
    public string FlavorsDescription { get; set; }
    public virtual ApplicationUser User { get; set; }

    public ICollection<CategoryFlavors> Categories { get; }
  }
}