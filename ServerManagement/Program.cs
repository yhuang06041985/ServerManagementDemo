using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ServerManagement.Components;
using ServerManagement.Data;
using ServerManagement.Models;
using ServerManagement.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ServerReporsitory>();
builder.Services.AddMudBlazorJsApi();
builder.Services.AddMudBlazorDialog();


builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
  );
builder.Services.AddScoped<ServerReporsitory>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
