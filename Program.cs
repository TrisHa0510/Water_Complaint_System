using Microsoft.EntityFrameworkCore;
using WaterComplaintSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container - Practical 1
builder.Services.AddControllersWithViews();

// Practical 11: Configure SQLite Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Practical 9: Configure Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Practical 10: Configure Response Caching
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

// Configure Kestrel to use ports 5000 and 5001
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000);
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated(); // Creates database if not exists
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Practical 9: Enable Session
app.UseSession();

// Practical 10: Enable Response Caching
app.UseResponseCaching();

app.UseAuthorization();

// Practical 4: Configure routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
