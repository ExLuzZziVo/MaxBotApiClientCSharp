#region

using System;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Сообщение в чате
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Пользователь, отправивший сообщение
        /// </summary>
        public User Sender { get; set; }

        /// <summary>
        /// Получатель сообщения
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Время создания сообщения
        /// </summary>
        [UnixTimestampConverter]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Пересланное или ответное сообщение
        /// </summary>
        public LinkedMessage Link { get; set; }

        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        /// <remarks>
        /// Может быть null, если сообщение содержит только пересланное сообщение
        /// </remarks>
        public MessageBody Body { get; set; }

        /// <summary>
        /// Статистика сообщения
        /// </summary>
        public MessageStat Stat { get; set; }

        /// <summary>
        /// Публичная ссылка на пост в канале. Отсутствует для диалогов и групповых чатов
        /// </summary>
        public string Url { get; set; }
    }
}