#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    /// <summary>
    /// Данные прикрепляемого внешнего вложения
    /// </summary>
    public class ShareAttachmentPayload
    {
        /// <summary>
        /// Данные прикрепляемого внешнего вложения
        /// </summary>
        /// <param name="token">Уникальный ID вложения</param>
        /// <param name="url">URL, прикрепленный к сообщению в качестве предпросмотра медиа</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="token"/> обязателен</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="url"/> должен соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></exception>
        public ShareAttachmentPayload(string token, string url = null)
        {
            if (token.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (!url.IsNullOrEmptyOrWhiteSpace() && !Regex.IsMatch(url, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(url)));
            }

            Token = token;
            Url = url;
        }

        /// <summary>
        /// URL, прикрепленный к сообщению в качестве предпросмотра медиа
        /// </summary>
        /// <list type="bullet">
        /// <item>Минимальная длина: 1</item>
        /// <item>Должно соответствовать регулярному выражению: <see cref="RegexExtensions.UrlPattern"/></item>
        /// </list>
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringRangeLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Url { get; }

        /// <summary>
        /// Уникальный ID вложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string Token { get; }
    }
}