#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда пользователь нажал кнопку 'Start'
    /// </summary>
    public class BotStartedUpdate: Update
    {
        public BotStartedUpdate(): base(UpdateType.BotStarted) { }

        /// <summary>
        /// ID диалога, где произошло событие
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Пользователь, который нажал кнопку 'Start'
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Дополнительные данные из дип-линков, переданные при запуске бота
        /// </summary>
        /// <remarks>
        /// До 512 символов
        /// </remarks>
        public string Payload { get; set; }

        /// <summary>
        /// Текущий язык пользователя в формате IETF BCP 47
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; }
    }
}