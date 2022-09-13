using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace B2B.SharedTools
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(
              "Bearer", new OpenApiSecurityScheme
              {
                  Description = "JWT Kimlik Doğrulama.Örn - 'Bearer Token'",
                  Name = "Authorization",
                  In = ParameterLocation.Header,
                  Type = SecuritySchemeType.ApiKey,
                  Scheme = "Bearer"
              });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                new OpenApiSecurityScheme{
                Reference = new OpenApiReference{

                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
                },
                Scheme = "oauth2",
                Name= "Bearer",
                In = ParameterLocation.Header,
                },
               new List<string>()
                }
            });

            var xmlFileComment = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlFileComment);
            options.IncludeXmlComments(xmlFullPath);
        }
    }
}
