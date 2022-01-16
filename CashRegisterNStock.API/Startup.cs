using CashRegisterNStock.API.Services;
using CashRegisterNStock.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToolBox.Security.Hash;
using System.Security.Cryptography;
using ToolBox.Security.Configurations;
using System.IdentityModel.Tokens.Jwt;
using ToolBox.Security.Services;
using ToolBox.Security.Middlewares;

namespace CashRegisterNStock.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    var enumConverter = new JsonStringEnumConverter();
                    opts.JsonSerializerOptions.Converters.Add(enumConverter);
                });

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CashRegisterNStock.API", Version = "v1" });
                OpenApiSecurityScheme securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });

            services.AddCors(options => options.AddPolicy("default", builder =>
            {
                //builder.WithOrigins("http://localhost:8100");
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            services.AddDbContext<CrnsDbContext>();

            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();

            services.AddScoped<OrderService>();
            services.AddScoped<OrderLineService>();
            services.AddScoped<AuthService>();

            services.AddSingleton(sb => Configuration.GetSection("JWT").Get<JwtConfig>());
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddScoped<JwtService>();

            services.AddScoped<HashService>();
            services.AddScoped<HashAlgorithm, SHA512CryptoServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CashRegisterNStock.API v1"));
            }

            app.UseCors("default");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
