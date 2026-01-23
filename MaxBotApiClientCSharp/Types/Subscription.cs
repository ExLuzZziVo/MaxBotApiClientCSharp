#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Подписка на события
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// URL вебхука
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Время, когда была создана подписка
        /// </summary>
        [UnixTimestampConverter]
        public DateTime Time { get; set; }

        /// <summary>
        /// Типы обновлений, на которые подписан бот
        /// </summary>
        [JsonPropertyName("update_types")]
        public UpdateType[] UpdateTypes { get; set; }
    }
}