#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Users
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    [JsonDerivedType(typeof(ChatMember))]
    [JsonDerivedType(typeof(UserWithPhoto))]
    public class User
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Отображаемое имя пользователя
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отображаемая фамилия пользователя
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Отображаемое имя пользователя
        /// </summary>
        [Obsolete]
        public string Name { get; set; }

        /// <summary>
        /// Уникальное публичное имя пользователя
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Флаг, указывающий является ли пользователь ботом
        /// </summary>
        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// Время последней активности пользователя в MAX
        /// </summary>
        [JsonPropertyName("last_activity_time")]
        [UnixTimestampConverter]
        public DateTime LastActivityTime { get; set; }
    }
}