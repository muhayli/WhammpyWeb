using Microsoft.EntityFrameworkCore;
using Whammy.DataAccess.Repository;
using Whammy.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Whammy.DataAccess.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Whammy.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();


builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Identity/Account/Login";
    opt.LogoutPath = "/Identity/Account/Logout";
    opt.AccessDeniedPath = "/Identity/Account/AccessDenied";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{


    app.UseExceptionHandler("/Error");


}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
