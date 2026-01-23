#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    /// <summary>
    /// Информация об изображении
    /// </summary>
    public class ImageAttachmentPayload
    {
        /// <summary>
        /// Уникальный ID этого изображения
        /// </summary>
        [JsonPropertyName("photo_id")]
        public long PhotoId { get; set; }

        /// <summary>
        /// Используется, если повторно используется одно и то же вложение в другом сообщении
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// URL изображения
        /// </summary>
        public string Url { get; set; }
    }
}
