#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Статус чата
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ChatStatus: byte
    {
        /// <summary>
        /// Бот является активным участником чата
        /// </summary>
        Active,

        /// <summary>
        /// Бот был удалён из чата
        /// </summary>
        Removed,

        /// <summary>
        /// Бот покинул чат
        /// </summary>
        Left,

        /// <summary>
        /// Чат был закрыт
        /// </summary>
        Closed,

        /// <summary>
        /// Бот был остановлен пользователем
        /// </summary>
        Suspended
    }
}
