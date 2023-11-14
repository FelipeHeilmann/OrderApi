using Application.gateway;
using Application.repository;
using Application.usecase.product;
using Azure.Storage.Blobs;
using Infra.context;
using Infra.gateway;
using Infra.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration){
            var connectionString = configuration.GetConnectionString("Default");
            
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped(x =>
            {
                return new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage"));
            });

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<ProductRepository, ProductRepositoryDatabase>();
            services.AddScoped<SaveImage, AzureSaveImage>();
            
            services.AddScoped<GetAllProducts>();
            services.AddScoped<GetProductById>();
            services.AddScoped<CreateProduct>();
            services.AddScoped<UpdateProduct>();
            services.AddScoped<DeleteProduct>();
            services.AddScoped<UploadImage>();

            return services;
        }
    }
}
