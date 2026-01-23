#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Видео
    /// </summary>
    public class VideoAttachment: Attachment
    {
        public VideoAttachment(): base(AttachmentType.Video) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public MediaAttachmentPayload Payload { get; set; }

        /// <summary>
        /// Миниатюра видео
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Ширина видео
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота видео
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Длина видео в секундах
        /// </summary>
        public int? Duration { get; set; }
    }
}