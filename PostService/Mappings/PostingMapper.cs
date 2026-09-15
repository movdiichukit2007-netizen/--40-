using PostService.Dtos;
using PostService.Models;

namespace PostService.Mappings;

public static class PostingMapper
{
    public static Posting ToModel(PostingPostDto dto)
    {
        return new Posting
        {
            Description = dto.Description,
            WeightKg = dto.WeightKg,
            DeliveryType = dto.DeliveryType
        };
    }

    public static Posting ToModel(PostingPutDto dto)
    {
        return new Posting
        {
            Description = dto.Description,
            WeightKg = dto.WeightKg,
            DeliveryType = dto.DeliveryType
        };
    }

    public static PostingGetDto ToDto(Posting posting)
    {
        return new PostingGetDto
        {
            Id = posting.Id,
            Description = posting.Description,
            WeightKg = posting.WeightKg,
            DeliveryType = posting.DeliveryType,
            DeliveryCost = posting.DeliveryCost,
            CreatedAt = posting.CreatedAt
        };
    }
}
