using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ResraurantLayer.Services;
using Restaurant.WebApi.Middleware;
using RestaurantLayer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWaiterRepository, WaiterRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICashierRepository, CashierRepository>();
builder.Services.AddScoped<ICookerRepository, CookerRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMenuCategoryService, MenuCategoryService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IWaiterService, WaiterService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ICookerService, CookerService>();
builder.Services.AddScoped<ICashierService, CashierService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scope = scopeFactory.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbContext.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
//
app.UseAuthorization();

app.MapControllers();

app.Run();
