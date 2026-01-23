#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Результат нажатия кнопки бота пользователем
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Время, когда пользователь нажал кнопку
        /// </summary>
        [UnixTimestampConverter]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Текущий ID клавиатуры
        /// </summary>
        [JsonPropertyName("callback_id")]
        public string CallbackId { get; set; }

        /// <summary>
        /// Токен кнопки
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Пользователь, нажавший на кнопку
        /// </summary>
        public User User { get; set; }
    }
}