#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    /// <summary>
    /// Данные прикрепляемого изображения
    /// </summary>
    /// <remarks>
    /// Все поля являются взаимоисключающими
    /// </remarks>
    public class ImageAttachmentRequestPayload
    {
        private ImageAttachmentRequestPayload() { }

        /// <summary>
        /// Внешний URL изображения
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению: <see cref="RegexExtensions.UrlPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Url { get; private set; }

        /// <summary>
        /// ID загруженного файла
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Токены, полученные после загрузки изображений
        /// </summary>
        public IDictionary<string, ImageToken> Photos { get; private set; }

        /// <summary>
        /// Создает объект данных прикрепляемого изображения по ссылке
        /// </summary>
        /// <param name="url">Внешний URL изображения</param>
        /// <returns>Данные прикрепляемого изображения по ссылке</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="url"/> обязателен и должен быть URL-адресом</exception>
        public static ImageAttachmentRequestPayload AttachByUrl(string url)
        {
            if (url.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(url, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(url)),
                    nameof(url));
            }

            return new ImageAttachmentRequestPayload
            {
                Url = url
            };
        }

        /// <summary>
        /// Создает объект данных прикрепляемого изображения по ID загруженного файла
        /// </summary>
        /// <param name="token">ID загруженного файла</param>
        /// <returns>Данные прикрепляемого изображения по ID загруженного файла</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="token"/> обязателен</exception>
        public static ImageAttachmentRequestPayload AttachByToken(string token)
        {
            if (token.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(token));
            }

            return new ImageAttachmentRequestPayload
            {
                Token = token
            };
        }

        /// <summary>
        /// Создает объект данных прикрепляемого изображения по токенам, полученным после загрузки изображений
        /// </summary>
        /// <param name="photos">Токены, полученные после загрузки изображений</param>
        /// <returns>Данные прикрепляемого изображения по токенам, полученным после загрузки изображений</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="photos"/> обязателен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Коллекция <paramref name="photos"/> должна содержать хотя бы один элемент</exception>
        public static ImageAttachmentRequestPayload AttachByTokens(IDictionary<string, ImageToken> photos)
        {
            if (photos == null)
            {
                throw new ArgumentNullException(nameof(photos));
            }

            if (photos.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(photos));
            }

            return new ImageAttachmentRequestPayload
            {
                Photos = photos
            };
        }
    }
}
