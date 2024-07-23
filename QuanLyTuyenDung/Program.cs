using QuanLyTuyenDung.DAO;
using Microsoft.EntityFrameworkCore;
using QuanLyTuyenDung.Models;

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




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
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=TaiKhoan}/{action=CapNhapTK}/{id?}");

app.Run();
*/

var builder = WebApplication.CreateBuilder(args);

// Cấu hình chuỗi kết nối (connection string)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DataContext với DI container
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký các dịch vụ khác
builder.Services.AddScoped<ViecLamDAO>();
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

// Thêm các dịch vụ cho MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline xử lý HTTP requests
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaiKhoan}/{action=CapNhapUV}/{id?}");

app.Run();

