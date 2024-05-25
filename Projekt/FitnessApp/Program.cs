using FitnessApp.Components;
using ClientAPI.Context;
using Microsoft.AspNetCore.Components.Authorization;
using FitnessApp.Data;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Identity;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<MyDBContext>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
//builder.Services.AddSingleton<DataContext>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorizationCore();

//builder.Services.AddSyncfusionBlazor();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<MyDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();