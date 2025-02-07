using DataTier;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignReplacementLaredo_App.Data;
using SignReplacementLaredo_App.Models;
using SignReplacementLaredo_App.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options => {
        options.SignIn.RequireConfirmedAccount = true;
        options.SignIn.RequireConfirmedEmail = true;

    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Identity/Login");
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
//builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddKendo();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<Microsoft.Data.SqlClient.SqlConnection>();


builder.Services.AddTransient<SignReplacementLaredo.IWorkOrderRepository, SignReplacementLaredo.WorkOrderRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IProjectRepository, SignReplacementLaredo.ProjectRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IResTypeRepository, SignReplacementLaredo.ResTypeRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IActivityRepository, SignReplacementLaredo.ActivityRepository>();
builder.Services.AddTransient<SignReplacementLaredo.ITaskRepository, SignReplacementLaredo.TaskRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IPCBusRepository, SignReplacementLaredo.PCBusRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IAccountRepositoy, SignReplacementLaredo.AccountRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IRegionalDistributionCenterRepository, SignReplacementLaredo.RegionalDistributionCenterRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IDepartmentRepository, SignReplacementLaredo.DepartmentRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IFundRepository, SignReplacementLaredo.FundRepository>();
builder.Services.AddTransient<SignReplacementLaredo.INIGPRepository, SignReplacementLaredo.NIGPRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IMaintenanceSectionRepository, SignReplacementLaredo.MaintenanceSectionRepository>();
builder.Services.AddTransient<SignReplacementLaredo.ISignShopRepository, SignReplacementLaredo.SignShopRepository>();
builder.Services.AddTransient<SignReplacementLaredo.IYearRepository, SignReplacementLaredo.YearRepository>();
builder.Services.AddTransient<EMailSender>();
builder.Services.AddTransient<ExportPdf>();

builder.Services.AddTransient<DataTier.Tools>();
builder.Services.AddTransient<DataTier.Interfaces.IUnitOfWork, DataTier.UnitOfWorkSQLServer_MSFT>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
