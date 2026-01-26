#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Buttons;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    /// <summary>
    /// Данные прикрепляемых кнопок
    /// </summary>
    public class InlineKeyboardAttachmentRequestPayload
    {
        /// <summary>
        /// Данные прикрепляемых кнопок
        /// </summary>
        /// <param name="buttons">Двумерный массив кнопок</param>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="buttons"/> обязателен и должен содержать хотя бы один элемент</exception>
        public InlineKeyboardAttachmentRequestPayload(Button[,] buttons)
        {
            if (buttons == null || buttons.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(buttons));
            }

            Buttons = buttons;
        }

        /// <summary>
        /// Двумерный массив кнопок
        /// </summary>
        [TwoDimensionalArrayConverter<Button>]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public Button[,] Buttons { get; }
    }
}