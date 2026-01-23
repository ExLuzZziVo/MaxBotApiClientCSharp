#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Изображение
    /// </summary>
    public class ImageAttachment: Attachment
    {
        public ImageAttachment(): base(AttachmentType.Image) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public ImageAttachmentPayload Payload { get; set; }
    }
}