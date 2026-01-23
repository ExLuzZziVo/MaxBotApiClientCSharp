#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип вложения
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum AttachmentType: byte
    {
        /// <summary>
        /// Аудио
        /// </summary>
        Audio,

        /// <summary>
        /// Контакт
        /// </summary>
        Contact,

        /// <summary>
        /// Файл
        /// </summary>
        File,

        /// <summary>
        /// Кнопки в сообщении
        /// </summary>
        [JsonStringEnumMemberName("inline_keyboard")]
        InlineKeyboard,

        /// <summary>
        /// Местоположение
        /// </summary>
        Location,

        /// <summary>
        /// Изображение
        /// </summary>
        Image,

        /// <summary>
        /// Публикация
        /// </summary>
        Share,

        /// <summary>
        /// Стикер
        /// </summary>
        Sticker,

        /// <summary>
        /// Видео
        /// </summary>
        Video
    }
}
