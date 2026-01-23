#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Users
{
    /// <summary>
    /// Информация об участнике чата
    /// </summary>
    public class ChatMember: UserWithPhoto
    {
        /// <summary>
        /// Время последней активности пользователя в чате
        /// </summary>
        [JsonPropertyName("last_access_time")]
        [UnixTimestampConverter]
        public DateTime LastAccessTime { get; set; }

        /// <summary>
        /// Флаг, указывающий является ли пользователь владельцем чата
        /// </summary>
        [JsonPropertyName("is_owner")]
        public bool IsOwner { get; set; }

        /// <summary>
        /// Флаг, указывающий является ли пользователь администратором чата
        /// </summary>
        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Дата присоединения к чату
        /// </summary>
        [JsonPropertyName("join_time")]
        [UnixTimestampConverter]
        public DateTime JoinTime { get; set; }

        /// <summary>
        /// Перечень прав пользователя
        /// </summary>
        public ChatAdminPermission[] Permissions { get; set; }

        /// <summary>
        /// Заголовок, который будет показан на клиенте
        /// </summary>
        public string Alias { get; set; }
    }
}