using Microsoft.EntityFrameworkCore;
using ProductManagment;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;
using ProductManagment.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductManagmentContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagmentDB")));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped < IMapper < ProductManagment.Entity.Category, ProductManagment.Model.CategoryModel>, CategoryMapper>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMapper<ProductManagment.Entity.Product, ProductManagment.Model.ProductModel>, ProductMapper>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IMapper<ProductManagment.Entity.Package, ProductManagment.Model.PackageModel>, PackageMapper>();
builder.Services.AddScoped<IPackageProductService, PackageProductService>();
builder.Services.AddScoped <IMapper< ProductManagment.Entity.PackageProduct, ProductManagment.Model.PackageProductModel>, PackageProductMapper>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagmentContext>();
    dbContext.Database.Migrate();
}

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
