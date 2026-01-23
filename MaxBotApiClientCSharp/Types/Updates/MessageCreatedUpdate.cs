#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее при отправке нового сообщения
    /// </summary>
    public class MessageCreatedUpdate: Update
    {
        public MessageCreatedUpdate(): base(UpdateType.MessageCreated) { }

        /// <summary>
        /// Новое созданное сообщение
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Текущий язык пользователя в формате IETF BCP 47
        /// </summary>
        /// <remarks>
        /// Доступно только в диалогах
        /// </remarks>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; }
    }
}