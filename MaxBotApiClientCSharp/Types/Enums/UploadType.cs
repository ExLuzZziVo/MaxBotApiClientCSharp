#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип загружаемого файла
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum UploadType: byte
    {
        /// <summary>
        /// Изображение
        /// </summary>
        Image,

        /// <summary>
        /// Видео
        /// </summary>
        Video,

        /// <summary>
        /// Аудио
        /// </summary>
        Audio,

        /// <summary>
        /// Файл
        /// </summary>
        File
    }
}