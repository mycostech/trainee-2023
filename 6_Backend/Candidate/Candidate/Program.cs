
using Candidate.Data;
using Candidate.Services;
using Microsoft.EntityFrameworkCore;

namespace Candidate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(
                        origin => true
                        );

                });
        }
        );

        //builder.Services.AddCors(option =>
        //{
        //    option.AddPolicy("Policy1", builder =>
        //    {
        //        builder.WithOrigins("http://localhost:3000")
        //        .WithMethods("POST", "GET", "PUT", "DELETE")
        //        .WithHeaders(headers.ContentType);
        //    });
        //});

        builder.Services.AddDbContext<TodoItemsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("candidateContext")));
        #region Services
        builder.Services.AddScoped<ICandidateService, CandidateService>();
        #endregion
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

