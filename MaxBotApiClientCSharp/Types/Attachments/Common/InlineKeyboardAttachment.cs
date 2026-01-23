#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Кнопки в сообщении
    /// </summary>
    public class InlineKeyboardAttachment: Attachment
    {
        public InlineKeyboardAttachment(): base(AttachmentType.InlineKeyboard) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public InlineKeyboardAttachmentPayload Payload { get; set; }
    }
}