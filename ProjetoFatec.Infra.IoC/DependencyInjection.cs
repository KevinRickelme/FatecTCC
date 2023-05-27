using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.Services;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Infra.Data.Context;
using ProjetoFatec.Infra.Data.Repositories;

namespace ProjetoFatec.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Database"),
                    b => b.MigrationsAssembly(typeof(ApplicationContext)
                        .Assembly.FullName)));
                

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
            services.AddScoped<IPublicacaoService, PublicacaoService>();

            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPerfilService, PerfilService>();

            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<IFeedService, FeedService>();

            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<IAmigoService, AmigoService>();

            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IComentarioService, ComentarioService>();

            return services;
        }
    }
}
