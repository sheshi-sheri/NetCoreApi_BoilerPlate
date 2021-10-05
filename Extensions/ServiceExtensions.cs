using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using LoggerService;
using Contracts;

namespace NetCoreApi_BoilerPlate
{

    public static class ServiceExtensions{


        public static string CorsAnyPolicy = "CorsAnyPolicy";
        public static string CorsWithPolicy = "CorsWithPolicy";

        /// <summary>
        /// This method is to configure CORS with any domain any method and any header
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAnyCors(this IServiceCollection services ) => 
            services.AddCors(options => {
                options.AddPolicy(CorsAnyPolicy, builder => 
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
    

    /// <summary>
    /// This method is to finest CORS configuration 
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureWithCors(this IServiceCollection services ) => 
            services.AddCors(options => {
                options.AddPolicy(CorsWithPolicy, builder => 
                builder.WithOrigins("http://wwww.google.com")
                .WithMethods("POST")
                .WithExposedHeaders("x-custom-header")
                .WithHeaders("x-custom-header"));
            });


        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>{
                
            });


        public static void ConfigureLoggerService(this IServiceCollection services) =>
                services.AddScoped<ILoggerManager,LoggerManager>();
        
    }
}