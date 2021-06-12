using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheShow.Domain.Services;
using TheShow.Domain.User;
using TheShow.Infrastructure.Repositories;

namespace TheShow.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ReservationsRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<MovieService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<DbSeed>().AsImplementedInterfaces();
        }
    }

    public static class Extensions
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<TheShowDbContext>(builder =>
            {
                builder.UseInMemoryDatabase("TheShow-test");
            });

            services.AddIdentity<User, IdentityRole<Guid>>(x =>
                {
                    x.Password = new PasswordOptions
                    {
                        RequireDigit = true,
                        RequireLowercase = false,
                        RequireNonAlphanumeric = false,
                        RequireUppercase = false,
                        RequiredLength = 6
                    };
                })
                .AddEntityFrameworkStores<TheShowDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
