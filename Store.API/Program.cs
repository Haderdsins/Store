using Microsoft.EntityFrameworkCore;
using Store.DAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseNpgsql("Host=localhost;Port=5432;Database=store_db;Username=postgres;Password=postgres");
});
//var connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddSingleton<StoreDbContext>(options => options.UseNpgsql(connection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();