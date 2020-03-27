using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Treats
  {
    public Treats()
    {
      this.Flavors = new HashSet<TreatsFlavors>();
    }

    public int TreatsId { get; set; }
    public string TreatsName { get; set; }
    public virtual ICollection<TreatsFlavors> Flavors { get; set; }
  }
}