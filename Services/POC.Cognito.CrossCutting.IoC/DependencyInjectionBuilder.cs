using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using POC.Cognito.Application.Users.Interfaces;
using POC.Cognito.Application.Users.Services;
using POC.Cognito.Core.Models;
using POC.Cognito.Domain.Users.Interfaces.InfraData;
using POC.Cognito.Domain.Users.Interfaces.InfraService;
using POC.Cognito.Infra;
using POC.Cognito.Infra.Users.Repositories;
using POC.Cognito.Services.Users;

namespace POC.Cognito.CrossCutting.IoC
{
    public static class DependencyInjectionBuilder
    {
        public static void InjectApplicationServiceDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
        }
        public static void InjectInfraDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDataContext>(options =>
            {
                options.UseInMemoryDatabase(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

        }
        public static void InjectServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var awsCognitoSection = services.BuildServiceProvider().GetRequiredService<IOptions<AWSManager>>().Value;

            var cognitoIdentityProvider = new AmazonCognitoIdentityProviderClient(awsCognitoSection.AcessKey, awsCognitoSection.SecretKey, RegionEndpoint.SAEast1);
            services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoIdentityProvider);

            var cognitoUserPool = new CognitoUserPool(awsCognitoSection.CognitoPoolId, awsCognitoSection.CognitoId, cognitoIdentityProvider);
            services.AddSingleton(cognitoUserPool);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("RedisSettings")["ConnectionString"];
                options.InstanceName = "POC.Cognito-Cache";
            });

            services.AddScoped<IUserAuthService, UserAuthService>();

        }
    }
}
