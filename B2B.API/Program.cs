using Autofac;
using Autofac.Extensions.DependencyInjection;
using B2B.Business.Modules;
using B2B.Core.DependencyResolvers;
using B2B.Core.Extensions;
using B2B.Core.Utilities.IoC;
using B2B.DataAccess;
using B2B.SharedTools;
using B2B.SharedTools.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region SqlServerConnection
var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<B2BDbContext>(opt => { opt.UseSqlServer(conString); });
#endregion
#region JWT
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
builder.Services.AddSwaggerGen();
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);
var appSettingsB = appSettings.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettingsB.Secret);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_b2b";
    options.RequireHttpsMetadata = false;

});

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x => {
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});

#endregion


builder.Services.AddControllers(opt =>
{
 //   opt.Filters.Add(new AuthorizeFilter());
   // opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region AutoFacRepoService
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
#endregion

//var redisSettings = builder.Configuration.GetSection("RedisSettings");
//builder.Services.Configure<RedisSettings>(redisSettings);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDependencyResolvers(new ICoreModule[]{
    new CoreModule()
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
