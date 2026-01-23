#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    public class StickerAttachmentPayload: AttachmentPayload
    {
        /// <summary>
        /// ID стикера
        /// </summary>
        public string Code { get; set; }
    }
}
