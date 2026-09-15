using PostService.CommonTypes;
using PostService.Models;

namespace PostService.BusinessLogic;

public class PostingService : IPostingService
{
    private static readonly List<Posting> _postings = new();
    private static int _nextId = 1;

    public List<Posting> GetAll()
    {
        return _postings;
    }

    public Posting? GetById(int id)
    {
        return _postings.FirstOrDefault(p => p.Id == id);
    }

    public Posting Create(Posting posting)
    {
        posting.Id = _nextId++;
        posting.CreatedAt = DateTime.Now;
        posting.DeliveryCost = CalculateDeliveryCost(posting.WeightKg, posting.DeliveryType);

        _postings.Add(posting);
        return posting;
    }

    public bool Update(int id, Posting posting)
    {
        var existing = GetById(id);
        if (existing == null)
            return false;

        existing.Description = posting.Description;
        existing.WeightKg = posting.WeightKg;
        existing.DeliveryType = posting.DeliveryType;
        existing.DeliveryCost = CalculateDeliveryCost(posting.WeightKg, posting.DeliveryType);

        return true;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing == null)
            return false;

        _postings.Remove(existing);
        return true;
    }

    private decimal CalculateDeliveryCost(double weightKg, DeliveryType deliveryType)
    {
        double baseCost = 50 + weightKg * 10;

        double coefficient = deliveryType switch
        {
            DeliveryType.Standard => 1.0,
            DeliveryType.Express => 1.5,
            DeliveryType.International => 2.5,
            _ => 1.0
        };

        return (decimal)(baseCost * coefficient);
    }
}
