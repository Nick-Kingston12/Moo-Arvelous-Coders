using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;

var builder = WebApplication.CreateBuilder(args);

// Connection strings from appsettings.json
var identityConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var mooConnection = builder.Configuration.GetConnectionString("MooArvelousConnection")
    ?? throw new InvalidOperationException("Connection string 'MooArvelousConnection' not found.");

// Identity database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConnection));

builder.Services.AddDbContext<MooArvelousDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MooArvelousConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity config
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index1}/{id?}");

app.MapRazorPages();
app.Run();


