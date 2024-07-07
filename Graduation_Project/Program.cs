
using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Graduation_Project.Services;
using Graduation_Project.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Graduation_Project.Helpers;

namespace Graduation_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors();
            // Add services to the container.
            //builder.Services.AddDbContext<Context>(options =>
            //{
            //    // options.UseSqlServer("Data Source=DESKTOP-9E8RQR1;Initial Catalog=GraduationProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            //    // options.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_aaa39b_amanydb22;User Id=db_aaa39b_amanydb22_admin;Password=AmanyDB22");                                      
            //    // options.UseSqlServer("Server=db5930.public.databaseasp.net; Database=db5930; User Id=db5930; Password=e?8W@Zj5L3!i; Encrypt=False; MultipleActiveResultSets=True;");                                      
            //    options.UseSqlServer("workstation id=AmanySala7lyDB.mssql.somee.com;packet size=4096;user id=amanyfarouk22_SQLLogin_1;pwd=ietyt4zu2m;data source=AmanySala7lyDB.mssql.somee.com;persist security info=False;initial catalog=AmanySala7lyDB;TrustServerCertificate=True");                                      
            //});
            var connectionString = builder.Configuration.GetConnectionString("Context");
            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(connectionString));
            //==================================
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            //====================
            //Authorize  used jwt token on authorization
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidIssuer =builder.Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudiance"],
                    ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    (builder.Configuration["JWT:Key"])) 
            //        ClockSkew = TimeSpan.Zero
                };
            });
            //=====================
            //=====================
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ClientPolicy", policy => policy.RequireRole("Client"));
                options.AddPolicy("WorkerPolicy", policy => policy.RequireRole("Worker"));
            });
            //========================================
            // To Enable authorization using Swagger (JWT)  
            // ==========================

            //==========================
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });

                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] {}
                    }
                });
            });

            //=====================
            //add cors
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200", "http://localhost:8080")
            //                   .AllowAnyHeader()
            //                   .AllowAnyMethod();
            //        });
            //});
            builder.Services.AddCors();
         
            //=====================
            //logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            //=======================
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           // builder.Services.AddEndpointsApiExplorer();
           // builder.Services.AddSwaggerGen();
            //automapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            //Custom Serivces
            builder.Services.AddScoped<IAdminRepository,AdminRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IPaymentRepository,PaymentRepository>();
            builder.Services.AddScoped<ISparePartsRepository, SparePartsRepository>();
            builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

            var app = builder.Build();
            //==========================
            // Seed roles 
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Worker", "Admin", "Client" };
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
            //=============================
            //=============================
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}
            app.UseAuthentication();
            app.UseAuthorization();
            //to enable cors
            app.UseCors(c =>
            c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //for image
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}