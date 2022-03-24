using Blazor.Analytics;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SnakeAsianLeague.Areas.Identity;
using SnakeAsianLeague.Data;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Services;
using SnakeAsianLeague.Data.Services.Backstage;
using SnakeAsianLeague.Data.Services.Interface;
using SnakeAsianLeague.Data.Services.Metamask;
using SnakeAsianLeague.Data.Services.SnakeServerService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings:dev");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddSingleton<LoginService>();
//builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<AsiaLeagueScheduleService>();
builder.Services.AddSingleton<AsiaLeagueS1PrizeService>();
builder.Services.AddSingleton<QualifyingCompetitionRecordService>();
builder.Services.AddSingleton<GuildMemberService>();
builder.Services.AddSingleton<AsiaLeaguePlaceService>();
builder.Services.AddSingleton<AsiaLeagueRegistrationService>();
builder.Services.AddSingleton<ProfileService>();
builder.Services.AddSingleton<AwardInfoService>();
builder.Services.AddSingleton<SponsorService>();
builder.Services.AddSingleton<S2PrizeService>();
builder.Services.AddSingleton<AsiaLeagueFinalQualifiedIdentityService>();
builder.Services.AddSingleton<AwardService>();
builder.Services.AddSingleton<NFTService>();

builder.Services.Configure<ExternalServers>(builder.Configuration.GetSection("ExternalServers"));
builder.Services.AddScoped<AppState>();





builder.Services.AddGoogleAnalytics("G-7004ZEJL2X");


builder.Services.AddScoped<IMetamaskInterop, MetamaskBlazorInterop>();
builder.Services.AddScoped<MetamaskInterceptor>();
builder.Services.AddScoped<MetamaskHostProvider>();
builder.Services.AddScoped<IEthereumHostProvider>(serviceProvider =>
{
    return serviceProvider.GetService<MetamaskHostProvider>();
});
builder.Services.AddScoped<IEthereumHostProvider, MetamaskHostProvider>();




builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
