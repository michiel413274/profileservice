using Business;
using Dal.Data;
using IBusiness;
using iDal.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ProfileService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //if (_env.IsProduction())
            //{
                Console.WriteLine("Using sqlserver Db");
                services.AddDbContext<ProfileDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("ProfileConn")));
           // }
            //else
            //{
             //   Console.WriteLine("using inMem Db");
            //    services.AddDbContext<ProfileDbContext>(opt =>
           //     opt.UseInMemoryDatabase("InMemory"));
          //  }            

            services.AddControllers();

            //services.AddHostedService<MessageBusSubscriber>();

            //services.AddSingleton<IEventProcessor, EventProcessor>();
            services.AddScoped<IProfileRepo, ProfileRepo>();
            services.AddScoped<IProfileLogic, ProfileLogic>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProfileService", Version = "v1" });
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend v1"));
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //PrepDb.PrepPopulation(app, env.IsProduction());
        }
    }
}
