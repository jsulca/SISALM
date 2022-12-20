var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


#region Rutas MVC

app.MapAreaControllerRoute(
    name: "general",
    areaName: "General",
    pattern: "General/{controller}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "logistica",
    areaName: "Logistica",
    pattern: "Logistica/{controller}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

#endregion

app.Run();
