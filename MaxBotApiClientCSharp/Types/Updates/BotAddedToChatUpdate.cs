#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда бот присоединился к чату
    /// </summary>
    public class BotAddedToChatUpdate: Update
    {
        public BotAddedToChatUpdate(): base(UpdateType.BotAdded) { }

        /// <summary>
        /// ID чата, куда был добавлен бот
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, добавивший бота в чат
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Флаг, указывающий, был ли бот добавлен в канал
        /// </summary>
        [JsonPropertyName("is_channel")]
        public bool IsChannel { get; set; }
    }
}