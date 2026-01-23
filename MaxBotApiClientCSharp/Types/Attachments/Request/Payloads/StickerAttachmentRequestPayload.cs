#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    /// <summary>
    /// Данные прикрепляемого стикера
    /// </summary>
    public class StickerAttachmentRequestPayload
    {
        /// <summary>
        /// Данные прикрепляемого стикера
        /// </summary>
        /// <param name="code">Код стикера</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="code"/> обязателен</exception>
        public StickerAttachmentRequestPayload(string code)
        {
            if (code.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(code));
            }

            Code = code;
        }

        /// <summary>
        /// Код стикера
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string Code { get; }
    }
}