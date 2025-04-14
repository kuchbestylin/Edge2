using Edge.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Paygate.Infrastructure.Extensions;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
.AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();


builder.Services.AddHttpClient();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddPaygate(options =>
{
    options.MerchantId = "10011064270";
    options.MerchantSecret = "test";
    options.Url = "https://secure.paygate.co.za/payhost/process.trans";
});

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