//using QuanLyTuyenDung.DAO;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();




//builder.Services.AddScoped<ViecLamDAO>(); //Đăng kí DAO
//builder.Services.AddScoped<NguoiDungDAO>();
//builder.Services.AddScoped<UngTuyenDAO>();
//builder.Services.AddScoped<TaiKhoanDAO>();

//// Thêm dịch vụ session
//builder.Services.AddSession(options =>
//{
//	options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn của session
//	options.Cookie.HttpOnly = true;
//	options.Cookie.IsEssential = true;
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Home/Error");
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseSession();

//app.UseAuthorization();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


using Microsoft.EntityFrameworkCore;
using QuanLyTuyenDung.DAO;
using QuanLyTuyenDung.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<ViecLamDAO>(); //Đăng kí DAO
builder.Services.AddScoped<NguoiDungDAO>();
builder.Services.AddScoped<UngTuyenDAO>();
builder.Services.AddScoped<TaiKhoanDAO>();

// Thêm dịch vụ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn của session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}*/
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Sử dụng session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

