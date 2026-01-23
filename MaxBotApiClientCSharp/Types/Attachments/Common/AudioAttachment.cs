#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Аудио
    /// </summary>
    public class AudioAttachment: Attachment
    {
        public AudioAttachment(): base(AttachmentType.Audio) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public MediaAttachmentPayload Payload { get; set; }

        /// <summary>
        /// Аудио транскрипция
        /// </summary>
        public string Transcription { get; set; }
    }
}