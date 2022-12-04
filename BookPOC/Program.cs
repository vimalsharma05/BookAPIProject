using BookAPI.Data;
using BookAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

//Use for InMemoryDatabase
//builder.Services.AddDbContext<BookAPIDbContext>(options => options.UseInMemoryDatabase("BooksDb"));

//Use for Sql Serer Database
builder.Services.AddDbContext<BookAPIDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("BooksApiConnectionStrings")));

var app = builder.Build();
app.MapHealthChecks("/health");

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
