using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CategoryService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // http://localhost:5111/openapi
    app.MapScalarApiReference();        // http://localhost:5111/scalar/v1
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();