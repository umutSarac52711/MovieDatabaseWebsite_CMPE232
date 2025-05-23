using MovieDatabaseWebsite_CMPE232.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore; 
using MovieDatabaseWebsite_CMPE232.Data;              

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents() // Or AddRazorPages() if it's a Blazor Server app from an older template
    .AddInteractiveServerComponents();   // Or .AddInteractiveWebAssemblyComponents(); or .AddServerSideBlazor() for older Blazor Server

// === REGISTER YOUR DBCONTEXT HERE ===
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Choose ONE of the following based on your database:
// For SQL Server:
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else // Optional: Seed database in development
{
    // You might want to add database seeding or migration application here
    // using (var scope = app.Services.CreateScope())
    // {
    //     var dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    //     // dbContext.Database.EnsureCreated(); // or dbContext.Database.Migrate();
    //     // SeedData.Initialize(dbContext); // Your custom seeding logic
    // }
}


app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>() // Or app.MapBlazorHub(); for older Blazor Server
    .AddInteractiveServerRenderMode(); 

app.Run();