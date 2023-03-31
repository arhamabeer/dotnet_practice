//using dotnet_mvc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSingleton<IEmployee_Repository, MockEmployeeRepository>();

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

// MVC SERVICE

//app.UseMvcWithDefaultRoute();
app.UseMvc(route =>
{
    route.MapRoute(
        "default",
        "{controller=Home}/{action=AllEmployees}/{id?}"
    );
});

app.UseRouting();



app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=AllEmployees}/{id?}");

app.Run();
