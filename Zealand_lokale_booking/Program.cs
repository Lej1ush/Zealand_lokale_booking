using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Repositories;
using Zealand_lokale_booking.Services;
using Zealand_lokale_booking.Services.UserServ;
using Zealand_lokale_booking.Repositories.UserRep;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*builder.Services.AddSingleton<IUserService, UserMockService>();   */              //mock

//builder.Services.AddScoped<JsonFileService>();                                      //json
//builder.Services.AddScoped<IUserService, JsonUserService>();                   //json

//json-db
//builder.Services.AddScoped<DataSeeder>();
//builder.Services.AddScoped<JsonFileService>();
//builder.Services.AddScoped<JsonUserService>();
// User service
//builder.Services.AddScoped<IUserRepository, UserRepository>();// 
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IUserService, DbUserService>();
//builder.Services.AddSingleton<IUserService, UserMockService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, DbUserService>();

// Booking service
builder.Services.AddSingleton<BookingRepository>();
builder.Services.AddScoped<BookingService>();

// Room service
builder.Services.AddSingleton<RoomRepository>();
builder.Services.AddScoped<RoomService>();


builder.Services.AddDbContext<UserDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});



builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/LogInPage/LogIn";

});
builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AuthorizeFolder("/Users");

}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);//json



var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider.GetRequiredService<IDbUserService>();
//    await ((DbUserService)service).SeedFromJsonAsync();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

