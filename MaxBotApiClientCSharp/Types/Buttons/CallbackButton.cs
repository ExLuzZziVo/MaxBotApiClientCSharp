#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для отправки полезной нагрузки на сервер
    /// </summary>
    public class CallbackButton: Button
    {
        /// <summary>
        /// Кнопка для отправки полезной нагрузки на сервер
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        /// <param name="payload">Полезная нагрузка</param>
        /// <param name="intent">Намерение кнопки. Влияет на отображение клиентом. По умолчанию: <see cref="ButtonIntent.Default"/></param>
        /// <exception cref="ArgumentException">Параметр <paramref name="payload"/> обязателен и должен иметь длину не более 1024</exception>
        public CallbackButton(string text, string payload, ButtonIntent intent = ButtonIntent.Default): base(
            ButtonType.Callback, text)
        {
            if (payload.IsNullOrEmptyOrWhiteSpace() || payload.Length > 1024)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(payload)));
            }

            Payload = payload;
            Intent = intent;
        }

        /// <summary>
        /// Полезная нагрузка
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 1024</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [StringLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Payload { get; }

        /// <summary>
        /// Намерение кнопки. Влияет на отображение клиентом
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: <see cref="ButtonIntent.Default"/>
        /// </remarks>
        public ButtonIntent Intent { get; }
    }
}