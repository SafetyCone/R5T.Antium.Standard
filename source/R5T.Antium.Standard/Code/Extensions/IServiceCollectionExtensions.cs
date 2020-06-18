using System;

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
        /// Adds the <see cref="IPublishAction"/> service.
        /// </summary>
        public static IServiceCollection AddPublishAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddDefaultDotnetPublishAction(
                services.AddEntryPointProjectFilePathProviderAction(addEntryPointProjectNameProvider),
                services.AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider),
                services.AddDotnetOperatorAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IPublishAction"/> service.
        /// </summary>
        public static IServiceAction<IPublishAction> AddPublishActionAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IPublishAction>(() => services.AddPublishAction(
                addEntryPointProjectNameProvider,
                addBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSource_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddPublishDeploymentSourceFileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddDefaultDeploymentSourceFileSystemSiteProvider(
                services.AddPublishProjectBuildOutputBinariesDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSource_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentSource_FileSystemSiteProvider> AddPublishDeploymentSourceFileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentSource_FileSystemSiteProvider>(() => services.AddPublishDeploymentSourceFileSystemSiteProvider(
                addEntryPointProjectNameProvider,
                addBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSource_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddDeploymentSourceFileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
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
        /// Adds the <see cref="IDeploymentSource_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentSource_FileSystemSiteProvider> AddDeploymentSourceFileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentSource_FileSystemSiteProvider>(() => services.AddDeploymentSourceFileSystemSiteProvider(
                addSolutionFileNameProvider,
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentSecretsSerializationProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddDefaultRemoteDeploymentSecretsSerializationProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddSecretsDirectoryFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceAction<IRemoteDeploymentSecretsSerializationProvider> AddRemoteDeploymentSecretsSerializationProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IRemoteDeploymentSecretsSerializationProvider>(() => services.AddRemoteDeploymentSecretsSerializationProvider(addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddSecretsFileRemoteDeploymentDestinationFileSystemSiteProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider),
                services.AddRemoteFileSystemOperatorAction(addAwsEc2ServerHostFriendlyNameProvider),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentDestination_FileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestination_FileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProviderAction(
                    addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentDestination_FileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestination_FileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }


        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddLocalDeploymentSecretsSerializationProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddDefaultLocalDeploymentSecretsSerializationProvider(
                addDeploymentDestinationSecretsFileNameProvider,
                services.AddSecretsDirectoryFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceAction<ILocalDeploymentSecretsSerializationProvider> AddLocalDeploymentSecretsSerializationProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<ILocalDeploymentSecretsSerializationProvider>(() => services.AddLocalDeploymentSecretsSerializationProvider(addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddLocalDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddSecretsFileLocalDeploymentDestinationFileSystemSiteProvider(
                services.AddLocalDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentDestination_FileSystemSiteProvider> AddLocalDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestination_FileSystemSiteProvider>(() => services.AddLocalDeploymentDestinationFileSystemSiteProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerHostFriendlyNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerHostFriendlyNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerSecretsFileNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsFileNameProvider> AddRemoteDeploymentAwsEc2ServerSecretsFileNameProviderAction(this IServiceCollection services,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsFileNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_SecretsDirectory_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestination_SecretsDirectory_FileSystemSiteProvider(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            services.AddDefaultRemoteDeploymentDestination_SecretsDirectory_FileSystemSiteProvider(
                services.AddRemoteFileSystemOperatorAction(
                    addAwsEc2ServerHostFriendlyNameProvider),
                services.AddRemoteDeploymentSecretsSerializationProviderAction(
                    addDeploymentDestinationSecretsFileNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestination_SecretsDirectory_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentDestination_SecretsDirectory_FileSystemSiteProvider> AddRemoteDeploymentDestination_SecretsDirectory_FileSystemSiteProviderAction(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider,
            IServiceAction<IDeploymentDestinationSecretsFileNameProvider> addDeploymentDestinationSecretsFileNameProvider)
        {
            var serviceAction = new ServiceAction<IDeploymentDestination_SecretsDirectory_FileSystemSiteProvider>(() => services.AddRemoteDeploymentDestination_SecretsDirectory_FileSystemSiteProvider(
                addAwsEc2ServerHostFriendlyNameProvider,
                addDeploymentDestinationSecretsFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSource_SecretsDirectory_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddDeploymentSource_SecretsDirectory_FileSystemSiteProvider(this IServiceCollection services)
        {
            services.AddDefaultDeploymentSource_SecretsDirectory_FileSystemSiteProvider(
                services.AddLocalFileSystemOperatorAction(),
                services.AddSecretsDirectoryPathProviderAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSource_SecretsDirectory_FileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceAction<IDeploymentSource_SecretsDirectory_FileSystemSiteProvider> AddDeploymentSource_SecretsDirectory_FileSystemSiteProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IDeploymentSource_SecretsDirectory_FileSystemSiteProvider>(() => services.AddDeploymentSource_SecretsDirectory_FileSystemSiteProvider());
            return serviceAction;
        }
    }
}
