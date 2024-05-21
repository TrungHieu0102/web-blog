using Microsoft.EntityFrameworkCore;
using web_blog.Data;

namespace web_blog.Api
{
    public static class MigrationManager
    {
        //extention method
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<WebBlogContext>())
                {
                    context.Database.Migrate();
                    new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }
}
