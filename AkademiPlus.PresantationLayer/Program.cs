using AkademiPlus.BusinessLayer.Abstract;
using AkademiPlus.BusinessLayer.Concrete;
using AkademiPlus.DataAccessLayer.Abstract;
using AkademiPlus.DataAccessLayer.Concrete;
using AkademiPlus.DataAccessLayer.EntityFramework;
using AkademiPlus.DataAccessLayer.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();

builder.Services.AddScoped<IProcessService, ProcessManager>();
builder.Services.AddScoped<IProcessDal, EfProcessDal>();


builder.Services.AddScoped<IUowDal, UowDal>();
var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
