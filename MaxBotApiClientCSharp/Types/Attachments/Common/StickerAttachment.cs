#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Стикер
    /// </summary>
    public class StickerAttachment: Attachment
    {
        public StickerAttachment(): base(AttachmentType.Sticker) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public StickerAttachmentPayload Payload { get; set; }

        /// <summary>
        /// Ширина стикера
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота стикера
        /// </summary>
        public int Height { get; set; }
    }
}