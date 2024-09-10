using NonFactors.Mvc.Grid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvcGrid();

// Configure MvcGrid options
// builder.Services.Configure<GridGlobalOptions>(options =>
// {
//     options.DefaultPageSize = 5;
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Comment out or remove the HTTPS redirection middleware
    // app.UseHsts();
}

// Comment out or remove the HTTPS redirection middleware
// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Use the following line to bind to localhost on port 5001
app.Run("http://127.0.0.1:5001");
