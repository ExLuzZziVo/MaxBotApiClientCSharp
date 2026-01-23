#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Файл
    /// </summary>
    public class FileAttachment: Attachment
    {
        public FileAttachment(): base(AttachmentType.File) { }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        public FileAttachmentPayload Payload { get; set; }

        /// <summary>
        /// Имя загруженного файла
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public long Size { get; set; }
    }
}