#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип чата
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ChatType: byte
    {
        /// <summary>
        /// Личные сообщения
        /// </summary>
        Dialog,

        /// <summary>
        /// Групповой чат
        /// </summary>
        Chat,

        /// <summary>
        /// Канал
        /// </summary>
        Channel
    }
}