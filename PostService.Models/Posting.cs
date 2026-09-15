using PostService.CommonTypes;

namespace PostService.Models;

public class Posting
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double WeightKg { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public decimal DeliveryCost { get; set; }
    public DateTime CreatedAt { get; set; }
}
