using System;
using System.Collections.Generic;
using System.Text;

namespace NuMusic.Configurations
{
    internal static class AppCenterConfigurations
    {
        private static string iOSAppSecrect_DEVELOPMENT = "ios=916ea169-6f53-40a0-8c2d-004b2825cfa1;";
        private static string AndroidAppSecrect_DEVELOPMENT = "android=1b1ec3e3-70e5-48cd-afb0-743235999dbb;";

        private static string iOSAppSecrect_PRODUCTION = "ios=916ea169-6f53-40a0-8c2d-004b2825cfa1;";
        private static string AndroidAppSecrect_PRODUCTION = "android=1b1ec3e3-70e5-48cd-afb0-743235999dbb;";


        internal static string iOSAppSecrect => AppSettings.AppEnvironment == AppSettings.Environment.Development
            ? iOSAppSecrect_DEVELOPMENT
            : iOSAppSecrect_PRODUCTION;

        internal static string AndroidAppSecrect => AppSettings.AppEnvironment == AppSettings.Environment.Development
            ? AndroidAppSecrect_DEVELOPMENT
            : AndroidAppSecrect_PRODUCTION;
    }
}
