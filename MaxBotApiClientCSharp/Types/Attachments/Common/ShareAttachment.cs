#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    public class ShareAttachment: Attachment
    {
        public ShareAttachment(): base(AttachmentType.Share) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public FileAttachmentPayload Payload { get; set; }

        /// <summary>
        /// Заголовок предпросмотра ссылки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание предпросмотра ссылки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Изображение предпросмотра ссылки
        /// </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
    }
}