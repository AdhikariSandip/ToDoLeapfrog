namespace ApiGateway
{
    // Startup.cs
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add any necessary services for the ApiGateway
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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
    }

}
