#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для открытия мини-приложение
    /// </summary>
    public class OpenAppButton: Button
    {
        /// <summary>
        /// Кнопка для открытия мини-приложение
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        /// <param name="webApp">Публичное имя (username) бота или ссылка на него, чьё мини-приложение надо запустить</param>
        /// <param name="payload">Параметр запуска, который будет передан в initData мини-приложения</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="webApp"/> обязателен</exception>
        public OpenAppButton(string text, string webApp, string payload = null): base(ButtonType.OpenApp, text)
        {
            if (webApp.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(webApp));
            }

            WebApp = webApp;
            Payload = payload;
        }

        /// <summary>
        /// Кнопка для открытия мини-приложение
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        /// <param name="contactId">ID бота, чьё мини-приложение надо запустить</param>
        /// <param name="payload">Параметр запуска, который будет передан в initData мини-приложения</param>
        public OpenAppButton(string text, long contactId, string payload = null): base(ButtonType.OpenApp, text)
        {
            ContactId = contactId;
            Payload = payload;
        }

        [JsonConstructor]
        private OpenAppButton(string text, string webApp, long contactId, string payload = null): base(
            ButtonType.OpenApp, text)
        {
            WebApp = webApp;
            ContactId = contactId;
            Payload = payload;
        }

        /// <summary>
        /// Публичное имя (username) бота или ссылка на него, чьё мини-приложение надо запустить
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="ContactId"/> имеет значение null</item>
        /// </list>
        [JsonPropertyName("web_app")]
        [RequiredIf(nameof(ContactId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        public string WebApp { get; }

        /// <summary>
        /// ID бота, чьё мини-приложение надо запустить
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="WebApp"/> имеет значение null</item>
        /// </list>
        [JsonPropertyName("contact_id")]
        [RequiredIf(nameof(WebApp), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        public long? ContactId { get; }

        /// <summary>
        /// Параметр запуска, который будет передан в initData мини-приложения
        /// </summary>
        public string Payload { get; }
    }
}