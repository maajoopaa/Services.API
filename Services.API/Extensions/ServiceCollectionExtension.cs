using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Application.Interfaces;
using Services.Application.Models;
using Services.Application.Services;
using Services.Application.Validators;
using Services.Core.Interfaces;
using Services.Core.Models;
using Services.DataAccess;
using Services.DataAccess.Repositories;

namespace Services.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<ISpecializationService, SpecializationService>();
            services.AddTransient<ICategoryService,CategoryService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISpecializationsRepository, SpecializationsRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<ICategoriesRepository,CategoriesRepository>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SpecializationCreateRequest>, SpecializationCreateRequestValidator>();
            services.AddTransient<IValidator<SpecializationUpdateRequest>, SpecializationUpdateRequestValidator>();
            services.AddTransient<IValidator<ServiceCreateRequest>, ServiceCreateRequestValidator>();
            services.AddTransient<IValidator<ServiceUpdateRequest>, ServiceUpdateRequestValidator>();
            services.AddTransient<IValidator<PaginationModel>, PaginationModelValidator>();
        }

        public static void AddDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ServicesDbContext>(options => options.UseNpgsql(connectionString, b =>
                b.MigrationsAssembly("Services.DataAccess")));
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(options =>
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter JWT in the field",
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                });
        }
    }
}
