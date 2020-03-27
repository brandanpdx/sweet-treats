using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Flavors
  {
    public Flavors()
    {
      this.Treats = new HashSet<TreatsFlavors>();
    }

    public int FlavorsId { get; set; }
    public string FlavorsDescription { get; set; }
    public virtual ApplicationUser User { get; set; }

    public ICollection<TreatsFlavors> Treats { get; }
  }
}