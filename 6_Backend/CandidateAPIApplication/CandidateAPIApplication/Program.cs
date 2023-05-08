
using CandidateAPIApplication.Data;
using CandidateAPIApplication.Services;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CandidateAPIApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CandidatesContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("CandidateContext"))
            );

            builder.Services.AddCors(option =>
            {
                option.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(
                            origin => true
                            );

                    });
            });

            builder.Services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(optim => {
                optim.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = new TimeSpan(60),
                    ValidateLifetime = true,
                };
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(option =>
            //{
            //    option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
            //    {
            //        Description = "Access token in format 'Bearer [token]'",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Name = "Athurization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });
            //    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Id = "Bearer",
            //                    Type = ReferenceType.Schema
            //                }
            //            },
            //            new List<string>()
            //        }
            //    });;
            //});
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICandidateServices, CandidateServices>();
            builder.Services.AddScoped<IStatusCodeServices, StatusCodeServices>();
            builder.Services.AddScoped<ICommentAndScoreServices, CommentAndScoreServices>();
            builder.Services.AddScoped<IDateAppointmentServices, DateAppointmentServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}