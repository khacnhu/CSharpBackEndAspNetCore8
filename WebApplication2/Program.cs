var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/shirt", () =>
{
    return "tran khac nhu ne";
});

app.MapControllers();

app.Run();
