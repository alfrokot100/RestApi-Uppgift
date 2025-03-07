
using Microsoft.EntityFrameworkCore;
using RestApi_Uppgift.Data;
using RestApi_Uppgift.Endpoints.StudentEnpoints;
using RestApi_Uppgift.Services;

namespace RestApi_Uppgift
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<WorkDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<UserService>();

            builder.Services.AddHttpClient();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Middleware för att begränsa tillgången till apiet
            //app.Use(async (HttpContext context, RequestDelegate next) =>
            //{
            //    Console.WriteLine("Request recieved");
            //    string? configuredapiKey = builder.Configuration["ApiKey"];
            //    var apiKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

            //    if(apiKey != configuredapiKey)
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        await context.Response.WriteAsync("Du har ej tillgång!!");
            //        return;
            //    }

            //    await next(context);
            //});

            StudentEndpoints.RegisterEndpoints(app);
           
            app.Run();

        }
    }
}
