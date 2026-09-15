using PostService.CommonTypes;

namespace PostService.Dtos;

public class PostingPostDto
{
    public string Description { get; set; } = string.Empty;
    public double WeightKg { get; set; }
    public DeliveryType DeliveryType { get; set; }
}

public class PostingPutDto
{
    public string Description { get; set; } = string.Empty;
    public double WeightKg { get; set; }
    public DeliveryType DeliveryType { get; set; }
}

public class PostingGetDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double WeightKg { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public decimal DeliveryCost { get; set; }
    public DateTime CreatedAt { get; set; }
}
