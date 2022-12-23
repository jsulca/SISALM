using Microsoft.EntityFrameworkCore;
using SISALM.Contextos;
using SISALM.Logicas.General;
using SISALM.Logicas.Servicios.General;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
                //.Addn(x =>
                //{
                //    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //}); ;

var services = builder.Services;
var configuration = builder.Configuration;

#region Adicionales

#endregion

#region Contextos

services.AddDbContext<SISALMContexto>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("SISALM_PG")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //options.UseSqlServer(configuration.GetConnectionString("SISALM")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion

#region Logicas

services.AddScoped<IMaterialServicio, MaterialLogica>()
    .AddScoped<IMetaDatoServicio, MetaDatoLogica>()
    .AddScoped<IAlmacenServicio, AlmacenLogica>();

#endregion

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
