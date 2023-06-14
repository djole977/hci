using HCI_Djole.Business.Interfaces;
using HCI_Djole.Business.Services;
using HCI_Djole.Data;
using HCI_Djole.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Services
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

SeedDatabase(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Flights}/{id?}");
app.MapRazorPages();

app.Run();

//DATABASE SEED - BORING
void SeedDatabase(IApplicationBuilder app)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        SeedData(dbContext);
        SeedRoles(roleManager);
        SeedUsers(userManager);
        AssignRolesToUsers(userManager);
    }
}

void SeedData(ApplicationDbContext dbContext)
{
    if (!dbContext.Cities.Any() && !dbContext.Airports.Any() && !dbContext.FlightRoutes.Any())
    {
        var routes = new List<FlightRoute>
        {
            new FlightRoute { AirportFrom = new Airport { City = new City { Name = "Ni�" }, Label = "INI" },
                AirportTo = new Airport { City = new City { Name = "Beograd" }, Label = "BEG" } },
            new FlightRoute { AirportFrom = new Airport { City = new City { Name = "Vienna" }, Label = "VIE" }, 
                AirportTo = new Airport { City = new City { Name = "Rim" }, Label = "ROM" } },
            new FlightRoute { AirportFrom = new Airport { City = new City { Name = "Minhen" }, Label = "MUC" }
            , AirportTo = new Airport { City = new City { Name = "New York" }, Label = "NYC" } },
            new FlightRoute { AirportFrom = new Airport { City = new City { Name = "Abu Dabi" }, Label = "AUH" },
                AirportTo = new Airport { City = new City { Name = "Istanbul" }, Label = "IST" } },
            new FlightRoute { AirportFrom = new Airport { City = new City { Name = "Berlin" }, Label = "BER" },
                AirportTo = new Airport { City = new City { Name = "London" }, Label = "LON" } }
        };

        dbContext.FlightRoutes.AddRange(routes);
        dbContext.SaveChanges();
    }
}

void SeedRoles(RoleManager<IdentityRole> roleManager)
{
    if (!roleManager.RoleExistsAsync("Administrator").GetAwaiter().GetResult())
    {
        var adminRole = new IdentityRole("Administrator");
        roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
    }
}

void SeedUsers(UserManager<IdentityUser> userManager)
{
    if (userManager.FindByNameAsync("admin@singi.com").GetAwaiter().GetResult() == null)
    {
        var adminUser = new IdentityUser
        {
            UserName = "admin@singi.com",
            Email = "admin@singi.com"
        };
        userManager.CreateAsync(adminUser, "Admin123!").GetAwaiter().GetResult();
    }

    if (userManager.FindByNameAsync("user@singi.com").GetAwaiter().GetResult() == null)
    {
        var normalUser = new IdentityUser
        {
            UserName = "user@singi.com",
            Email = "user@singi.com"
        };

        userManager.CreateAsync(normalUser, "User123!").GetAwaiter().GetResult();
    }
}

void AssignRolesToUsers(UserManager<IdentityUser> userManager)
{
    var adminUser = userManager.FindByNameAsync("admin@singi.com").GetAwaiter().GetResult();
    var normalUser = userManager.FindByNameAsync("user@singi.com").GetAwaiter().GetResult();

    if (adminUser != null)
    {
        userManager.AddToRoleAsync(adminUser, "Administrator").GetAwaiter().GetResult();
    }
}