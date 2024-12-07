using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;
using ToDo.API.Models;
using ToDo.API.Validators;
using ToDo.Repositories;
using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Repositories;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;
using ToDo.Shared.Constants;

namespace ToDo.API
{

    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            ConfigureServicesDbContext(services);
            ConfigureServicesAuthentication(services);
            ConfigureServicesSwagger(services);
            ConfigureServicesDependencyInjection(services);
            ConfigureServicesValidation(services);



            services.AddControllers();
        }

        private static void ConfigureServicesValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<UserNameModel>, UserNameModelValidator>();
            services.AddTransient<IValidator<UserRegisterModel>, UserRegisterModelValidator>();
            
            services.AddFluentValidationAutoValidation();
        }

        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();

                app.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/")
                    {
                        context.Response.Redirect("/swagger");
                    }
                    else
                    {
                        await next();
                    }
                });

            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }

        private SymmetricSecurityKey GetSymmetricKey()
        {
            var secretKey = Configuration["Secret:Key"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException(Messages.ERRO_SECRET_KEY_NOT_APPSETTINGS);
            }
            if (secretKey.Length < 16)
            {
                throw new InvalidOperationException(Messages.ERRO_SECRET_KEY_SIZE);
            }
            var key = Encoding.ASCII.GetBytes(secretKey);

            return new SymmetricSecurityKey(key);
        }

        private void ConfigureServicesDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly("ToDo.API"))
            );
        }

        private void ConfigureServicesAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = GetSymmetricKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private static void ConfigureServicesSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "To-Do",
                    Version = "v1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor insira o token JWT neste formato: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void ConfigureServicesDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUserRepositorie, UserRepositorie>();
        }
    }
}
