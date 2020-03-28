using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuMusic.Core
{
    public interface IPropertyService
    { /// <summary>
      /// Lấy dữ liệu từ Application Properties, trả về kiểu dữ liệu T
      /// </summary>
      /// <returns></returns>
        T GetValueAsync<T>(string property);

        /// <summary>
        /// Lưu dữ liệu vào Application Properties
        /// </summary>
        void SetValue<T>(string property, T value);

        /// <summary>
        /// Kiểm tra có tồn tại key trong Application Properties
        /// </summary>
        bool Exists(string property);

        /// <summary>
        /// Xóa 1 key trong Application Properties
        /// </summary>
        bool Remove(string property);

        Task SavePropertiesAsync();
    }
}
