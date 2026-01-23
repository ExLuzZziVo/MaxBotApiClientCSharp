#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда бот был удален из чата
    /// </summary>
    public class BotRemovedFromChatUpdate: Update
    {
        public BotRemovedFromChatUpdate(): base(UpdateType.BotRemoved) { }

        /// <summary>
        /// ID чата, откуда был удалён бот
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChaId { get; set; }

        /// <summary>
        /// Пользователь, удаливший бота из чата
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Флаг, указывающий, был ли бот удален из канала
        /// </summary>
        [JsonPropertyName("is_channel")]
        public bool IsChannel { get; set; }
    }
}