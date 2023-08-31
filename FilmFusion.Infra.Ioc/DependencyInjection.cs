using FilmFusion.Application.Interfaces;
using FilmFusion.Application.Services;
using FilmFusion.Business;
using FilmFusion.Domain.Repositories;
using FilmFusion.Domain.UseCases;
using FilmFusion.Infra.Data.SqlServer.Context;
using FilmFusion.Infra.Data.SqlServer.Repositories;
using FilmFusion.Infra.External.Interfaces;
using FilmFusion.Infra.External.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmFusion.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationSqlServerDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());            

            services.AddScoped<IDirectoryService, DirectoryService>();

            services.AddScoped<IReadMovieInfosByPathUseCase, ReadMovieInfosByPathUseCase>();
            services.AddScoped<IGetMovieInfoByDirectoryUseCase, GetMovieInfoByDirectoryUseCase>();

            services.AddScoped<IImdbApiService, ImdbApiService>();
            services.AddScoped<IOmdbApiService, OmdbApiService>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
