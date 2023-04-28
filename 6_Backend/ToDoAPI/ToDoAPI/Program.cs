
using CandidateHW.Services;
using CandidateHW.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ToDoAPI.Data;
using ToDoAPI.Services;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<CandidateModel>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("database1")));
            builder.Services.AddScoped<ICandidateServices, CandidateServices>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            //builder.Services.AddScoped<IUserServices, UserServices>();

            #region JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(60),
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAuthorization();
            #endregion

            builder.Services.AddSwaggerGen(option =>
            {
                // Set the comments path for the Swagger JSON and UI.
                //List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.AllDirectories).ToList();
                //xmlFiles.ForEach(xmlFile => option.IncludeXmlComments(xmlFile));

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Access Token in format '[token]'",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}