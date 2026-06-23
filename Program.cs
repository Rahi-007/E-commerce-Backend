using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // http://localhost:5111/openapi
    app.MapScalarApiReference();        // http://localhost:5111/scalar/v1
}

app.UseHttpsRedirection();

List<Category> Categories = new List<Category>();

app.MapGet("/category", () =>
{
    return Results.Ok(Categories);
});
app.MapPost("/category", () => Results.Created());
app.MapPut("/category", () => Results.NoContent());
app.MapDelete("/category", () => Results.NoContent());

app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Narration { get; set; }
    public DateTime CreatedAt { get; set; }
};