using AlunosApi.Context;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi
{
    public class Startup
    {
        public Startup(IConfigurationRoot configurationRoot) 
        {
            configurationRoot = configurationRoot;
        }

        public IConfigurationRoot ConfigurationRoot { get; }
      public void ConfigureServices(IServiceCollection servicesColletions)
        {
            //Data base connection
            servicesColletions.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ConfigurationRoot.GetConnectionString("DefaultConnection")));

            servicesColletions.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            servicesColletions.AddEndpointsApiExplorer();
            servicesColletions.AddSwaggerGen();
        }

      public void Configrue(WebApplication app, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
