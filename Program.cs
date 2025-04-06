
using HistoryV1Extension.Controllers;
using HistoryV1Extension.Models;
using HistoryV1Extension.Models.Formatters;

namespace HistoryV1Extension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
            ApiSettings config = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.InputFormatters.Add(new TextPlainJsonInputFormatter());
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalExplorers", policy =>
                {
                    policy.WithOrigins(config.AllowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            builder.Services.AddHttpClient<HistoryController>(nameof(HistoryController), options =>
            {
                options.DefaultRequestHeaders.UserAgent.ParseAdd(config.HistoryUserAgentName);
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseCors("AllowLocalExplorers");
            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();


            app.MapControllers();

            try
            {
                config.EnsureSuccessValidation();
                app.Run(config.BaseUrl);
            }
            catch (Exception ex)
            {
                app.Logger.LogCritical("{exception}", ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
