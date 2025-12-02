// Program.cs
using FestivalCompanion.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. REGISTRATIE VAN JOUW SERVICES
// Zorg dat je de juiste namespace toevoegt voor jouw DbContext
// Voor nu gebruik ik een placeholder, pas deze aan naar de naam van jouw DbContext
builder.Services.AddDbContext<ApplicationDbContext>(); // <-- Jouw DbContext moet hier staan

// Registreer de PasswordHasher zodat deze in andere klassen geïnjecteerd kan worden
builder.Services.AddSingleton<FestivalCompanion.Models.PasswordHasher>();

// 2. BUILD APP
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
