#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Attachments.Common;
using MaxBotApiClientCSharp.Types.Markups;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Содержимое сообщения
    /// </summary>
    public class MessageBody
    {
        /// <summary>
        /// Уникальный ID сообщения
        /// </summary>
        [JsonPropertyName("mid")]
        public string MessageId { get; set; }

        /// <summary>
        /// ID последовательности сообщения в чате
        /// </summary>
        public long Seq { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Вложения сообщения
        /// </summary>
        public Attachment[] Attachments { get; set; }

        /// <summary>
        /// Разметка текста сообщения
        /// </summary>
        public MarkupElement[] Markup { get; set; }
    }
}