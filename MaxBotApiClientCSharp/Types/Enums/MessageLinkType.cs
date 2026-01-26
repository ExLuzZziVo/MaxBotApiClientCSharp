#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип связанного сообщения
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MessageLinkType: byte
    {
        /// <summary>
        /// Перенаправленное
        /// </summary>
        Forward,

        /// <summary>
        /// Ответ
        /// </summary>
        Reply
    }
}