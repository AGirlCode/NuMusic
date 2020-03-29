using NuMusic.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuMusic.Configurations
{
    public class AppSettings
    { // Môi trường khi release app
        // DEV - Development;
        // PRO - Production
        internal const Environment AppEnvironment = Environment.Development;

        internal enum Environment
        {
            Development,
            Production
        }
        /// <summary>
        /// Phiên bản ứng dụng
        /// </summary>
        public static string AppVersion => "1.0.0";

        internal const string SyncFusionLicenseKey =
            "MTg5MjczQDMxMzcyZTM0MmUzMFl6eWl1OVdjdmt6QkgxRUdzVmtBZVZhZmdyN0lHL1BBRkgxT2ExbWJwbXM9";


        internal static readonly LanguageCulture LanguageVI = new LanguageCulture() { Id = 1, CultureName = "vi-VN" };
        internal static readonly LanguageCulture LanguageEN = new LanguageCulture() { Id = 2, CultureName = "en-US" };

        internal const string Language = "Language";

        internal static readonly List<LanguageCulture> LanguageList = new List<LanguageCulture>()
        {
            LanguageVI,
            LanguageEN
        };

    }
}
