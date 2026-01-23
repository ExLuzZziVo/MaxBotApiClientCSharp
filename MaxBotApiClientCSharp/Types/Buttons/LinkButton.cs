#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для перехода по ссылке
    /// </summary>
    public class LinkButton: Button
    {
        /// <summary>
        /// Кнопка для перехода по ссылке
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        /// <param name="url">URL ссылка</param>
        /// <exception cref="ArgumentException">Параметр <paramref name="url"/> обязателен, должен иметь длину не более 1024 и соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></exception>
        public LinkButton(string text, string url): base(ButtonType.Link, text)
        {
            if (url.IsNullOrEmptyOrWhiteSpace() || url.Length > 1024 || !Regex.IsMatch(url, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(url)),
                    nameof(url));
            }

            Url = url;
        }

        /// <summary>
        /// URL ссылка
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 1024</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Url { get; }
    }
}