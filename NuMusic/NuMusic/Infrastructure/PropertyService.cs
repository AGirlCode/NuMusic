using NuMusic.Core;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NuMusic.Infrastructure
{
    public class PropertyService : IPropertyService
    {
        public T GetValueAsync<T>(string property)
        {
            if (!Application.Current.Properties.ContainsKey(property))
                return default;

            try
            {
                if (Application.Current.Properties[property] is T)
                    return (T)Application.Current.Properties[property];

                return (T)Convert.ChangeType(Application.Current.Properties[property], typeof(T));
            } catch (InvalidCastException)
            {
                return default;
            } catch (Exception)
            {
                return default;
            }
        }

        public void SetValue<T>(string property, T value)
        {
            if (value == null)
                Remove(property);
            else
                Application.Current.Properties[property] = value;
        }

        public bool Exists(string property)
        {
            try
            {
                return Application.Current.Properties.ContainsKey(property);
            } catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa 1 key khỏi application properties
        /// </summary>
        public bool Remove(string property)
        {
            try
            {
                var result = Application.Current.Properties.Remove(property);
                return result;
            } catch (Exception e)
            {
                return false;
            }
        }

        public async Task SavePropertiesAsync()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}