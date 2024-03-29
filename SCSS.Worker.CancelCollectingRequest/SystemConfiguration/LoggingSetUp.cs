﻿using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.AWS.Logger;
using NLog.Config;
using NLog.Targets;
using SCSS.AWSService.Implementations;
using SCSS.AWSService.Interfaces;
using SCSS.Utilities.Configurations;
using SCSS.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSS.Worker.CancelCollectingRequest.SystemConfiguration
{
    internal static class LoggingSetUp
    {
        public static void AddLoggingSetUp(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentException(nameof(services));
            }

            // Load nlog.config file
            var logConfigFile = AppFileHelper.GetFileConfig(AppSettingValues.LoggingConfig);
            if (ConfigurationHelper.IsProduction || ConfigurationHelper.IsTesting)
            {
                logConfigFile = Environment.GetEnvironmentVariable("SCSS.Worker.CancelCollectingRequest") + "\\" + AppSettingValues.LoggingConfig;
            }
            var config = new LoggingConfiguration(LogManager.LoadConfiguration(logConfigFile));
            // Set up to write log to AWS WatchCloud
            if (ConfigurationHelper.IsProduction || ConfigurationHelper.IsTesting)
            {
                // Config NLog in order to connect to AWS WatchCloud
                var awsTarget = new AWSTarget()
                {
                    LogGroup = AppSettingValues.AWSCloudWatchLogGroup,
                    LogStreamNamePrefix = "SCSS",
                    Region = AppSettingValues.AWSRegion,
                    Credentials = new Amazon.Runtime.BasicAWSCredentials(AppSettingValues.AWSAccessKey, AppSettingValues.AWSSecrectKey)
                };
                config.AddTarget("aws", awsTarget);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, awsTarget));
            }

            if (ConfigurationHelper.IsDevelopment)
            {
                var logTarget = new ConsoleTarget();
                config.AddTarget("console", logTarget);
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logTarget);
            }

            LogManager.Configuration = config;

            // Logging
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
