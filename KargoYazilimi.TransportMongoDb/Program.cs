using KargoYazilimi.TransportMongoDb.Services;
using KargoYazilimi.TransportMongoDb.Services.AboutServices;
using KargoYazilimi.TransportMongoDb.Services.AdminServices;
using KargoYazilimi.TransportMongoDb.Services.BranchService;
using KargoYazilimi.TransportMongoDb.Services.BrandServices;
using KargoYazilimi.TransportMongoDb.Services.CareerApplicationServices;
using KargoYazilimi.TransportMongoDb.Services.GetInTouchSectionServices;
using KargoYazilimi.TransportMongoDb.Services.HowItWorkServices;
using KargoYazilimi.TransportMongoDb.Services.OfferServices;
using KargoYazilimi.TransportMongoDb.Services.ProjectSectionServices;
using KargoYazilimi.TransportMongoDb.Services.QuestionService;
using KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices;
using KargoYazilimi.TransportMongoDb.Services.ShipmentServices;
using KargoYazilimi.TransportMongoDb.Services.SliderServices;
using KargoYazilimi.TransportMongoDb.Services.TestimonialServices;
using KargoYazilimi.TransportMongoDb.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ICareerApplicationService, CareerApplicationService>();
builder.Services.AddScoped<IGetInTouchSectionService, GetInTouchSectionService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IHowItWorkService, HowItWorkService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IProjectSectionService, ProjectSectionService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IShipmentMovementService, ShipmentMovementService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Bu projede bulunan AutoMapper Profile class'larýný bul ver çalýþtýr. Assembly.GetExecutingAssembly = Þu an çalýþan proje içindeki tüm class'larý tara demek. 
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));//appsettings.json içindeki DatabaseSettingsKey bölümünü al,DatabaseSettings class'ýna doldur.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; //IDatabaseSettings isteyen olursa, git DatabaseSettings'i oku ve ona ver.
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "CokkececiJet.Admin.Cookie"; // Tarayýcýdaki çerez adý
        options.LoginPath = "/Account/Login";         // Giriþ yapmayan buraya fýrlatýlýr
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Admin/Login/Index";  // Yetkisi olmayan buraya gider
        options.ExpireTimeSpan = TimeSpan.FromDays(7);    // Çerez ömrü
    });


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
