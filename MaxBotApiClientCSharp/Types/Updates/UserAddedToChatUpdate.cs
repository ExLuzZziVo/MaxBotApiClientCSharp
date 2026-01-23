#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда пользователь был добавлен в чат
    /// </summary>
    public class UserAddedToChatUpdate: Update
    {
        public UserAddedToChatUpdate(): base(UpdateType.UserAdded) { }

        /// <summary>
        /// ID чата, где произошло событие
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, добавленный в чат
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Пользователь, который добавил пользователя в чат
        /// </summary>
        /// <remarks>
        /// Может быть null, если пользователь присоединился к чату по ссылке
        /// </remarks>
        [JsonPropertyName("inviter_id")]
        public long? InviterId { get; set; }

        /// <summary>
        /// Флаг, указывающий, был ли пользователь добавлен в канал
        /// </summary>
        [JsonPropertyName("is_channel")]
        public bool IsChannel { get; set; }
    }
}