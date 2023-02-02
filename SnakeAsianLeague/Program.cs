using Blazor.Analytics;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using SnakeAsianLeague.Areas.Identity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Services;
using SnakeAsianLeague.Data.Services.Backstage;
using SnakeAsianLeague.Data.Services.Interface;
using SnakeAsianLeague.Data.Services.MarketPlace;
using SnakeAsianLeague.Data.Services.Metamask;
using SnakeAsianLeague.Data.Services.Personal;
using SnakeAsianLeague.Data.Services.Products;
using SnakeAsianLeague.Data.Services.SnakeServerService;
using System.Text;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OpenTelemetry.Metrics;
using SnakeAsianLeague.Data.Services.BlockChain;
using SnakeAsianLeague.Data.Services.Commodity;
using Microsoft.AspNetCore.Rewrite;
using SnakeAsianLeague.Data.Services.WarmUpActivities;
using SnakeAsianLeague.Data.Entity.View;
using SnakeAsianLeague.Data.Services.ForwardUrl;
using SnakeAsianLeague.Data.Contracts;
using SnakeAsianLeague.Data.Services.AuthManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("dev");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//var config = new MySQLConfig();
//builder.Configuration.GetSection(MySQLConfig.Section).Bind(config);
//var connectionString = $"Server={config.IP};Port={config.Port};database={config.DatabaseName};user id={config.User};password={config.Password}";

builder.WebHost.UseSentry(options => options.TracesSampler = context =>
{
    if(context.TransactionContext.Name.Contains("/health/")) 
        return 0;
    return null;
});


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; }); //����
builder.Services.AddOpenTelemetryMetrics(b => b.AddAspNetCoreInstrumentation().AddPrometheusExporter());

builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddSingleton<AsiaLeagueScheduleService>();
builder.Services.AddSingleton<AsiaLeagueS1PrizeService>();
builder.Services.AddSingleton<QualifyingCompetitionRecordService>();
builder.Services.AddSingleton<GuildMemberService>();
builder.Services.AddSingleton<AsiaLeaguePlaceService>();
builder.Services.AddSingleton<AsiaLeagueRegistrationService>();
builder.Services.AddSingleton<ProfileService>();
builder.Services.AddSingleton<AwardInfoService>();
builder.Services.AddSingleton<OfficialWebsiteData>();
builder.Services.AddSingleton<SponsorService>();
builder.Services.AddSingleton<S2PrizeService>();
builder.Services.AddSingleton<AsiaLeagueFinalQualifiedIdentityService>();
builder.Services.AddSingleton<AwardService>();
builder.Services.AddSingleton<NFTService>();
builder.Services.AddSingleton<OptionService>();
builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<MetamaskTransfer>();
builder.Services.AddSingleton<CommodityServices>();
builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<SnakeTableService>();
builder.Services.AddSingleton<WarmUpActivitiesService>();
builder.Services.AddSingleton<GetUrlView>();
builder.Services.AddSingleton<BlockChainProcessorSever>();
builder.Services.AddSingleton<ForwardUrlService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



builder.Services.AddHealthChecks();


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

builder.Services.AddScoped<IAuthManagement, AuthManagementService>();

//builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();




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

var cdnEnabled = Convert.ToBoolean( builder.Configuration["CDN:Enabled"]);
if(cdnEnabled)
{
    var cdnUrl = builder.Configuration["CDN:Url"];
    // https://stackoverflow.com/questions/49023794/redirecting-https-site-to-non-www-in-asp-net-core-application
    var options = new RewriteOptions().Add(new RedirectHostRule(cdnUrl));

    app.UseRewriter(options);
    
    Console.WriteLine($"=== CDN Enabled with Url({cdnUrl}) ===");
}
else
    Console.WriteLine("=== CDN Disabled ===");



if (!app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = context => 
        { 
            context.Context.Response.Headers.Append("Cache-Control", "max-age=1800"); 
        }
    });
}
app.UseStaticFiles();



app.UseOpenTelemetryPrometheusScrapingEndpoint();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSentryTracing();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints => 
{ 
    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions  
    {  
        Predicate = _ => false,  
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse  
    });
    
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions  
    {  
        Predicate = reg => false,  
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse  
    });
});

app.Run();
