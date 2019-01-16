using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhotosDemo.Repository.Repository;
using PhotosDemo.Services;
using ProductsDemo.Data.EntityFramework;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Repository;
using ProductsDemo.Repository.Services;
using ProductsDemo.Services;

namespace ProductsDemo
{
    public static class StartupHelpers
    {
        public static void ConfigureCors(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<ProductRepository, ProductRepository>();
            serviceCollection.AddTransient<PhotoRepository, PhotoRepository>();

            serviceCollection.AddTransient<IProductRepository<Product>, ProductDbRepository>();
            serviceCollection.AddTransient<IProductService, ProductService>();

            serviceCollection.AddTransient<IPhotoRepository<Photo>, PhotoDbRepository>();
            serviceCollection.AddTransient<IPhotoService, PhotoService>();
        }


        public static void ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                             .AddJwtBearer(options =>
                {
                    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ServerSecret"]));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = serverSecret,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Issuer"]
                    };
                });
        }
    }
}
