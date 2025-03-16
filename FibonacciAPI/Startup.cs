using Microsoft.OpenApi.Models;

namespace FibonacciAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
        });
        services.AddControllers();
        services.AddScoped<IFibonacciService, FibonacciService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Fibonacci API",
                Version = "v1",
                Description = "Backend API for the Fibonacci application",
                Contact = new OpenApiContact
                {
                    Name = "Tom Cross",
                    Email = "thomasgcross@outlook.com",
                },
            });
        });

        // This is where we'd add a DB Context, Automapper and anything else in the DI container
        // We'd probably want to add JWT bearer tokens here too to secure the API
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors("AllowReactApp");
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fibonacci API V1");
            c.RoutePrefix = string.Empty;
        });
    }
}
