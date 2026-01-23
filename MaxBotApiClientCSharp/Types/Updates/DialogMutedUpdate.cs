#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда пользователь отключил уведомления
    /// </summary>
    public class DialogMutedUpdate: Update
    {
        public DialogMutedUpdate(): base(UpdateType.DialogMuted) { }

        /// <summary>
        /// ID чата, где произошло событие
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, который отключил уведомления
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Время, до наступления которого диалог был отключён
        /// </summary>
        [JsonPropertyName("muted_until")]
        [UnixTimestampConverter]
        public DateTime MutedUntil { get; set; }

        /// <summary>
        /// Текущий язык пользователя в формате IETF BCP 47
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; }
    }
}