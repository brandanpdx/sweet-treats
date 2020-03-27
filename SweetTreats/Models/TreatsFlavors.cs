namespace SweetTreats.Models
{
  public class TreatsFlavors
  {
    public int TreatsFlavorsId { get; set; }
    public int FlavorsId { get; set; }
    public int TreatsId { get; set; }
    public Flavors Flavors { get; set; }
    public Treats Treats { get; set; }
  }
}