#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Намерение кнопки
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ButtonIntent: byte
    {
        /// <summary>
        /// Положительное
        /// </summary>
        Positive,

        /// <summary>
        /// Отрицательное
        /// </summary>
        Negative,

        /// <summary>
        /// По умолчанию
        /// </summary>
        Default
    }
}
