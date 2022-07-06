using Hangfire;
using HangFire.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddHangfire(config=>config.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFireConnection")));

builder.Services.AddHangfireServer();



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
app.UseHangfireDashboard("/hangfire");



app.UseRouting();

app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
