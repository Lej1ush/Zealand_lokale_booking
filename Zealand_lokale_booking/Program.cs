using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Repositories;
using Zealand_lokale_booking.Repositories.UserRep;
using Zealand_lokale_booking.Services;
using Zealand_lokale_booking.Services.UserServ;
using Zealand_lokale_booking.Services.RoomServ;
using Zealand_lokale_booking.Repositories;
using Zealand_lokale_booking.Services.SmartBoardServ;
using Zealand_lokale_booking.Services.BookingServ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();



// User service
builder.Services.AddScoped<IUserRepository, UserRepository>();   //logik
builder.Services.AddScoped<IUserService, JsonUserService>();      //db
//builder.Services.AddScoped<JsonFileService>();

// Booking service
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<IBookingService, DbBookingService>();

// Room service
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<IRoomService, DbRoomService>();

//SmartBoard Service 
builder.Services.AddScoped<SmartBoardRepository>();
builder.Services.AddScoped<ISmartBoardService, DbSmartBoardService>();


builder.Services.AddDbContext<UserDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(cookieOptions =>
    {
        cookieOptions.LoginPath = "/LogInPage/LogIn";
        cookieOptions.AccessDeniedPath = "/LogInPage/AccessDenied";
    });

builder.Services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/Users");
    })
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
