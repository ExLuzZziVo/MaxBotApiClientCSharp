#region

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    public class MediaAttachmentPayload: AttachmentPayload
    {
        /// <summary>
        /// Используется, если повторно используется одно и то же вложение в другом сообщении
        /// </summary>
        public string Token { get; set; }
    }
}