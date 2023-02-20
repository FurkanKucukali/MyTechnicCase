using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;
using MyTechnic_Case.Core;
using MyTechnic_Case.DataAcess;
using Newtonsoft.Json;
using MyTechnic_Case.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IUnitOfWork, UnitofWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShiftTeamService, ShiftTeamService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<ITeamService, TeamService>();



builder.Services.AddDbContext<MyTechnic_CaseDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DevConnection");
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("MyTechnic_Case.DataAcess"));
});

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<MyTechnic_CaseDbContext>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
