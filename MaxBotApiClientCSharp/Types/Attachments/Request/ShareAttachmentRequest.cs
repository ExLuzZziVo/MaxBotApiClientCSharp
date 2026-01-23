#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Attachments.Request.Payloads;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request
{
    /// <summary>
    /// Запрос на прикрепление внешнего вложения
    /// </summary>
    public class ShareAttachmentRequest: AttachmentRequest
    {
        /// <summary>
        /// Запрос на прикрепление внешнего вложения
        /// </summary>
        /// <param name="payload">Информация о вложении</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="payload"/> обязателен</exception>
        public ShareAttachmentRequest(ShareAttachmentPayload payload): base(AttachmentType.Share)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            Payload = payload;
        }

        /// <summary>
        /// Информация о вложении
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public ShareAttachmentPayload Payload { get; }
    }
}