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
using Microsoft.AspNetCore.Identity;
using Zealand_lokale_booking.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();



// User service

//builder.Services.AddSingleton<JsonFileService>();                     //mock-json     //opretter ASP.NET obj
//builder.Services.AddScoped<IUserService, JsonUserService>();        //mock


builder.Services.AddScoped<IUserRepository, UserRepository>();   //logik
builder.Services.AddScoped<IUserService, JsonUserService>();      //db


// Booking service
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<IBookingService, DbBookingService>();

// Room service
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<IRoomService, DbRoomService>();

//SmartBoard Service 
builder.Services.AddScoped<SmartBoardRepository>();
builder.Services.AddScoped<ISmartBoardService, DbSmartBoardService>();


builder.Services.AddDbContext<UserDbContext>(options =>                           //registrer i DI og forbinder mes mysql
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
        cookieOptions.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/Users");
    })
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

app.UseDeveloperExceptionPage();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles(); 


app.MapRazorPages();
 
/*
 using (var scope = app.Services.CreateScope())
   {
       var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
   
       var passwordHasher = new PasswordHasher<User>();
   
       foreach (var user in context.Users)
       {
           if (!user.Password.StartsWith("AQAAAA"))
           {
               user.Password = passwordHasher.HashPassword(user, user.Password);
           }
       }
   
       context.SaveChanges();
   }
 */


app.Run();
