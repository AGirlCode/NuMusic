using System;
using System.Collections.Generic;
using System.Text;

namespace NuMusic.Configurations
{
    internal static class AppCenterConfigurations
    {
        private static string iOSAppSecrect_DEVELOPMENT = "ios";
        private static string AndroidAppSecrect_DEVELOPMENT = "android;";

        private static string iOSAppSecrect_PRODUCTION = "ios";
        private static string AndroidAppSecrect_PRODUCTION = "android=";


        internal static string iOSAppSecrect => AppSettings.AppEnvironment == AppSettings.Environment.Development
            ? iOSAppSecrect_DEVELOPMENT
            : iOSAppSecrect_PRODUCTION;

        internal static string AndroidAppSecrect => AppSettings.AppEnvironment == AppSettings.Environment.Development
            ? AndroidAppSecrect_DEVELOPMENT
            : AndroidAppSecrect_PRODUCTION;
    }
}
