#region

using System;
using CoreLib.CORE.Helpers.StringHelpers;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Токен ранее загруженного изображения
    /// </summary>
    public class ImageToken
    {
        /// <summary>
        /// Токен ранее загруженного изображения
        /// </summary>
        /// <param name="token">Уникальный ID загруженного файла</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="token"/> обязателен</exception>
        public ImageToken(string token)
        {
            if (token.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(token));
            }

            Token = token;
        }

        /// <summary>
        /// Уникальный ID загруженного файла
        /// </summary>
        public string Token { get; }
    }
}