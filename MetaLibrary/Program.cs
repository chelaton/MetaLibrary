using MetaLibrary.Core.Services;
using MetaLibrary.Data;
using MetaLibrary.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("PostConnection");
builder.Services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));
//builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();



builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
