using PostService.BusinessLogic;
using PostService.Dtos;
using PostService.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPostingService, PostingService>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/api/postings", (IPostingService service) =>
{
    var postings = service.GetAll();
    var result = postings.Select(PostingMapper.ToDto).ToList();
    return Results.Ok(result);
});

app.MapGet("/api/postings/{id:int}", (int id, IPostingService service) =>
{
    var posting = service.GetById(id);
    if (posting == null)
        return Results.NotFound($"Відправлення з Id={id} не знайдено.");

    return Results.Ok(PostingMapper.ToDto(posting));
});

app.MapPost("/api/postings", (PostingPostDto dto, IPostingService service) =>
{
    var model = PostingMapper.ToModel(dto);
    var created = service.Create(model);
    var resultDto = PostingMapper.ToDto(created);

    return Results.Created($"/api/postings/{created.Id}", resultDto);
});

app.MapPut("/api/postings/{id:int}", (int id, PostingPutDto dto, IPostingService service) =>
{
    var model = PostingMapper.ToModel(dto);
    var updated = service.Update(id, model);

    if (!updated)
        return Results.NotFound($"Відправлення з Id={id} не знайдено.");

    return Results.Ok(PostingMapper.ToDto(service.GetById(id)!));
});

app.MapDelete("/api/postings/{id:int}", (int id, IPostingService service) =>
{
    var deleted = service.Delete(id);
    if (!deleted)
        return Results.NotFound($"Відправлення з Id={id} не знайдено.");

    return Results.NoContent();
});

app.Run();
