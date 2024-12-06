using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.Repositories;

namespace ToDo.API
{

    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly("ToDo.API")));

            services.AddControllers();
        }
    }
}
