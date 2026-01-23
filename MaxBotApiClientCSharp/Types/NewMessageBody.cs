#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Attachments.Request;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Содержимое нового сообщения
    /// </summary>
    public class NewMessageBody
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 4000</item>
        /// </list>
        [StringLength(4000, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Text { get; set; }

        /// <summary>
        /// Вложения сообщения
        /// </summary>
        [ComplexObjectCollectionValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public AttachmentRequest[] Attachments { get; set; }

        /// <summary>
        /// Ссылка на сообщение
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public NewMessageLink Link { get; set; }

        /// <summary>
        /// Флаг, указывающий будут ли участники чата уведомлены о сообщении
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        public bool Notify { get; set; } = true;

        /// <summary>
        /// Тип форматирования сообщения
        /// </summary>
        public TextFormat? Format { get; set; }
    }
}