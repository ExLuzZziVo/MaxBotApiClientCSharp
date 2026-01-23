#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request
{
    /// <summary>
    /// Запрос на прикрепление вложения
    /// </summary>
    [JsonDerivedType(typeof(AudioAttachmentRequest))]
    [JsonDerivedType(typeof(ContactAttachmentRequest))]
    [JsonDerivedType(typeof(FileAttachmentRequest))]
    [JsonDerivedType(typeof(InlineKeyboardAttachmentRequest))]
    [JsonDerivedType(typeof(LocationAttachmentRequest))]
    [JsonDerivedType(typeof(ImageAttachmentRequest))]
    [JsonDerivedType(typeof(ShareAttachmentRequest))]
    [JsonDerivedType(typeof(StickerAttachmentRequest))]
    [JsonDerivedType(typeof(VideoAttachmentRequest))]
    public abstract class AttachmentRequest
    {
        /// <summary>
        /// Запрос на прикрепление вложения
        /// </summary>
        /// <param name="type">Тип вложения</param>
        protected AttachmentRequest(AttachmentType type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип вложения
        /// </summary>
        public AttachmentType Type { get; }
    }
}
