#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    /// <summary>
    /// Данные прикрепляемого вложения
    /// </summary>
    public class AttachmentRequestPayload
    {
        /// <summary>
        /// Данные прикрепляемого вложения
        /// </summary>
        /// <param name="token">Уникальный ID загруженного файла</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="token"/> обязателен</exception>
        public AttachmentRequestPayload(string token)
        {
            if (token.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(token));
            }

            Token = token;
        }

        /// <summary>
        /// Уникальный ID загруженного файла
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string Token { get; }
    }
}