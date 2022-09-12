using B2B.Business.Services.Abstract;
using B2B.Business.Services.Concrete;
using B2B.DataAccess;
using B2B.DataAccess.Repositories.Abstract;
using B2B.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICategoryService),typeof(CategoryService));
// Add services to the container.
var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<B2BDbContext>(opt => { opt.UseSqlServer(conString); });
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
