#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее при удалении сообщения
    /// </summary>
    public class MessageRemovedUpdate: Update
    {
        public MessageRemovedUpdate(): base(UpdateType.MessageRemoved) { }

        /// <summary>
        /// ID удаленного сообщения
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// ID чата, где сообщение было удалено
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// ID пользователя, удалившего сообщение
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}