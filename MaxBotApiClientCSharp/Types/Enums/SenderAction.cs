#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Действия, отправляемые участникам чата
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum SenderAction
    {
        /// <summary>
        /// Бот набирает сообщение
        /// </summary>
        [JsonStringEnumMemberName("typing_on")]
        TypingOn,

        /// <summary>
        /// Бот отправляет фото
        /// </summary>
        [JsonStringEnumMemberName("sending_photo")]
        SendingPhoto,

        /// <summary>
        /// Бот отправляет видео
        /// </summary>
        [JsonStringEnumMemberName("sending_video")]
        SendingVideo,

        /// <summary>
        /// Бот отправляет аудиофайл
        /// </summary>
        [JsonStringEnumMemberName("sending_audio")]
        SendingAudio,

        /// <summary>
        /// Бот отправляет файл
        /// </summary>
        [JsonStringEnumMemberName("sending_file")]
        SendingFile,

        /// <summary>
        /// Бот помечает сообщения как прочитанные
        /// </summary>
        [JsonStringEnumMemberName("mark_seen")]
        MarkSeen
    }
}