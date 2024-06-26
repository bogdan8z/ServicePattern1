

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServicePattern1.API.Mapper;
using ServicePattern1.DataAccess;
using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Service;
using ServicePattern1.Service.Interfaces;
using ServicePattern1.Service.Mapper;

using System.Configuration;

namespace ServicePattern1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            AddDependencies(builder.Services, builder.Configuration);

            builder.Services.AddAutoMapper(
                typeof(ApiMappingProfile), 
                typeof(ServiceMappingProfile),
                typeof(DataAccess.Mapper.DataAccessMappingProfile)
                );

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
        }

        private static void AddDependencies(IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            bool useInMemoryRepository = configuration.GetValue<bool>("UseInMemoryRepository");

            if (useInMemoryRepository)
            {
                services.AddScoped<IOrderRepository, InMemoryData.OrderRepository>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();               
                services.AddScoped<IOrderService, OrderService>();
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );
                services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<IOrderService, OrderService>();
                services.AddScoped<IOrderRepository, OrderRepository>();
            }
        }
    }
}