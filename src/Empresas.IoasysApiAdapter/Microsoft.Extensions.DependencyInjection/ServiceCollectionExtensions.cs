using AutoMapper;
using Empresas.Domain.Adapters;
using Empresas.IoasysApiAdapter;
using Empresas.IoasysApiAdapter.Clients;
using Empresas.IoasysApiAdapter.Mapper;
using Refit;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIoasysApiAdapter(this IServiceCollection services, IoasysApiAdapterConfiguration  ioasysApiAdapterConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(ioasysApiAdapterConfiguration ?? throw new ArgumentNullException(nameof(ioasysApiAdapterConfiguration)));

            services.AddTransient(serviceProvider =>
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(ioasysApiAdapterConfiguration.UrlBase)
                };

                return RestService.For<IIoasysApiAdapterClient>(httpClient);
            });

            services.AddSingleton<IIoasysApiAdapter, IoasysApiAdapter>();

            Mapper.Initialize(config =>
            {
                config.AddProfile<IoasysAdapterAutoMapperProfiller>();
            });

            return services;
        }
    }
}