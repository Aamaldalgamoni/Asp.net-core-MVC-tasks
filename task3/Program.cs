var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // ????? ??? ?????? (?? ???? ??? ???? ????)
    options.Cookie.HttpOnly = true; // ????? ???????
    options.Cookie.IsEssential = true; // ????? ?? ??????? ????? ??????
});
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



// ???? ????? ???????? ??? ????? ? ??? ?????? (Session)




// ??????? ??????? ???????
app.UseSession(); // ????? ???????





app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
