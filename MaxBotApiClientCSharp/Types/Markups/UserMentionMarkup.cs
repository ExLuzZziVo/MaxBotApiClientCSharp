#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Упоминание пользователя
    /// </summary>
    public class UserMentionMarkup: MarkupElement
    {
        public UserMentionMarkup(): base(MarkupType.UserMention) { }

        /// <summary>
        /// @username упомянутого пользователя
        /// </summary>
        [JsonPropertyName("user_link")]
        public string UserLink { get; set; }

        /// <summary>
        /// ID упомянутого пользователя без имени
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
    }
}