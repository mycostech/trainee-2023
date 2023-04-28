
using Microsoft.EntityFrameworkCore;
using serverCandidate.Data;
using serverCandidate.Services;
using serverCandidate.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace serverCandidate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        #region jwt
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
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

        builder.Services.AddSwaggerGen(option =>
        {
            // Set the comments path for the Swagger JSON and UI.
            //List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.AllDirectories).ToList();
            //xmlFiles.ForEach(xmlFile => option.IncludeXmlComments(xmlFile));

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Access Token in format 'Bearer [token]'",
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

        #endregion

        builder.Services.AddDbContext<CandidateContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("traningContext")));
        #region databaseService
        builder.Services.AddScoped<ICandidateService, CandidateService>();
        builder.Services.AddScoped<IRecruiterService, RecruiterService>();

        //builder.Services.AddScoped<IUserService, UserService>();
        #endregion
        builder.Services.AddControllers();

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

