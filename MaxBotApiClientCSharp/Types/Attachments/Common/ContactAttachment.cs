#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    public class ContactAttachment: Attachment
    {
        public ContactAttachment(): base(AttachmentType.Contact) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public ContactAttachmentPayload Payload { get; set; }
    }
}