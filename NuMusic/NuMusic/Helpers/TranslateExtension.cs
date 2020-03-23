using NuMusic.Resources;
using Plugin.Multilingual;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Helpers
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private static readonly string ResourceId = typeof(AppResources).FullName;

        static readonly Lazy<ResourceManager> resmgr =
            new Lazy<ResourceManager>(() =>
                new ResourceManager(ResourceId, typeof(TranslateExtension)
                    .GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;
            var translation = resmgr.Value.GetString(Text.ToUpper(), ci);

            if (translation == null)
            {
#if DEBUG
                Debug.WriteLine($"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.",
                    "Text");

                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
