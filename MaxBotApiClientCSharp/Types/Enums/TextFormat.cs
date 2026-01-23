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
    public enum TextFormat: byte
    {
        /// <summary>
        /// Markdown
        /// </summary>
        Markdown,

        /// <summary>
        /// Html
        /// </summary>
        Html
    }
}
