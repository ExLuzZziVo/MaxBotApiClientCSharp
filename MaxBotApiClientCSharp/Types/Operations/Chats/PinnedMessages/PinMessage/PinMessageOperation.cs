#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.PinnedMessages.PinMessage
{
    public class PinMessageOperation
    {
        /// <summary>
        /// ID сообщения, которое нужно закрепить
        /// </summary>
        [JsonPropertyName("message_id")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string MessageId { get; set; }

        /// <summary>
        /// Флаг, указывающий будут ли участники чата уведомлены об изменении
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        public bool Notify { get; set; } = true;
    }
}