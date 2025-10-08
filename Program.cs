using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;

var builder = WebApplication.CreateBuilder(args);

// -----------------------
// Database connection
// -----------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Enable database developer page for errors in development
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// -----------------------
// Identity setup with roles
// -----------------------
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// -----------------------
// Add MVC and Razor Pages
// -----------------------
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// -----------------------
// Seed roles if they don’t exist
// -----------------------
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = new[] { "Farmer", "Buyer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// -----------------------
// Middleware
// -----------------------
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

// -----------------------
// Routes
// -----------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index1}/{id?}");

app.MapRazorPages(); // Required for Identity pages like Login/Register

app.Run();
