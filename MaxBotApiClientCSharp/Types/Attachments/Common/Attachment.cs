#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common
{
    /// <summary>
    /// Вложение сообщения
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AudioAttachment), "audio")]
    [JsonDerivedType(typeof(ContactAttachment), "contact")]
    [JsonDerivedType(typeof(FileAttachment), "file")]
    [JsonDerivedType(typeof(InlineKeyboardAttachment),
        "inline_keyboard")]
    [JsonDerivedType(typeof(LocationAttachment), "location")]
    [JsonDerivedType(typeof(ImageAttachment), "image")]
    [JsonDerivedType(typeof(ShareAttachment), "share")]
    [JsonDerivedType(typeof(StickerAttachment), "sticker")]
    [JsonDerivedType(typeof(VideoAttachment), "video")]
    public abstract class Attachment
    {
        /// <summary>
        /// Вложение сообщения
        /// </summary>
        /// <param name="type">Тип вложения</param>
        [JsonConstructor]
        protected Attachment(AttachmentType type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип вложения
        /// </summary>
        [JsonIgnore]
        public AttachmentType Type { get; }
    }
}
