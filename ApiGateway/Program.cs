var builder = WebApplication.CreateBuilder(args);

 void ConfigureServices(IServiceCollection services)
{
    // Add any necessary services for the ApiGateway
}

 void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
{
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        // Configure routing for microservices
        endpoints.MapControllerRoute(
            name: "todo",
            pattern: "todo/{controller=Todo}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
            name: "auth",
            pattern: "auth/{controller=Auth}/{action=Index}/{id?}");
    });
}
// Add services to the container.

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
