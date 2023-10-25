var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//session 
builder.Services.AddSession(options =>
{
    //option in a property
    options.IdleTimeout = TimeSpan.FromSeconds(20);

    //because it internally store data in cookie only
    options.Cookie.HttpOnly = true;

    //
    options.Cookie.IsEssential = true;
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

//using the creating session.here tm
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
