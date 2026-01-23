#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Ссылка на сообщение
    /// </summary>
    public class NewMessageLink
    {
        public NewMessageLink(string messageId, MessageLinkType linkType)
        {
            if (messageId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            Type = linkType;
            MessageId = messageId;
        }

        /// <summary>
        /// Тип ссылки сообщения
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public MessageLinkType Type { get; }

        /// <summary>
        /// ID сообщения исходного сообщения
        /// </summary>
        [JsonPropertyName("mid")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string MessageId { get; }
    }
}