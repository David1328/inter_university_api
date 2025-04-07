using Microsoft.OpenApi.Models;

namespace inter_university_api
{
    public class Startup
    {
        public static string db_inter_university { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Agrega servicios al contenedor
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Otros servicios que necesites
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "inter-university-api", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
        }

        // Configura el middleware del pipeline HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db_inter_university = Configuration["ConnectionStrings:db_inter_university"];

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("v1/swagger.json", "inter-university-api");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AltruiaPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
