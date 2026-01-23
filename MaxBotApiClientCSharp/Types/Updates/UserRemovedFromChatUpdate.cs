#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда пользователь был удален из чата
    /// </summary>
    public class UserRemovedFromChatUpdate: Update
    {
        public UserRemovedFromChatUpdate(): base(UpdateType.UserRemoved) { }

        /// <summary>
        /// ID чата, где произошло событие
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, удалённый из чата
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Администратор, который удалил пользователя из чата
        /// </summary>
        /// <remarks>
        /// Может быть null, если пользователь покинул чат сам
        /// </remarks>
        [JsonPropertyName("admin_id")]
        public long? AdminId { get; set; }

        /// <summary>
        /// Флаг, указывающий, был ли пользователь удалён из канала
        /// </summary>
        [JsonPropertyName("is_channel")]
        public bool IsChannel { get; set; }
    }
}