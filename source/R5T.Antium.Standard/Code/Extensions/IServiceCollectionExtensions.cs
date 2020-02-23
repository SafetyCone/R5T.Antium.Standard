﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia.Suebia;
using R5T.Gepidia.Local.Standard;
using R5T.Gepidia.Remote.Standard;
using R5T.Jutland.Standard;
using R5T.Lombardy.Standard;
using R5T.Norsica.Standard;
using R5T.Pompeii;
using R5T.Pompeii.Standard;
using R5T.Suebia.Standard;

using R5T.Antium.Default;


namespace R5T.Antium.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IPublicationOperator"/> service.
        /// </summary>
        public static IServiceCollection AddPublicationOperator(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddDefaultDotnetPublicationOperator(
                services.AddEntryPointProjectFilePathProviderAction(addEntryPointProjectNameProvider),
                services.AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider),
                services.AddDotnetOperatorAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IPublicationOperator"/> service.
        /// </summary>
        public static ServiceAction<IPublicationOperator> AddPublicationOperatorAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IPublicationOperator>(() => services.AddPublicationOperator(
                addEntryPointProjectNameProvider,
                addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddPublishDeploymentSourceFileSystemSiteProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddDefaultDeploymentSourceFileSystemSiteProvider(
                services.AddPublishProjectBuildOutputBinariesDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentSourceFileSystemSiteProvider> AddPublishDeploymentSourceFileSystemSiteProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentSourceFileSystemSiteProvider>(() => services.AddPublishDeploymentSourceFileSystemSiteProvider(
                addEntryPointProjectNameProvider,
                addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddDeploymentSourceFileSystemSiteProvider(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddDefaultDeploymentSourceFileSystemSiteProvider(
                services.AddStandardProjectBinariesOutputDirectoryPathProviderAction(
                    addSolutionFileNameProvider,
                    addEntryPointProjectNameProvider),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentSourceFileSystemSiteProvider> AddDeploymentSourceFileSystemSiteProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentSourceFileSystemSiteProvider>(() => services.AddDeploymentSourceFileSystemSiteProvider(
                addSolutionFileNameProvider,
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentSecretsSerializationProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddDefaultRemoteDeploymentSecretsSerializationProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddSecretsFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static ServiceAction<IRemoteDeploymentSecretsSerializationProvider> AddRemoteDeploymentSecretsSerializationProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IRemoteDeploymentSecretsSerializationProvider>(() => services.AddRemoteDeploymentSecretsSerializationProvider(addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddSecretsFileRemoteDeploymentDestinationFileSystemSiteProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider),
                services.AddRemoteFileSystemOperatorAction(addAwsEc2ServerHostFriendlyNameProvider),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationFileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider,
            ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationFileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProviderAction(
                    addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationFileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationFileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }


        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddLocalDeploymentSecretsSerializationProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddDefaultLocalDeploymentSecretsSerializationProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddSecretsFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static ServiceAction<ILocalDeploymentSecretsSerializationProvider> AddLocalDeploymentSecretsSerializationProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<ILocalDeploymentSecretsSerializationProvider>(() => services.AddLocalDeploymentSecretsSerializationProvider(addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddLocalDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddSecretsFileLocalDeploymentDestinationFileSystemSiteProvider(
                services.AddLocalDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationFileSystemSiteProvider> AddLocalDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationFileSystemSiteProvider>(() => services.AddLocalDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerHostFriendlyNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerHostFriendlyNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerSecretsFileNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerSecretsFileNameProvider> AddRemoteDeploymentAwsEc2ServerSecretsFileNameProviderAction(this IServiceCollection services,
            ServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsFileNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }
    }
}
