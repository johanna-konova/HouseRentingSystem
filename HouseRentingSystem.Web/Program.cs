using HouseRentingSystem.Web.ModelBinder;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
	options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
	options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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
    name: "house informatiom",
    pattern: "/House/{action}/{id?}/{information?}",
    defaults: new { Controller = "House" });

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.SeedUsersClaim();
await app.SeedAdmin();

await app.RunAsync();
