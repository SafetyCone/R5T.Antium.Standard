using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia.Suebia;
using R5T.Gepidia.Local.Standard;
using R5T.Gepidia.Remote.Standard;
using R5T.Jutland.Standard;
using R5T.Lombardy.Standard;
using R5T.Norsica.Standard;
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
        public static IServiceCollection AddPublicationOperator(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services.AddDefaultDotnetPublicationOperator(
                services.AddEntryPointProjectFilePathProviderAction(entryPointProjectName),
                services.AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(entryPointProjectName, buildConfigurationName),
                services.AddDotnetOperatorAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IPublicationOperator"/> service.
        /// </summary>
        public static ServiceAction<IPublicationOperator> AddPublicationOperatorAction(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            var serviceAction = new ServiceAction<IPublicationOperator>(() => services.AddPublicationOperator(entryPointProjectName, buildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddDeploymentSourceFileSystemSiteProvider(this IServiceCollection services, string solutionFileName, string entryPointProjectName)
        {
            services.AddDefaultDeploymentSourceFileSystemSiteProvider(
                services.AddProjectBuildOutputBinariesDirectoryPathProviderAction(solutionFileName, entryPointProjectName),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentSourceFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentSourceFileSystemSiteProvider> AddDeploymentSourceFileSystemSiteProviderAction(this IServiceCollection services, string solutionFileName, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IDeploymentSourceFileSystemSiteProvider>(() => services.AddDeploymentSourceFileSystemSiteProvider(solutionFileName, entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationSecretsFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddDeploymentDestinationSecretsFileNameProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddDirectDeploymentDestinationSecretsFileNameProvider(deploymentDestinationSecretsFileName);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationSecretsFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationSecretsFileNameProvider> AddDeploymentDestinationSecretsFileNameProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationSecretsFileNameProvider>(() => services.AddDeploymentDestinationSecretsFileNameProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentSecretsSerializationProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddDefaultRemoteDeploymentSecretsSerializationProvider(
                services.AddDeploymentDestinationSecretsFileNameProviderAction(deploymentDestinationSecretsFileName),
                services.AddSecretsFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IRemoteDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static ServiceAction<IRemoteDeploymentSecretsSerializationProvider> AddRemoteDeploymentSecretsSerializationProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<IRemoteDeploymentSecretsSerializationProvider>(() => services.AddRemoteDeploymentSecretsSerializationProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName, string hostFriendlyName)
        {
            services.AddSecretsFileRemoteDeploymentDestinationFileSystemSiteProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(deploymentDestinationSecretsFileName),
                services.AddRemoteFileSystemOperatorAction(hostFriendlyName),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationFileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationFileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(deploymentDestinationSecretsFileName, hostFriendlyName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static IServiceCollection AddLocalDeploymentSecretsSerializationProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddDefaultLocalDeploymentSecretsSerializationProvider(
                services.AddDeploymentDestinationSecretsFileNameProviderAction(deploymentDestinationSecretsFileName),
                services.AddSecretsFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ILocalDeploymentSecretsSerializationProvider"/> service.
        /// </summary>
        public static ServiceAction<ILocalDeploymentSecretsSerializationProvider> AddLocalDeploymentSecretsSerializationProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<ILocalDeploymentSecretsSerializationProvider>(() => services.AddLocalDeploymentSecretsSerializationProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentDestinationFileSystemSiteProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddSecretsFileLocalDeploymentDestinationFileSystemSiteProvider(
                services.AddLocalDeploymentSecretsSerializationProviderAction(deploymentDestinationSecretsFileName),
                services.AddLocalFileSystemOperatorAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IDeploymentDestinationFileSystemSiteProvider"/> service.
        /// </summary>
        public static ServiceAction<IDeploymentDestinationFileSystemSiteProvider> AddRemoteDeploymentDestinationFileSystemSiteProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<IDeploymentDestinationFileSystemSiteProvider>(() => services.AddRemoteDeploymentDestinationFileSystemSiteProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerHostFriendlyNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(deploymentDestinationSecretsFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerHostFriendlyNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerHostFriendlyNameProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            services.AddRemoteDeploymentSerializationAwsEc2ServerSecretsFileNameProvider(
                services.AddRemoteDeploymentSecretsSerializationProviderAction(deploymentDestinationSecretsFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerSecretsFileNameProvider> AddRemoteDeploymentAwsEc2ServerSecretsFileNameProviderAction(this IServiceCollection services, string deploymentDestinationSecretsFileName)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsFileNameProvider>(() => services.AddRemoteDeploymentAwsEc2ServerSecretsFileNameProvider(deploymentDestinationSecretsFileName));
            return serviceAction;
        }
    }
}
