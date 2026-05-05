using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Repositories.UserRep;
using Zealand_lokale_booking.Services;
using Zealand_lokale_booking.Services.UserServ;

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDbUserService, DbUserService>();


builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


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

