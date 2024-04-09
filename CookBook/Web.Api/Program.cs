using Data.AppContext;
using Logic.CookBook.Interfaces;
using Logic.CookBook;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("AppDbContext") ?? null;

    if (connection == null)
    {
        throw new Exception("Could not find database connection!");
    }

    opt.UseMySQL(connection);
});

builder.Services.AddScoped<ICookBookUnitOfWork, CookbookUnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
