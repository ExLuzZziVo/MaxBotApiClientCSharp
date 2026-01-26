#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип кнопки
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ButtonType: byte
    {
        /// <summary>
        /// Отправка полезной нагрузки на сервер
        /// </summary>
        Callback,

        /// <summary>
        /// Открытие ссылки
        /// </summary>
        Link,

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        Message,

        /// <summary>
        /// Открытие мини-приложения
        /// </summary>
        [JsonStringEnumMemberName("open_app")] OpenApp,

        /// <summary>
        /// Запрос контактных данных
        /// </summary>
        [JsonStringEnumMemberName("request_contact")]
        RequestContact,

        /// <summary>
        /// Запрос местоположения
        /// </summary>
        [JsonStringEnumMemberName("request_geo_location")]
        RequestGeoLocation
    }
}