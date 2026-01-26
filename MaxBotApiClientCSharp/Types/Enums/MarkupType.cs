#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип форматирования
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkupType: byte
    {
        /// <summary>
        /// Курсив
        /// </summary>
        Emphasized,

        /// <summary>
        /// Ссылка
        /// </summary>
        Link,

        /// <summary>
        /// Моноширинный
        /// </summary>
        Monospaced,

        /// <summary>
        /// Зачеркнутый
        /// </summary>
        Strikethrough,

        /// <summary>
        /// Жирный
        /// </summary>
        Strong,

        /// <summary>
        /// Подчеркнутый
        /// </summary>
        Underline,

        /// <summary>
        /// Упоминание пользователя
        /// </summary>
        [JsonStringEnumMemberName("user_mention")]
        UserMention
    }
}