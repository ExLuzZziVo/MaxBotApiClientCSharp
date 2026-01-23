#region

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Информация о чате
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// ID чата
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Тип чата
        /// </summary>
        public ChatType Type { get; set; }

        /// <summary>
        /// Статус чата
        /// </summary>
        public ChatStatus Status { get; set; }

        /// <summary>
        /// Отображаемое название чат
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Иконка чата
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// Время последнего события в чате
        /// </summary>
        [JsonPropertyName("last_event_time")]
        [UnixTimestampConverter]
        public DateTime LastEventTime { get; set; }

        /// <summary>
        /// Количество участников чата
        /// </summary>
        [JsonPropertyName("participants_count")]
        public int ParticipantsCount { get; set; }

        /// <summary>
        /// ID владельца чата
        /// </summary>
        [JsonPropertyName("owner_id")]
        public long? OwnerId { get; set; }

        //ToDo DateTime
        /// <summary>
        /// Участники чата с временем последней активности
        /// </summary>
        public IDictionary<string, long> Participants { get; set; }

        /// <summary>
        /// Флаг, указывающий доступен ли чат публично
        /// </summary>
        [JsonPropertyName("is_public")]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Ссылка на чат
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Описание чата
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Данные о пользователе в диалоге
        /// </summary>
        [JsonPropertyName("dialog_with_user")]
        public UserWithPhoto DialogWithUser { get; set; }

        /// <summary>
        /// Количество сообщений в чате
        /// </summary>
        [JsonPropertyName("messages_count")]
        public int? MessagesCount { get; set; }

        /// <summary>
        /// ID сообщения, содержащего кнопку, через которую был инициирован чат
        /// </summary>
        [JsonPropertyName("chat_message_id")]
        public string ChatMessageId { get; set; }

        /// <summary>
        /// Закреплённое сообщение в чате
        /// </summary>
        [JsonPropertyName("pinned_message")]
        public Message PinnedMessage { get; set; }
    }
}