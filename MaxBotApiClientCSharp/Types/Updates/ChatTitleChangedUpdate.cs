#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда было изменено название чата
    /// </summary>
    public class ChatTitleChangedUpdate: Update
    {
        public ChatTitleChangedUpdate(): base(UpdateType.ChatTitleChanged) { }

        /// <summary>
        /// ID чата, где произошло событие
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, который изменил название
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Новое название
        /// </summary>
        public string Title { get; set; }
    }
}