#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Получатель сообщения
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// ID чата
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long? ChatId { get; set; }

        /// <summary>
        /// Тип чата
        /// </summary>
        [JsonPropertyName("chat_type")]
        public ChatType ChatType { get; set; }

        /// <summary>
        /// ID пользователя, если сообщение было отправлено пользователю
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
    }
}