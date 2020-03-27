using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Treats
  {
    public Treats()
    {
      this.Items = new HashSet<TreatsItem>();
    }

    public int TreatsId { get; set; }
    public string TreatsName { get; set; }
    public virtual ICollection<TreatsItem> Flavors { get; set; }
  }
}