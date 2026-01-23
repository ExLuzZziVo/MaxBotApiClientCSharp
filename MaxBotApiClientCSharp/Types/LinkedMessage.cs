#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Пересланное или ответное сообщение
    /// </summary>
    public class LinkedMessage
    {
        /// <summary>
        /// Тип связанного сообщения
        /// </summary>
        public MessageLinkType Type { get; set; }

        /// <summary>
        /// Пользователь, отправивший сообщение
        /// </summary>
        public User Sender { get; set; }

        /// <summary>
        /// Чат, в котором сообщение было изначально опубликовано
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public MessageBody Message { get; set; }
    }
}